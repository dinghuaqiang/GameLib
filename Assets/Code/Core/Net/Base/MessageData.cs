using System;
using System.Collections.Generic;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 新的消息数据封装
    /// </summary>
    public class MessageData
    {
        #region//静态数据
        //缓存的数据
        private static Dictionary<int, List<MessageData>> _cacheMsgTable = new Dictionary<int, List<MessageData>>();
        //消息头大小
        public const int HeaderBufferSize = 8;
        //消息最大size  // 服务器说最大包是语音包64k，定义接收缓冲区大小为4个最大包
        public const int MaxMsgDataSize = 256 * 1024;
        //缓冲区最小size
        public const int CacheMinSize = 64;
        //缓冲区最大size，超过此size的适合开始删除数据
        public const int CacheMaxSize = 2 * 1024 * 1024; //2M
        //当前缓冲区总大小
        public static int CurCacheSize = 0;
        #endregion

        #region//属性
        //消息ID，用于区分消息
        public int MsgID { get; private set; }
        //实际消息数据大小
        public int DataSize { get; set; }
        //数据缓存区大小
        public int CacheDataSize { get; private set; }
        //数据缓冲区
        public byte[] Data { get; private set; }
        //是否正在使用
        public bool Used { get; private set; }
        #endregion

        #region//公有函数
        //从缓冲区获取一条可用消息
        public static MessageData GetMsgData(int msgBodySize, int msgID)
        {
            MessageData result = null;
            var cacheSize = CalcToMultiple(msgBodySize);
            List<MessageData> list = null;
            lock (_cacheMsgTable)
            {
                if (_cacheMsgTable.TryGetValue(cacheSize, out list) && list.Count > 0)
                {
                    //取最后一条可用数据
                    result = list[list.Count - 1];
                    list.RemoveAt(list.Count - 1);
                }
                else
                {
                    result = new MessageData();
                    result.Data = new byte[cacheSize];
                    result.CacheDataSize = cacheSize;
                    CurCacheSize += cacheSize;
                }

                Array.Clear(result.Data, (int)msgBodySize, (int)(cacheSize - msgBodySize));

                if (CurCacheSize > CacheMaxSize)
                {
                    //超过最大值后，清除掉当前最大的缓冲区
                    var iter = _cacheMsgTable.GetEnumerator();
                    try
                    {
                        int curMaxCache = 0;
                        List<MessageData> maxList = null;
                        while (iter.MoveNext())
                        {
                            if (iter.Current.Key > curMaxCache && iter.Current.Value.Count > 0)
                            {
                                curMaxCache = iter.Current.Key;
                                maxList = iter.Current.Value;
                            }
                        }

                        if (maxList != null)
                        {
                            CurCacheSize -= curMaxCache * maxList.Count;
                            _cacheMsgTable.Remove(curMaxCache);
                        }
                    }
                    finally
                    {
                        iter.Dispose();
                    }
                }
            }
            result.MsgID = msgID;
            result.DataSize = msgBodySize;
            result.Used = true;

            return result;
        }

        //归还消息数据到缓冲区
        public static void FreeMsgData(MessageData data)
        {
            if (data == null)
                return;
            data.Used = false;
            List<MessageData> list = null;
            lock (_cacheMsgTable)
            {
                if (!_cacheMsgTable.TryGetValue(data.CacheDataSize, out list))
                {
                    list = new List<MessageData>();
                    _cacheMsgTable[data.CacheDataSize] = list;
                }
                list.Add(data);
            }
        }

        //清除所有缓冲区
        public static void ClearAllCache()
        {
            _cacheMsgTable.Clear();
            CurCacheSize = 0;
        }

    
        #endregion

        #region//私有函数
        //将数据size规范化为最小size的倍数
        private static int CalcToMultiple(int source)
        {
            var count = source / CacheMinSize;
            if (source % CacheMinSize == 0)
            {
                count = count * CacheMinSize;
            }
            else
            {
                count = (count + 1) * CacheMinSize;
            }
            //规范最小size
            if (count < CacheMinSize)
            {
                count = CacheMinSize;
            }
            return count;
        }
        #endregion
    }
}
