using System;
using System.Collections.Concurrent;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Socket.Core.Model;

namespace Socket.Core
{
    /// <summary>
    /// 异步socket + ProtoBuffer格式传输数据
    /// </summary>
    public class SocketConnectionServerDispatcher : SocketConnection
    {
        #region Static Member
        /// <summary>
        /// 服务端监听socket
        /// </summary>
        public static readonly System.Net.Sockets.Socket ServerSocketListenner;

        /// <summary>
        /// 服务端开启的socket客户端
        /// </summary>
        public static SocketConnection ServerSocketClient;

        /// <summary>
        /// 取消异步操作信号量
        /// </summary>
        private static CancellationTokenSource _cancellationTocken = new CancellationTokenSource();

        /// <summary>
        /// 保存持久连接socket
        /// </summary>
        public static readonly ConcurrentDictionary<string, SocketConnection> DicSockectConnection = new ConcurrentDictionary<string, SocketConnection>();
        /// <summary>
        /// 服务器编号
        /// </summary>
        public static readonly byte ServerId;
        /// <summary>
        /// 上位机对外ip端口
        /// </summary>
        public static readonly string ServerOutIpEndPort;
        #endregion

        #region Static Method
        static SocketConnectionServerDispatcher()
        {
            var serverid = ConfigurationManager.AppSettings["serverid"];
            var dhost = ConfigurationManager.AppSettings["shost"];
            var dport = ConfigurationManager.AppSettings["sport"];
            var bufsize = ConfigurationManager.AppSettings["buffersize"];
            var maxcon = ConfigurationManager.AppSettings["maxconnect"];
            ServerOutIpEndPort = ConfigurationManager.AppSettings["serverip"];
            if (!byte.TryParse(serverid, out ServerId))
            {
                ServerId = 0x00;
            }
            if (!int.TryParse(bufsize, out BufferSize))
            {
                BufferSize = 1024;//每个socke1kb缓存
            }
            int port;
            if (!int.TryParse(dport, out port))
            {
                port = 44444;
            }
            int maxConnect;
            if (!int.TryParse(maxcon, out maxConnect))
            {
                maxConnect = 10000;
            }
            var ip = IPAddress.Parse(dhost);
            var ipe = new IPEndPoint(ip, port);
            try
            {
                ServerSocketListenner = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ServerSocketListenner.Bind(ipe);
                ServerSocketListenner.Listen(maxConnect);
            }
            catch (SocketException se)
            {
                SocketException(null, se);
            }
        }

        /// <summary>
        /// 开启服务端socket监听
        /// </summary>
        public static void ServerSocketListing(Action<ISocketConnection> acceptCallback = null, Action<ISocketConnection> disConnectCallback = null
            , Action<byte[], ISocketConnection> recevieCallBack = null, Action<ISocketConnection> sendCallback = null
            , Action<string> showMsg = null,Action<Exception> socketExceptionCallback=null,Action disposeCallback=null)
        {
            var sktconfig = new SocketConnectConfig()
            {
                AcceptCallback = acceptCallback,
                DisConnectCallback = disConnectCallback,
                ReceiveCallback = recevieCallBack,
                SendCallback = sendCallback,
                ServerSocket = ServerSocketListenner,
                ShowMsg = showMsg,
                SocketConnectExceptionCallback = socketExceptionCallback,
                DisposeCallback = disposeCallback
            };
            ServerSocketListing(sktconfig);
        }

