using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameLib.Core.Event
{
    /// <summary>
    /// 事件管理器
    /// 通用与UI 逻辑 数据等系统
    /// EventManager.SharedInstance.RegEventHandle(EventDefines.);
    /// </summary>
    public class EventManager
    {
        //public Action<object, object> EventHandler;
        public delegate void EventHandler(object param, object sender);

        protected Dictionary<int, List<EventHandler>> _events = null;
        //事件消息缓存
        private Queue<EventMessage> _eventMessageQueue = null;

        //是否开启异步消息
        private bool _enableAsynMsg = false;

        //测试某个事件ID
        public static int DebugEventID = -1;

        private static EventManager _instance = null;

        public static EventManager SharedInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventManager();
                }
                return _instance;
            }
        }

        public EventManager()
        {
            //初始化事件容器，设置大小
            _events = new Dictionary<int, List<EventHandler>>(2048);
            _eventMessageQueue = new Queue<EventMessage>(1024);
        }

        public bool EnableAsynMsg
        {
            get { return _enableAsynMsg; }
            set
            {
                _enableAsynMsg = value;
                if (_enableAsynMsg)
                {
                    EventRootScript.Create(this);
                }
            }
        }

        /// <summary>
        /// 注册事件和回调
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public EventHandler RegEventHandle(int eventID, EventHandler handler)
        {
            if (handler == null)
            {
                Trace.Fail("未设置回调，添加事件失败，失败ID：" + eventID);
                return null;
            }
            List<EventHandler> handlerList = null;
            if (!_events.TryGetValue(eventID, out handlerList))
            {
                handlerList = new List<EventHandler>();
                _events[eventID] = handlerList;
            }
            else
            {
                if (IndexOf(handlerList, handler) >= 0)
                {
                    return handler;
                }
            }
            handlerList.Add(handler);
            return handler;
        }

        /// <summary>
        /// 注销事件的回调
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="handler"></param>
        public void UnRegEventHandle(int eventID, EventHandler handler)
        {
            if (handler == null)
            {
                return;
            }
            List<EventHandler> handlerList;
            if (_events.TryGetValue(eventID, out handlerList))
            {
                int eventIndex = IndexOf(handlerList, handler);
                if (eventIndex >= 0)
                {
                    handlerList.RemoveAt(eventIndex);
                    //_events[eventID].Remove(handler);
                }
            }
        }

        /// <summary>
        /// 清理某一个事件的回调
        /// </summary>
        /// <param name="eventID"></param>
        public void CleanHandler(int eventID)
        {
            List<EventHandler> list;
            if (_events.TryGetValue(eventID, out list))
            {
                list.Clear();
                _events.Remove(eventID);
            }
        }

        /// <summary>
        /// 清理所有的事件信息
        /// </summary>
        public void CleanAllHandler()
        {
            _events.Clear();
        }

        /// <summary>
        /// 推送消息，执行注册的回调
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="param"></param>
        /// <param name="sender"></param>
        public void PushEvent(int eventID, object param, object sender)
        {
            try
            {
                List<EventHandler> handlerList;
                if (_events.TryGetValue(eventID, out handlerList))
                {
                    if (handlerList != null && handlerList.Count > 0)
                    {
                        //执行所有的回调函数
                        for (int i = 0; i < handlerList.Count; i++)
                        {
                            try
                            {
                                handlerList[i](param, sender);
                            }
                            catch (Exception ex)
                            {
                                handlerList.RemoveAt(i);
                                i--;
                                Trace.Fail(ex.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 发送事件。
        /// </summary>
        public void PushFixEvent(int eventType, object param = null, object sender = null, object target = null, bool isSync = true, float delayTime = 0f)
        {
            //判断是不是同步执行
            if (!isSync)
            {   //如果是异步,那么就把事件消息缓存起来,并返回
                CacheEventMessage(sender, target, eventType, param, delayTime);
                return;
            }

            //判断发送那个事件
            if (eventType == DebugEventID)
            {
                UnityEngine.Debug.LogError("发送某个事件:" + eventType);
            }
#if TRY_CATCH_EXCEPTION
            try
            {
#endif
            List<EventHandler> list;
            if (_events.TryGetValue(eventType, out list))
            {
                if (list != null && list.Count > 0)
                {
                    if (target == null)
                    {
                        //执行方法链里的所有方法
                        for (int i = 0; i < list.Count; i++)
                        {
#if TRY_CATCH_EXCEPTION
                                try
                                {
#endif
                                    list[i](param, sender);
#if TRY_CATCH_EXCEPTION
                                }
                                catch (Exception ex)
                                {
                                    LogError(ex.Message, ex.StackTrace);
                                    list.RemoveAt(i);
                                    i--;                        
                                }
#endif
                        }
                    }
                    else
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Target == target)
                            {
#if TRY_CATCH_EXCEPTION
                                    try
                                    {
#endif
                                        list[i](param, sender);
                                        break;
#if TRY_CATCH_EXCEPTION
                                    }
                                    catch (Exception ex)
                                    {
                                        LogError(ex.Message, ex.StackTrace);
                                        list.RemoveAt(i);
                                        i--;
                                    }
#endif

                            }
                        }
                    }
                }
            }
#if TRY_CATCH_EXCEPTION
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex.StackTrace);
            }
#endif
        }

        /// <summary>
        /// 事件管理器的心跳,用于处理异步消息
        /// </summary>
        public void Update()
        {
            if (_enableAsynMsg)
            {
                lock (_eventMessageQueue)
                {
                    var cnt = _eventMessageQueue.Count;
                    for (int i = 0; i < cnt; i++)
                    {
                        var msg = _eventMessageQueue.Dequeue();
                        if (msg.IsDelayExec())
                        {
                            _eventMessageQueue.Enqueue(msg);
                        }
                        else
                        {
                            PushFixEvent(msg.EventType, msg.Param, msg.Sender, msg.Target);
                        }
                    }
                }
            }
        }

        #region//私有函数

        //缓存事件消息
        private void CacheEventMessage(object sender, object target, int eventType, object param, float delayTime)
        {
            lock (_eventMessageQueue)
            {
                _eventMessageQueue.Enqueue(new EventMessage(sender, target, eventType, param, delayTime));
            }
        }

        /// <summary>
        /// 对比下回调函数列表，防止重复注册回调函数
        /// </summary>
        /// <param name="list"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        private int IndexOf(List<EventHandler> list, EventHandler handler)
        {
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Equals(handler))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        //日志
        private void Log(string msg)
        {
            if (System.Threading.Thread.CurrentThread.IsBackground)
            {
                Trace.Write(msg);
            }
            else
            {
                UnityEngine.Debug.Log(msg);
            }
        }
        //错误日志
        private void LogError(string msg, string detailmsg = "")
        {
            if (System.Threading.Thread.CurrentThread.IsBackground)
            {
                Trace.Fail(msg, detailmsg);
            }
            else
            {
                UnityEngine.Debug.LogError(msg + detailmsg);
            }
        }
        #endregion
    }
}
