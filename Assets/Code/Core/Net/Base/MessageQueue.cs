using GameLib.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLib.Core.Net
{
    /// <summary>
    /// 消息队列
    /// </summary>
    public class MessageQueue
    {
        //普通消息，在UI线程处理
        private FSafeQueue<MessageData> _normalList = new FSafeQueue<MessageData>();
        //高优先级处理的消息，要先处理
        private FSafeQueue<MessageData> _highList = new FSafeQueue<MessageData>();
        //待处理的消息，这些消息是在线程中做处理，比如心跳消息，不走UI update，避免切到后台不处理
        private FSafeQueue<MessageData> _bgList = new FSafeQueue<MessageData>();

        private HashSet<int> _highIDs = new HashSet<int>();
        private HashSet<int> _bgIDs = new HashSet<int>();

        public int GetNormalMsgsCount()
        {
            return _normalList.Count;
        }
       
        public void SetHighMsgID(int msgID)
        {
            _highIDs.Add(msgID);
        }
        public void SetBgMsgID(int msgID)
        {
            _bgIDs.Add(msgID);
        }

        /// <summary>
        /// 存放解析后的消息
        /// </summary>
        /// <param name="tempData"></param>
        public void PushMsg(MessageData tempData)
        {
            //消息是在线程中处理还是在ui的update中处理
            if (_bgIDs.Contains((int)tempData.MsgID))
            {
                //在后台线程处理的
                _bgList.Enqueue(tempData);
            }
            else if (_highIDs.Contains((int)tempData.MsgID))
            {
                //优先处理的，在UI线程
                _highList.Enqueue(tempData);
            }
            else
            {
                //普通消息
                _normalList.Enqueue(tempData);
            }
        }

        /// <summary>
        /// 弹出一个主线程消息队列中的一个MessageData，可能为null
        /// </summary>
        /// <returns></returns>
        public MessageData PopNormalData()
        {
            MessageData ret = null;

            if (_normalList.Count > 0)
            {
                ret = _normalList.Dequeue();
            }
            return ret;
        }

        /// <summary>
        /// 弹出一个后台线程消息队列中的一个MessageData，可能为null
        /// </summary>
        /// <returns></returns>
        public MessageData PopBgData()
        {
            MessageData ret = null;

            if (_bgList.Count > 0)
            {
                ret = _bgList.Dequeue();
            }
            return ret;
        }


        /// <summary>
        /// 弹出一个优先处理的消息
        /// </summary>
        /// <returns></returns>
        public MessageData PopHighData()
        {
            MessageData ret = null;
            if (_highList.Count > 0)
            {
                ret = _highList.Dequeue();
            }
            return ret;
        }

        /// <summary>
        /// 清理数据
        /// </summary>
        /// <param name="bClearHighData"></param>
        public void ClearData(bool bClearHighData = false)
        {
            if (bClearHighData)
            {
                _highList.Clear();
            }
            _normalList.Clear();
            _bgList.Clear();
        }
    }
}
