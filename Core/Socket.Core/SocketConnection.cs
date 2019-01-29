using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Socket.Core.Model;
using Socket.Core.Util;

namespace Socket.Core
{
    /// <summary>
    /// 智能家居
    /// </summary>
    public class SocketConnection:ISocketConnection
    {
        #region Static Member        
        /// <summary>
        /// 各种回调的配置
        /// </summary>
        protected static SocketConnectConfig Sktconfig;
        /// <summary>
        /// 每一个会话的缓存大小
        /// </summary>
        protected static int BufferSize;
        /// <summary>
        /// 设置编码格式
        /// </summary>
        protected static readonly Encoding Encoder = Encoding.UTF8;
        #endregion

        #region Properity
        /// <summary>
        /// 当前客户端socket连接
        /// </summary>
        public System.Net.Sockets.Socket ConnectSocket { get; }

        /// <summary>
        /// 当前socket会话次数
        /// </summary>
        private int TotalSession { set; get; }
        
        /// <summary>
        /// 子连接数
        /// </summary>
        public int SubConnection { get; set; } = 0;

        /// <summary>
        /// 最近一次会话时间
        /// </summary>
        public DateTime LastSessionTime { private set; get; }

        /// <summary>
        /// 粘包情况下，上次最末尾未处理的包 -----修改为，直接舍弃
        /// </summary>
        //private byte[] _prePartialReceiveByte;

        /// <summary>
        /// 当前连接的客户端标识,最大长度16位字符串
        /// </summary>
        public string Identity { get; set; } = "";
        
        /// <summary>
        /// socket连接类型
        /// </summary>
        public SocketConnectType SocketConnectType { set;  get; }
        /// <summary>
        /// App标识，单点登录
        /// </summary>
        public string PhoneMac { get; set; }

        #endregion

        #region construct

        public SocketConnection(System.Net.Sockets.Socket connect)
        {
            ConnectSocket = connect;
        }

        public virtual void Disconnect(Action<string> disConnectCallback = null)
        {
            //string localIpEndPort = ConnectSocket.LocalEndPoint.ToString();
            if (ConnectSocket!=null&& Identity!=null && ConnectSocket.Connected)
            {
                ConnectSocket.BeginDisconnect(false, ar =>
                {
                    disConnectCallback?.Invoke(Identity);
                    //LogMsg(localIpEndPort,remoteIpEndPort,$"disconnect socket remote {remoteIpEndPort} local {localIpEndPort}");
                }, null);
            }
            
        }
        #endregion

        #region Receive
        /// <summary>
        /// 接收数据
        /// </summary>
        public virtual void ReceiveData(Action<byte[], SocketConnection> receiveCallback = null)
        {
            try
            {
                var srb = new SocketReceiveBack() { Buffer = new byte[BufferSize], ReceiveCallback = receiveCallback };
                ConnectSocket.BeginReceive(srb.Buffer, 0, BufferSize, SocketFlags.None, ReceiveCallback, srb);
            }
            catch (SocketException sktex)
            {
                SocketException(ConnectSocket, sktex);
            }
            catch (Exception ex)
            {
                Exception(ex);
            }
        }

