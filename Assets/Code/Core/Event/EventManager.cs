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
        }

        /// <summary>
        /// 注册事件和回调
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public bool RegEventHandle(int eventID, EventHandler handler)
        {
            if (handler == null)
            {
                Trace.Fail("未设置回调，添加事件失败，失败ID：" + eventID);
                return false;
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
                    return true;
                }
            }
            handlerList.Add(handler);
            return true;
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
    }
}
