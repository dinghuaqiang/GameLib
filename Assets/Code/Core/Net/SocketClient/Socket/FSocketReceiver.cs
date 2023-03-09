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
    /// 网络消息接受者
    /// </summary>
    public class FSocketReceiver
    {
        #region//常量

        //接受空数据的次数为250次,根据每次检测间隔为20ms,那么这样在5秒就能判断出来远端有问题
        private const int CN_RECEIVE_EMPTY_TIMES = 250;

        //接受数据的每次20毫秒间隔
        private const int CN_SELECT_READ_TIMEOUT = 20;
        #endregion

        #region 成员变量
        //接收消息的缓冲池
        private byte[] _buffer = new byte[MessageData.MaxMsgDataSize];

        //待处理的接收到的消息总长度，处理过的消息长度从这里减去
        private int _bufOffset = 0;

        //接受消息队列
        private MessageQueue _msgQueue = new MessageQueue();

        //消息解密
        private MessageSecurity _Security = new MessageSecurity();

        //接收消息线程
        private FThread _thread = new FThread();
        //Socket
        private Socket _socket;
        //是否暂停
        private bool _isPause = false;

        //触发断开的底线
        private int _deadline = CN_RECEIVE_EMPTY_TIMES;
        #endregion

        #region //属性
        public Socket Socket
        {
            get
            {
                return _socket;
            }
            set
            {
                _socket = value;
            }
        }

        public MessageQueue MsgQueue
        {
            get
            {
                return _msgQueue;
            }
        }

        public bool IsPause
        {
            get
            {
                return _isPause;
            }
            set
            {
                _isPause = value;
            }
        }

        //断开连接的函数回调
        public Action<int> OnDisconnect { get; set; }

        #endregion

        public void Start()
        {
            _thread.Start(OnRecvFunc);
        }

        public void Stop()
        {
            _thread.Stop();
        }

        public void Close()
        {
            //停止发送线程
            _thread.Stop();

            //把socket清理掉
            _socket = null;
        }

        private void OnRecvFunc(FThread.Switcher s)
        {
            UnityEngine.Debug.Log("开启网络接受线程... ...");
            while (s.On)
            {
                if (_socket != null && !_isPause)
                {
                    try
                    {
                        int num = 0;
                        if (_socket.Poll(CN_SELECT_READ_TIMEOUT*1000, SelectMode.SelectRead))
                        {
                            num = _socket.Receive(this._buffer, _bufOffset, (MessageData.MaxMsgDataSize - _bufOffset), SocketFlags.None);
                            if (num > 0)
                            {  
                                _deadline = CN_RECEIVE_EMPTY_TIMES;
                                _bufOffset += num;
                                _Security.Decoding(_msgQueue, _buffer, ref _bufOffset);
                            }
                            else
                            {//判断出来有数据,但是读取出来为空,则表示远程连接已经断开
                                Thread.Sleep(CN_SELECT_READ_TIMEOUT);
                                _deadline--;
                                if (_deadline <= 0)
                                {
                                    throw new Exception("检测到远端服务器关闭... ...");
                                }
                            }
                        }
                    }
                    catch (System.Exception ex2)
                    {
                        _socket = null;
                        int errorCode = -1;
                        if (ex2 is SocketException)
                        {
                            var ex = (ex2 as SocketException);
                            if (ex != null)
                            {
                                errorCode = ex.ErrorCode;
                                UnityEngine.Debug.LogError("网络错误码:" + errorCode);
                            }
                        }
                        UnityEngine.Debug.LogException(ex2);
                        PushDisconnectEvent(errorCode);
                    }
                }
                else
                {   //如果没有socket,那么就100毫秒一次.
                    Thread.Sleep(100);
                }
            }
            UnityEngine.Debug.Log("关闭网络接受线程... ...");
        }

        private void PushDisconnectEvent(int code)
        {
            if (OnDisconnect != null)
            {
                OnDisconnect(code);
            }
        }

        //清理缓存
        public void ClearCache()
        {
            _msgQueue.ClearData(false);
            if (this._buffer != null)
            {
                int length = this._buffer.Length;
                Array.Clear(this._buffer, 0, length);
            }
        }
    }
}