        public virtual void ReceiveCallback(IAsyncResult ar)
        {
            if (TotalSession >= 10000) TotalSession = 0;
            TotalSession++;
            System.Net.Sockets.Socket handler = ConnectSocket;
            var srb = ar.AsyncState as SocketReceiveBack;
            try
            {
                if (handler != null && !handler.Connected) //当近端主动Disconnect时会触发
                {
                    Sktconfig?.DisConnectCallback?.Invoke(this);
                    LogMsg(handler.LocalEndPoint.ToString(), handler.RemoteEndPoint.ToString(), $"disconnect remote {handler.RemoteEndPoint}\r\n");
                    return;
                }
                //最大是设置的msgbuffer的长度，如果发送的数据超过了buffer的长度就分批次接收
                //这里在客户端强制关闭也会进去这个回调，但是执行到EndReceive时会出错
                SocketError se;
                var rEnd = handler?.EndReceive(ar, out se);

                if (rEnd > 0&&srb!=null)
                {
                    var receiveBytes = srb.Buffer.Take(rEnd.Value).ToArray();

                    if (LastSessionTime == DateTime.MinValue)
                    {//websockethttp协议升级
                        #region 分析报文、文本
                        LastSessionTime = DateTime.Now;
                        string receiveText = Encoder.GetString(receiveBytes);
                        //确认客户端发送的是websocket握手协议包，解析出key
                        if (receiveText.IndexOf("Sec-WebSocket-Version:", StringComparison.Ordinal) != -1)
                        {
                            SocketConnectType = SocketConnectType.WebSocket;
                            string[] rawClientHandshakeLines = receiveText.Split(new [] { "\r\n" },
                                StringSplitOptions.RemoveEmptyEntries);

                            string secwebSocketKey =
                                rawClientHandshakeLines.FirstOrDefault(e => e.Contains("Sec-WebSocket-Key:"));
                            string acceptKey =
                                SocketTool.ComputeWebSocketHandshakeSecurityHash09(
                                    secwebSocketKey?.Substring(secwebSocketKey.IndexOf(":", StringComparison.Ordinal) + 2));
                            var newHandshake = Encoder.GetBytes(SocketTool.ComputeNewHandshake(acceptKey));
                            //返回websocket握手包
                            handler.BeginSend(newHandshake, 0, newHandshake.Length, 0, SendCallback, null);
                            handler.BeginReceive(srb.Buffer, 0, BufferSize, 0, ReceiveCallback, srb);
                            LogMsg(handler.LocalEndPoint.ToString(), handler.RemoteEndPoint.ToString(), $"from remote {handler.RemoteEndPoint} webSocket first session receive data [{receiveText}]\r\n");
                            return;
                        }
                        #endregion
                    }
                    else if (SocketConnectType == SocketConnectType.WebSocket)
                    {//websocket解析明文内容
                        receiveBytes = new DataFrame(receiveBytes).Content;
                    }

                    #region 解析每一个数据包
                    //LogMsg(handler.LocalEndPoint.ToString(), handler.RemoteEndPoint.ToString(), $"current session from remote {handler.RemoteEndPoint} receive data [{ BitConverter.ToString(receiveBytes)}]\r\n");
                    var bytepackage = GetPackage(receiveBytes);
                    int queeCount = bytepackage.Count;
                    handler.BeginReceive(srb.Buffer, 0, BufferSize, 0, ReceiveCallback, srb);
                    for (int i = 0; i < queeCount; i++)
                    {
                        //下面是正常业务逻辑处理
                        var bytemsg = bytepackage.Dequeue();
                        if(bytemsg.Length==0)continue;
                        LogMsg(handler.LocalEndPoint.ToString(), handler.RemoteEndPoint.ToString(), $"from {handler.RemoteEndPoint} receive [{ BitConverter.ToString(bytemsg)}]\r\n");
                        
                        if (srb.MsgRecevieCallBack != null)
                        {
                            srb.MsgRecevieCallBack(bytemsg, this);
                        }
                        else
                        {
                            Sktconfig?.ReceiveCallback?.Invoke(bytemsg, this);
                        }
                        //else //如果回调是空就原样返回，正常收发可达5000次/s
                        //{
                        //    Send(bytemsg);
                        //}
                    }
                    #endregion
                }
                else //远端主动Disconnect时会到达这里
                {
                    if (handler != null)
                    {
                        Sktconfig?.DisConnectCallback?.Invoke(this);
                        LogMsg(handler.LocalEndPoint.ToString(), handler.RemoteEndPoint.ToString(), $"remote {handler.RemoteEndPoint} has close\r\n");
                    }
                }
                LastSessionTime = DateTime.Now;
            }
            catch (SocketException sktex)
            {
                SocketException(handler, sktex);
            }
            catch (Exception ex)
            {
                Exception(ex);
            }
        }

