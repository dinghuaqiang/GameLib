using System;
using System.Collections.Generic;
using System.Net.Sockets;

#pragma warning disable 0219
#pragma warning disable 0168
#pragma warning disable 0162


namespace GameLib.Core.Net
{
    /// <summary>
    /// 管理socket的连接、断开、发送、接收的逻辑，不处理接收数据或者发送数据的打包解包
    /// </summary>
    public class FSocketClient : ISocketClient
    {
        #region 内部字段
        //地址
        private string _ip;
        //端口
        private int _port;
        //发送者
        private FSocketSender _sender = new FSocketSender();
        //接收者
        private FSocketReceiver _receiver = new FSocketReceiver();
        //socket
        private Socket _socket;
        private bool _triggerDisconnect = false;
        #endregion

        #region 属性

        //断开连接的函数回调
        public Action<int> OnDisconnect { get; set; }

        //连接返回的函数回调
        public Action<bool> OnConnect { get; set; }

        public string Host
        {
            get { return _ip; }
            set { _ip = value; }
        }

        public int Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }

        public bool IsConnected
        {
            get
            {
                return FSocketAPI.IsConnected(_socket);
            }
        }

        public bool EnableReceived
        {
            get
            {
                return !_receiver.IsPause;
            }
            set
            {
                _receiver.IsPause = !value;
            }
        }

        public MessageQueue ReceivedQueue
        {
            get
            {
                return _receiver.MsgQueue;
            }
        }
        #endregion

        public void Send(byte[] msg)
        {
            _sender.Send(msg);
        }

        public void Initialize()
        {
            UnityEngine.Debug.LogError("FSocketClient.Initialize");
            _sender.OnDisconnect = DisconnectCallBack;
            _receiver.OnDisconnect = DisconnectCallBack;
            _receiver.Start();
            _sender.Start();
        }

        public void Uninitialize()
        {
            UnityEngine.Debug.LogError("FSocketClient.Uninitialize");
            _receiver.Stop();
            _sender.Stop();
            Close(true);
        }

        public void Close(bool clearData)
        {
            if (clearData)
            {
                _sender.ClearCache();
            }
            if (_socket != null)
            {
                FSocketAPI.Close(_socket);
                _socket = null;
            }
            _receiver.Socket = null;
            _sender.Socket = null;
        }

        public void Reflush()
        {
            _sender.Reflush();
        }

        public bool Connect()
        {
            return ConnectEx(_ip, _port);
        }

        //清理缓存
        public void ClearCache()
        {
            _sender.ClearCache();
            _receiver.ClearCache();
        }

        private bool ConnectEx(string aIp, int aPort)
        {
            //是否开始启动与服务器的网络连接
            bool isBeginConn = false;
            if (_socket != null)
            {
                Close(true);
            }
            _ip = aIp;
            _port = aPort;
            var s = FSocketAPI.BeginConnect(_ip, _port, x =>
            {

                _socket = (Socket)x.AsyncState;
                if (IsConnected)
                {
                    _triggerDisconnect = false;
                    SetSocket(_socket);
                    UnityEngine.Debug.LogError("连接服务器成功!" + _ip + ";" + _port);
                }
                else
                {
                    UnityEngine.Debug.LogError("连接服务器失败!" + _ip + ";" + _port);
                    SetSocket(null);
                }
                if (OnConnect != null) OnConnect(IsConnected);
            });
            //开始请求了
            isBeginConn = (s != null);
            return isBeginConn;
        }


        private void SetSocket(Socket s)
        {
            _socket = s;
            _sender.ClearCache();
            _sender.Socket = s;
            _receiver.Socket = s;
        }

        private void DisconnectCallBack(int code)
        {
            if (OnDisconnect!=null)
            {
                if (!_triggerDisconnect)
                {
                    _triggerDisconnect = true;
                    OnDisconnect(code);
                }
            }
        }


    }
}
