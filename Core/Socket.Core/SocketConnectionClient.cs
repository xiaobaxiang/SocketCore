using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using Socket.Core.Model;

namespace Socket.Core
{
    public class SocketConnectionClient:SocketConnection
    {
        #region Static Member
        /// <summary>
        /// 服务端监听socket
        /// </summary>
        private static readonly EndPoint ServerSocketEndPoint;

        /// <summary>
        /// 当前客户端socket连接
        /// </summary>
        public static System.Net.Sockets.Socket SocketClient { private set; get; }

        /// <summary>
        /// 单例，指向当前对象
        /// </summary>
        public static SocketConnectionClient SocketClientConnection { private set; get; }
        #endregion
        
        #region Static Method
        static SocketConnectionClient()
        {
            //XmlDocument xd = new XmlDocument();
            //xd.Load("SocketConfig.xml");
            //dns
            //var dns = xd.SelectSingleNode("/socketconfig/dns")?.InnerText ?? "xiaobaxiang.top";
            // ip地址
            //var host = xd.SelectSingleNode("/socketconfig/shost")?.InnerText ?? "127.0.0.1";
            // 端口号
            //string o = xd.SelectSingleNode("/socketconfig/sport")?.InnerText ?? "9000";
            // 父级ip地址
            //var dhost = xd.SelectSingleNode("/socketconfig/dhost")?.InnerText;
            //// 父级端口号
            //string dport = xd.SelectSingleNode("/socketconfig/dport")?.InnerText??"";
            //int port;
            //if (!int.TryParse(dport, out port))
            //{
            //    port = 44444;
            //}
            ////每个socket连接的缓存
            //string o = xd.SelectSingleNode("/socketconfig/buffersize")?.InnerText ?? "10000";
            var dhost = ConfigurationManager.AppSettings["dhost"];
            var dport = ConfigurationManager.AppSettings["dport"];
            var o = ConfigurationManager.AppSettings["buffersize"];
            if (!int.TryParse(o, out BufferSize))
            {
                BufferSize = 1024;//每个socke1kb缓存
            }
            int port;
            if (!int.TryParse(dport, out port))
            {
                port = 44444;
            }
            if (!string.IsNullOrWhiteSpace(dhost) && port != 0)
            {
                var ip = IPAddress.Parse(dhost);
                ServerSocketEndPoint = new IPEndPoint(ip, port);
            }
        }

        /// <summary>
        /// 开启客户端socket
        /// </summary>
        public static void ClientSocketStarting(Action<ISocketConnection> conncetCallback = null, Action<ISocketConnection> disConnectCallback = null, Action<byte[], ISocketConnection> receiveCallback = null
            , Action<ISocketConnection> sendCallback = null, Action<string> showMsg = null, Action<Exception> socketExceptionCallback = null)
        {
            SocketConnectConfig sktconfig = new SocketConnectConfig()
            {
                ConnectCallback = conncetCallback,
                DisConnectCallback = disConnectCallback,
                ReceiveCallback = receiveCallback,
                SendCallback = sendCallback,
                ShowMsg = showMsg,
                SocketConnectExceptionCallback = socketExceptionCallback
            };
            ClientSocketStarting(sktconfig);
        }

        /// <summary>
        /// 开启客户端socket
        /// </summary>
        public static void ClientSocketStarting(SocketConnectConfig sktconfig)
        {
            if (ServerSocketEndPoint != null)
            {
                Sktconfig = sktconfig;
                SocketClient = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                SocketClientConnection = new SocketConnectionClient(SocketClient);
                SocketClient.BeginConnect(ServerSocketEndPoint, ConnectCallback, SocketClientConnection);
            }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                //处理连接上之后的逻辑
                //这个链接会在多次客户端请求的过程中重用，只会在第一次连接的时候调用，以后在不关闭通信窗口的时候不会重复调用
                //RemoteEndPoint远程地址 LocalEndPoint本地地址
                SocketConnectionClient handler = (SocketConnectionClient) ar.AsyncState;
                SocketClient.EndConnect(ar);
                LogMsg(handler.ConnectSocket.LocalEndPoint.ToString(), handler.ConnectSocket.RemoteEndPoint.ToString(), $"connect remote {handler.ConnectSocket.RemoteEndPoint}\r\n");
                Sktconfig.ConnectCallback?.Invoke(handler);
                handler.ReceiveData();
            }
            catch (SocketException sktex)
            {
                SocketException(SocketClient,sktex);
                SocketClient = null;
                SocketClientConnection = null;
            }
            catch (Exception ex)
            {
                Exception(ex);
            }
        }
        #endregion
        
        #region construct
        private SocketConnectionClient(System.Net.Sockets.Socket connect):base(connect)
        {
        }
        #endregion
    }
}
