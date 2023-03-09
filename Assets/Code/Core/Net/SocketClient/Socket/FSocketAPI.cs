using System;
using System.Net;
using System.Net.Sockets;

namespace GameLib.Core.Net
{
    /// <summary>
    /// socket基础类，提供连接、接收、发送、关闭等基础功能
    /// </summary>
    public class FSocketAPI
    {
        //是否连接
        public static bool IsConnected(Socket socket)
        {
            //socket不为空
            if (socket != null)
            {
                return socket.Connected;
            }
            return false;
        }

        public static void Close(Socket socket)
        {
            if (socket == null) return;            
            try
            {
                if (socket.Connected)
                {
                    socket.Shutdown(SocketShutdown.Both);
                }
            }
            catch (SocketException exception)
            {
                UnityEngine.Debug.LogError(exception.ToString());
            }
            try
            {
                socket.Close();
            }
            catch (SocketException exception2)
            {
                UnityEngine.Debug.LogError(exception2.ToString());
            }
        }

        public static Socket BeginConnect(string ServerIP, int nPort, AsyncCallback callback)
        {
            Socket socket = null;
            try
            {

                UnityEngine.Debug.Log(string.Format("Start Connect: {0}:{1}", ServerIP, nPort));
                //1.直接解析ServerIP,如果是域名这里返回null
                IPAddress ipaddress;
                IPAddress.TryParse(ServerIP, out ipaddress);
                IPAddress[] ipArray = null;

                //2.如果是苹果,就直接调用IOS的脚本
#if UNITY_IPHONE && !UNITY_EDITOR
                //如果使用ios,那么就直接使用ipv6
                AddressFamily af = ipaddress.AddressFamily;
                ipArray = ResolveIOSAddress(ServerIP, out af); 
                if (ipArray.Length > 0)
                {
                    ipaddress = ipArray[0];
                }
#endif

                //3.如果通过ip地址解析失败,说明可能是个域名,那么就通过域名来获取ip地址
                if (ipaddress == null)
                {
                    var start = Environment.TickCount;
                    UnityEngine.Debug.Log("Start Domain name resolution:" + ServerIP );
                    var iphost = Dns.GetHostEntry(ServerIP);
                    ipArray = iphost.AddressList;
                    if (ipArray.Length > 0)
                    {
                        ipaddress = ipArray[0];
                        UnityEngine.Debug.Log("Successed, Time consume:" + (Environment.TickCount - start));
                    }
                    else
                    {
                        UnityEngine.Debug.Log("Failed, Time consume:" + (Environment.TickCount - start));
                    }
                    
                }

                //4.最后如果地址不为空,就可以创建连接了.
                if (ipaddress != null)
                {
                    UnityEngine.Debug.Log("ServerAddress parse successed! AddressFamily: " + ipaddress.AddressFamily +"::"+ ServerIP);
                    socket = new Socket(ipaddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    IPEndPoint point = new IPEndPoint(ipaddress, nPort);
                    EndPoint remoteEP = point;
                    socket.ReceiveBufferSize = 256 * 1024;
                    socket.BeginConnect(remoteEP, callback, socket);
                }
                else
                {
                    UnityEngine.Debug.LogError("ServerAddress parse failed!:" + ServerIP);
                }
            }
            catch (Exception ex)
            {
                socket = null;
                UnityEngine.Debug.LogError("连接服务器出现异常:" + ServerIP + "::" + nPort + ";;" + ex.Message);
                UnityEngine.Debug.LogException(ex);
            }
            return socket;
        }

        #region //IOS的地址解析方法
#if UNITY_IPHONE && !UNITY_EDITOR
        //调用ios的方法
        [DllImport("__Internal")]
        private static extern string IOSGetAddressInfo(string host);

        //解析host获取address地址列表
        //其中host可以是ip也可以是name
        public static IPAddress[] ResolveIOSAddress(string host, out AddressFamily af)
        {
            af = AddressFamily.InterNetwork;
            var outstr = IOSGetAddressInfo(host);
            UnityEngine.Debug.Log("IOSGetAddressInfo: " + outstr);
            if (outstr.StartsWith("ERROR"))
            {
                return null;
            }
            var addressliststr = outstr.Split('|');
            var addrlist = new List<IPAddress>();
            foreach (string s in addressliststr)
            {
                if (String.IsNullOrEmpty(s.Trim()))
                    continue;
                switch (s)
                {
                    case "ipv6":
                        {
                            af = AddressFamily.InterNetworkV6;
                        }
                        break;
                    case "ipv4":
                        {
                            af = AddressFamily.InterNetwork;
                        }
                        break;
                    default:
                        {
                            addrlist.Add(IPAddress.Parse(s));
                        }
                        break;
                }
            }
            return addrlist.ToArray();
        }
#endif
        #endregion
    }

}

