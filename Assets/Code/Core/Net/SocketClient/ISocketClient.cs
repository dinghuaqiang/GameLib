using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLib.Core.Net
{
    public interface ISocketClient
    {
        string Host { get; set; }
        int Port { get; set; }
        bool IsConnected { get; }
        bool EnableReceived { get; set; }
        MessageQueue ReceivedQueue { get; }
        Action<bool> OnConnect { get; set; }
        Action<int> OnDisconnect { get; set; }
        void Initialize();
        void Uninitialize();
        bool Connect();
        void Close(bool clearData);
        void Send(byte[] data);
        void Reflush();
        void ClearCache();
    }
}