        /// <summary>
        /// 将prePartialReceiveByte中的字节与本次取出来的字节拼接在一起，最后返回可用部分消息
        /// 现在直接返回第一包完整的数据
        /// </summary>
        /// <param name="receiveByte">本次从buffer中取出来的字节</param>
        /// <returns></returns>
        private Queue<byte[]> GetPackage(byte[] receiveByte)
        {
            var queePackage = new Queue<byte[]>();
            int msgLength;
            
            if (!receiveByte.Any(b=>b==0x0A))//当前包也是同一个消息中的一部分
                return queePackage;
            if (receiveByte.Length >= 6) //包最小长度6,过滤掉0数据长度包
            {
                byte[] byts = new byte[4];
                Array.Copy(receiveByte,0,byts,0,4);
                msgLength = BitConverter.ToInt32(byts, 0);
            }
            else
                return queePackage;

            int takeLength = 0;
            while (takeLength < receiveByte.Length)
            {
                var takeBytes = receiveByte.Skip(takeLength + 4).Take(msgLength - 4).ToArray();
                takeLength += takeBytes.Length + 4;
                if (takeLength == msgLength && takeBytes[takeBytes.Length - 2] == 0x0D &&takeBytes[takeBytes.Length - 1] == 0x0A)
                    queePackage.Enqueue(takeBytes.Take(takeBytes.Length - 2).ToArray());
                else break;
                receiveByte = receiveByte.Skip(takeLength).ToArray();
                if (receiveByte.Any(b => b == 0x0A))
                {
                    byte[] byts = new byte[4];
                    Array.Copy(receiveByte, 0, byts, 0, 4);
                    msgLength = BitConverter.ToInt32(byts, 0);
                }
                else break;
            }
            return queePackage;
        }
        //private Queue<byte[]> GetPackage(byte[] receiveByte)
        //{
        //    List<byte> package =new List<byte>();
        //    var queePackage = new Queue<byte[]>();
        //    int msgLength;

        //    if (_prePartialReceiveByte != null && _prePartialReceiveByte.Length > 0)
        //    {
        //        package= package.Concat(_prePartialReceiveByte).ToList();
        //    }
        //    package = package.Concat(receiveByte).ToList();
        //    int rIndex = package.IndexOf(0x0A);
        //    if (rIndex == -1)//当前包也是同一个消息中的一部分
        //    {//处理断包问题
        //        if (_prePartialReceiveByte != null && _prePartialReceiveByte.Length > 0)
        //        {
        //            var temp = _prePartialReceiveByte.ToList();
        //            temp.AddRange(receiveByte);
        //            _prePartialReceiveByte = temp.ToArray();
        //        }
        //        else
        //        {
        //            _prePartialReceiveByte = receiveByte;
        //        }
        //        return queePackage;
        //    }
        //    if (package.Count >= 6) //包最小长度6,过滤掉0数据长度包
        //    {
        //        byte[] byts = package.GetRange(0, 4).ToArray();
        //        msgLength = BitConverter.ToInt32(byts,0);
        //    }
        //    else
        //    {
        //        _prePartialReceiveByte = null;
        //        return queePackage;
        //    }

        //    int takeLength = 0;
        //    while (takeLength < package.Count)
        //    {
        //        var takeBytes = package.Skip(takeLength + 4).Take(msgLength - 4).ToArray();
        //        takeLength += takeBytes.Length + 4;
        //        if (takeBytes.Length + 4 == msgLength && takeBytes[takeBytes.Length - 2] == 0x0D &&
        //            takeBytes[takeBytes.Length - 1] == 0x0A)
        //        {
        //            queePackage.Enqueue(takeBytes.Take(takeBytes.Length - 2).ToArray());
        //        }
        //        else break;
        //        var currindex = package.IndexOf(0x0A, takeLength);
        //        if (currindex > 0 && currindex + 1 < package.Count)
        //        {
        //            byte[] byts = package.GetRange(takeLength, 4).ToArray();
        //            msgLength = BitConverter.ToInt32(byts, 0);
        //        }
        //        else break;
        //    }
        //    if (takeLength < package.Count)
        //    {
        //        _prePartialReceiveByte = package.GetRange(takeLength, package.Count - takeLength).ToArray();
        //    }
        //    else
        //    {
        //        _prePartialReceiveByte = null;
        //    }
        //    return queePackage;
        //}
        #endregion