        /// <summary>
        /// 开启服务端socket监听
        /// </summary>
        public static void ServerSocketListing(SocketConnectConfig sktconfig)
        {
            DicSockectConnection.Clear();
            _cancellationTocken = new CancellationTokenSource();
            if (sktconfig == null) sktconfig = new SocketConnectConfig() { ServerSocket = ServerSocketListenner };
            else if (sktconfig.ServerSocket == null) sktconfig.ServerSocket = ServerSocketListenner;
            Sktconfig = sktconfig;
            try
            {
                if (SocketConnectionClient.SocketClient != null && SocketConnectionClient.SocketClient.Connected)
                {
                    SocketConnectionClient.SocketClientConnection.Disconnect();
                }

                SocketConnectionClient.ClientSocketStarting(connection =>
                    {
                        ServerSocketClient = (SocketConnection) connection;
                        SendCurrentConnectionCount();
                    } //监听打开后，发送当前上位机的连接数目信息
                );

                ServerSocketListenner.IOControl(IOControlCode.KeepAliveValues, KeepAlive(1, Sktconfig.KeepAliveTime ?? 2 * 60 * 1000, Sktconfig.KeepAliveTime ?? 2 * 60 * 1000), null);//设置心跳检测
                ServerSocketListenner.BeginAccept(AcceptCallback, sktconfig);
                Task.Run(() => //解决主线程直接调用报错
                {
                    ShowMsg($"socket server listening at {ServerSocketListenner.LocalEndPoint}...");
                });
            }
            catch (SocketException se)
            {
                SocketException(ServerSocketListenner, se);
            }
        }

        private static byte[] KeepAlive(int onOff, int keepAliveTime, int keepAliveInterval)
        {
            byte[] buffer = new byte[12];
            BitConverter.GetBytes(onOff).CopyTo(buffer, 0);
            BitConverter.GetBytes(keepAliveTime).CopyTo(buffer, 4);
            BitConverter.GetBytes(keepAliveInterval).CopyTo(buffer, 8);
            return buffer;
        }

        private static void SendCurrentConnectionCount()
        {
            if (ServerSocketClient != null && ServerSocketClient.ConnectSocket.Connected)
            {
                var servertimeToken = (DateTime.Now.Ticks - new DateTime(1970, 1, 1).Ticks) / 10000 - TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Hours * 3600 * 1000;
                var snedMsg =
                    new byte[] {0xFE, 0x01}.Concat(new[] {ServerId})
                        .Concat(BitConverter.GetBytes(DicSockectConnection.Count))
                        .Concat(Encoder.GetBytes(ServerSocketListenner.LocalEndPoint.ToString()))
                        .Concat(BitConverter.GetBytes(servertimeToken)).ToArray();
                ServerSocketClient.Send(snedMsg);
            }
        }

        /// <summary>
        /// 开启监听回调,每次有新客户端通过beginConnect连接过来都会触发这里
        /// </summary>
        /// <param name="ar"></param>
        private static void AcceptCallback(IAsyncResult ar)
        {
            if (_cancellationTocken.IsCancellationRequested) return;
            var ssocketConfig = ar.AsyncState as SocketConnectConfig;
            var client = ssocketConfig?.ServerSocket?.EndAccept(ar);
            ssocketConfig?.ServerSocket?.BeginAccept(AcceptCallback, ssocketConfig);//继续监听其他请求
            var currSocketConnection = new SocketConnection(client);
            currSocketConnection.ReceiveData();
            Sktconfig?.AcceptCallback?.Invoke(currSocketConnection);
            //LogMsg(client?.LocalEndPoint.ToString(), client?.RemoteEndPoint.ToString(), $"accept remote {client?.RemoteEndPoint}\r\n");
        }

        public static void Dispose(Action disposeCallback = null)
        {
            _cancellationTocken.Cancel();
            foreach (string id in DicSockectConnection.Keys)
            {
                SocketConnection currSocketConnection;
                if (DicSockectConnection.TryGetValue(id, out currSocketConnection)) currSocketConnection.Disconnect();
            }
            DicSockectConnection.Clear();
            Task.Run(() =>//解决主线程直接调用报错
            {
                ShowMsg("socket closed");
            });
            if (disposeCallback != null)
            {
                disposeCallback.Invoke();
            }
            else
            {
                Sktconfig?.DisposeCallback?.Invoke();
            }
            GC.Collect();
            ServerSocketListenner.Dispose();
        }
        #endregion
        
        #region construct
        protected SocketConnectionServerDispatcher(System.Net.Sockets.Socket connect):base(connect)
        {
        }
        #endregion
    }
    
}
