using GameLib.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace GameLib.Core.Net
{
    /// <summary>
    /// 网络发送者
    /// </summary>
    public class FSocketSender
    {
        #region//变量
        //写数据的缓存队列
        private FSafeQueue<byte[]> _writeMsgQueue = new FSafeQueue<byte[]>();
        //线程
        private FThread _thread = new FThread();
        //socket
        private Socket _socket;
        //是否暂停
        private bool _isPause = false;
        #endregion

        #region//属性

        public Socket Socket
        {
            get {
                return _socket;
            }
            set
            {
                _socket = value;
            }
        }

        public bool IsPause
        {
            get { return _isPause; }
            set { _isPause = value; }
        }

        //断开连接的函数回调
        public Action<int> OnDisconnect { get; set; }

        #endregion

        public void Start()
        {
            _thread.Start(OnSendFunc);
        }

        public void Stop()
        {
            _thread.Stop();
        }

        public void Send(byte[] msg)
        {
            //Debug.LogError("发送消息长度:" + msg.Length + ";;" + (_socket != null) + ";;");
            _writeMsgQueue.Enqueue(msg);
        }

        public void ClearCache()
        {
            UnityEngine.Debug.LogError("清除发送队列!");
            _writeMsgQueue.Clear();
        }

        public void Close(bool clearData)
        {
            //停止发送线程
            _thread.Stop();

            //把socket清理掉
            _socket = null;

            //把发送缓存的数据清理掉
            if (clearData)
            {
                _writeMsgQueue.Clear();
            }
        }

        private void OnSendFunc(FThread.Switcher s)
        {
            UnityEngine.Debug.Log("开启网络发送线程... ...");
            while (s.On)
            {
                if (_socket != null && !_isPause)
                {
                    //如果socket不为空,就是0.01毫秒一次.
                    Thread.Sleep(10);
                    Reflush();
                }
                else
                {   //如果没有socket,那么就0.1毫秒一次.
                    Thread.Sleep(100);
                }
            }
            UnityEngine.Debug.Log("关闭网络发送线程... ...");
        }

        /// <summary>
        /// 发送消息，从消息队列中取出所有消息发送，并且从消息队列中移除
        /// </summary>
        public void Reflush()
        {
           
            while (_writeMsgQueue.Count > 0)
            {
                byte[] msgData = _writeMsgQueue.Dequeue(); 
                if (msgData == null) continue;
                try
                {
                    int sendLen = _socket.Send(msgData, msgData.Length, SocketFlags.None);
                    if (sendLen <= 0)
                    {
                        UnityEngine.Debug.LogError(string.Format("发送数据时: socket connect = {0}, canSend={1}, canReceive={2}", _socket.Connected, _socket.Poll(0, SelectMode.SelectWrite), _socket.Poll(0, SelectMode.SelectRead)));
                        //这里判断网络是否断开了，用于断线重连
                        PushDisconnectEvent(0);
                        break;
                    }
                }
                catch (System.Exception ex2)
                {
                    _socket = null;
                    int errorCode = -1;
                    ClearCache();
                    if (ex2 is SocketException)
                    {
                        var ex = (ex2 as SocketException);
                        if (ex != null)
                        {
                            errorCode = ex.ErrorCode;
                            UnityEngine.Debug.LogError("网络错误码:"+ errorCode);
                        }
                    }
                    UnityEngine.Debug.LogException(ex2);
                    PushDisconnectEvent(errorCode);
                    break;
                }
            }
        }

        private void PushDisconnectEvent(int code)
        {
            if (OnDisconnect != null)
            {
                OnDisconnect(code);
            }

        }
    }
}
