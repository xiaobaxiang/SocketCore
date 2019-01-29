using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using Socket.Core.Model;

namespace Socket.Core
{
    public class SocketConnectionReConnectClient : SocketConnection
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
        public static SocketConnectionReConnectClient SocketClientConnection { private set; get; }
        #endregion

        #region Static Method
        static SocketConnectionReConnectClient()
        {
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
            Sktconfig = sktconfig;
            if (ServerSocketEndPoint != null && (SocketClient == null || !SocketClient.Connected))
            {
                SocketClient = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                SocketClientConnection = new SocketConnectionReConnectClient(SocketClient);
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
                SocketConnectionReConnectClient handler = (SocketConnectionReConnectClient) ar.AsyncState;
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

        #region 发送数据 
        private static readonly List<byte[]> WaitSendBytes =new List<byte[]>();
        public static void SendByteData(byte[] byteData, Action<SocketConnection> sendCallBack = null)
        {
            if (SocketClientConnection!=null&&SocketClientConnection.ConnectSocket.Connected)
            {
                SocketClientConnection.Send(byteData,sendCallBack);
            }
            if (SocketClientConnection==null || !SocketClientConnection.ConnectSocket.Connected)
            {
                WaitSendBytes.Add(byteData);
                Sktconfig.ConnectCallback = (con) =>
                {
                    foreach (var bytes in WaitSendBytes)
                    {
                        con.Send(bytes);
                    }
                    WaitSendBytes.Clear();
                };
                ClientSocketStarting(Sktconfig);
            }
        }

        #endregion
        #region construct
        private SocketConnectionReConnectClient(System.Net.Sockets.Socket connect):base(connect)
        {
        }
        #endregion
    }
}
