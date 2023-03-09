using System;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace GameLib.Core.Utils
{
    public sealed partial class Utility
    {
        /// <summary>
        /// 网络相关的工具
        /// </summary>
        public static class Net
        {
            //用来获取公网IP和判断网络连接的地址
            private const string NET_USE_URL = "http://icanhazip.com";

            /// <summary>
            /// 获取本机的公共IP
            /// </summary>
            /// <param name="timeoutMilliseconds">timeout</param>
            /// <returns>public IP Address</returns>
            public static string GetPublicIPAddress(int timeoutMilliseconds = 5000)
            {
                var client = new WebClient();
                var task = client.DownloadStringTaskAsync(NET_USE_URL);
                if (task.Wait(timeoutMilliseconds) == false)
                    return string.Empty;
                return task.Result.Trim();
            }

            /// <summary>
            /// 获取本机的IPv4地址
            /// </summary>
            /// <returns>IP Address</returns>
            public static string GetLocalIPv4Address()
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
                throw new Exception("No network adapters with an IPv4 address in the system!");
            }

            /// <summary>
            /// 获取本机的IPv6地址
            /// </summary>
            /// <returns>IP Address</returns>
            public static string GetILocalIPv6Address()
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetworkV6)
                    {
                        return ip.ToString();
                    }
                }
                throw new Exception("No network adapters with an IPv6 address in the system!");
            }

            /// <summary>
            /// Ping URL是否存在；
            /// Ping的过程本身是阻塞的，谨慎使用！；
            /// </summary>
            /// <param name="url">资源地址</param>
            /// <returns>是否存在</returns>
            public static bool PingURI(string url)
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = client.GetAsync(url).Result;
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }

            public static bool IsNetworkEnable()
            {
                try
                {
                    Ping ping = new Ping();
                    //3秒后给结果
                    PingReply reply = ping.Send(NET_USE_URL, 3000);
                    if (reply.Status == IPStatus.Success)
                    {
                        //UnityEngine.Debug.Log("网络连接信号正常");
                        return true;
                    }
                    else
                    {
                        //UnityEngine.Debug.Log("网络连接无信号");
                        return false;
                    }
                }
                catch (Exception e)
                {
                    UnityEngine.Debug.LogError("网络连接信号异常" + e.Message);
                }
                return false;
            }
        }
    }
}