        #region Send
        /// <summary>
        /// 发送字节数组，针对websocket协议本身就定义了前2，4，8字节为数据长度，所以不用加上自定义的数据帧长度了
        /// </summary>
        /// <param name="byteData"></param>
        /// <param name="sendCallBack">发送数据当前回调</param>
        public virtual void Send(byte[] byteData, Action<SocketConnection> sendCallBack = null)
        {
            try
            {
#if DEBUG
                LogMsg(ConnectSocket.LocalEndPoint.ToString(), ConnectSocket.RemoteEndPoint.ToString(), $"to {ConnectSocket.RemoteEndPoint} data [{BitConverter.ToString(byteData)}]\r\n");
#endif
                Sktconfig?.BeforeSend?.Invoke(byteData,this);//发送之前的操作
                var sendBytes = BitConverter.GetBytes(byteData.Length+6).Concat(byteData).ToArray().Concat(new byte[] {0x0D,0x0A}).ToArray();
                if (SocketConnectType == SocketConnectType.WebSocket)
                {
                    long byteLength = byteData.Length;
                    byte[] header;
                    if (byteLength < 126)
                    {
                        header = new byte[] { 0x82, 0x00 };
                        Array.Copy(BitConverter.GetBytes((byte)byteLength & 0x7F), 0, header, 1, 1);
                    }
                    else if (byteLength <= ushort.MaxValue)
                    {
                        header = new byte[] { 0x82, 0x7E, 0x00, 0x00 };
                        var shortLength = Convert.ToUInt16(byteLength);
                        var b1 = Convert.ToByte(shortLength / 256);
                        var b2 = Convert.ToByte(shortLength % 256);
                        Array.Copy(new [] { b1, b2 }, 0, header, 2, 2);
                    }
                    else
                    {
                        header = new byte[] { 0x82, 0x7F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                        Array.Copy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(byteLength)), 0, header, 2, 2);
                    }
                    sendBytes = header.Concat(byteData).ToArray();
                    sendBytes = new DataFrame(sendBytes).GetBytes();
                }
                ConnectSocket.BeginSend(sendBytes, 0, sendBytes.Length, 0, SendCallback, sendCallBack);
            }
            catch (SocketException sktex)
            {
                SocketException(ConnectSocket, sktex);
            }
            catch (Exception ex)
            {
                Exception(ex);
            }
        }

        /// <summary>
        /// 发送完毕的回调
        /// </summary>
        /// <param name="ar"></param>
        public virtual void SendCallback(IAsyncResult ar)
        {
            System.Net.Sockets.Socket handler = ConnectSocket;
            var sendCallBack = ar.AsyncState as Action<SocketConnection>;
            try
            {
                handler.EndSend(ar); //这里写发送完毕的逻辑
                sendCallBack?.Invoke(this);
            }
            catch (SocketException sktex)
            {
                SocketException(handler, sktex);
            }
            catch (Exception ex)
            {
                Exception(ex);
            }
        }
        #endregion

        #region ShowMsg | Log | Exception
        /// <summary>
        /// 所有记录的信息都可以显示出来
        /// </summary>
        /// <param name="content">显示内容</param>
        [Conditional("DEBUG")]
        public static void ShowMsg(string content)
        {
            Sktconfig?.ShowMsg?.Invoke(content);
        }

        /// <summary>
        /// 记录信息，记录的可以是消息、异常等信息
        /// </summary>
        /// <param name="localIpEndPoint">本地Ip端口</param>
        /// <param name="remoteIpEndPoint">远端Ip端口</param>
        /// <param name="content"></param>
        [Conditional("DEBUG")]
        protected static void LogMsg(string localIpEndPoint, string remoteIpEndPoint, string content)
        {
            ShowMsg(DateTime.Now.ToString("yy/MM/dd HH:mm:ss.fffffff") +" "+ content);
            //Log.LogModel(localIpEndPoint, remoteIpEndPoint, content);
        }
         
        /// <summary>
        /// socket异常处理
        /// </summary>
        /// <param name="handler">socket对象</param>
        /// <param name="ex">异常对象</param>
        protected static void SocketException(System.Net.Sockets.Socket handler, SocketException ex)
        {
            ShowMsg(ex.Message+"\r\n"+ex.StackTrace);
            Sktconfig?.SocketConnectExceptionCallback?.Invoke(ex);
            //Log.LogModel(handler.Connected
            //    ? new LogEntity<object>()
            //    {
            //        LogType = LogType.SocketException,
            //        LocalIpEndPoint = handler.LocalEndPoint.ToString(),
            //        RemoteIpEndPoint = handler.RemoteEndPoint.ToString(),
            //        LogContent = ex
            //    }
            //    : new LogEntity<object>()
            //    {
            //        LogType = LogType.SocketException,
            //        LocalIpEndPoint = handler.LocalEndPoint.ToString(),
            //        LogContent = ex
            //    });
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="ex">异常对象</param>
        protected static void Exception(Exception ex)
        {
            ShowMsg(ex.Message+"\r\n"+ex.StackTrace);
            //Log.LogModel(new LogEntity<object>() { LogType = LogType.Exception, LogContent = ex });
        }
        #endregion

    }
}
