using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Google.Protobuf;
using Persistence;
using Persistence.Dto;
using Socket.Core;
using Socket.Core.Model;
using SocketCmd;

namespace Socket.Reflect
{
    /// <summary>
    /// 异步socket + ProtoBuffer格式传输数据
    /// </summary>
    public class SocketConnectionServerDispatcherRef<T> : SocketConnectionServerDispatcher where T:IClientRequest,new()
    {
        #region Static Member
        /// <summary>
        /// 存放反射出来的处理
        /// </summary>
        public static readonly Dictionary<uint, ProcessRef> ReflactProcesses = new Dictionary<uint, ProcessRef>();
        /// <summary>
        /// 持久化保持
        /// </summary>
        private static readonly IClientRequest ClientRequest = new T();
        #endregion

        #region Static Method
        /// <summary>
        /// 开启服务端socket监听
        /// </summary>
        public static void ServerSocketRefListing(Action<ISocketConnection> acceptCallback = null, Action<ISocketConnection> disConnectCallback = null
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
            ServerSocketRefListing(sktconfig);
        }

        /// <summary>
        /// 开启服务端socket监听
        /// </summary>
        public static void ServerSocketRefListing(SocketConnectConfig sktconfig)
        {
            var pfiles=Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*Process.dll");
            foreach (var fileName in pfiles)
            {
                var assembly = Assembly.LoadFile(fileName);
                var types = assembly.GetTypes().Where(e => e.GetInterfaces().Any(e1 =>e1.Namespace != null && e1.Namespace.Equals("Socket.Reflect") && e1.Name.Equals("IProcess`1")));//IProcess`1
                foreach (var type in types)
                {
                    type.GetCustomAttributes().ToList().ForEach(e =>
                    {
                        var code = e as CmdCodeAttribute;
                        if (code != null&& type.GetInterfaces().Length>0)
                        {
                            ReflactProcesses.Add(code.CmdCode, new ProcessRef() { ProcessType = type, RefObj = Activator.CreateInstance(type), ArgType = type.GetInterfaces()[0].GetGenericArguments()[0] });
                        }
                    });
                }
            }
            var sktconfig2 = new SocketConnectConfig
            {
                AcceptCallback = sktconfig.AcceptCallback,
                BeforeSend = sktconfig.BeforeSend,
                ConnectCallback = sktconfig.ConnectCallback,
                DisConnectCallback = (con) =>
                {
                    sktconfig.DisConnectCallback(con);
                    if (con.SocketConnectType == SocketConnectType.DeviceSocket)
                    {
                        //var appconfig = CommCode.AppSettings("gettuiappid", "gettuiappkey", "gettuimasterkey");
                        //if (con.StateData.BoundList == null) return;
                        //foreach (var usrClient in con.StateData.BoundList)
                        //{
                        //    CommCode.GeTuiMsg("设备通知", "设备" + con.Identity + "离线", appconfig[0], appconfig[1], appconfig[2], usrClient.ClientId, null);
                        //}
                        ClientRequest.DeviceOffLine(new DtoOffLine
                        {
                            ImeiNo = con.Identity,
                            RemoteIpEndPoint = con.ConnectSocket.RemoteEndPoint.ToString(),
                            ServerIp = con.ConnectSocket.LocalEndPoint.ToString()
                        });
                    }
                },
                DisposeCallback = sktconfig.DisposeCallback,
                KeepAliveTime = sktconfig.KeepAliveTime,
                SendCallback = sktconfig.SendCallback,
                ShowMsg = sktconfig.ShowMsg,
                ReceiveCallback = (bytes, con) =>
                {
                    sktconfig.ReceiveCallback?.Invoke(bytes, con); //先执行外面注册展示层的方法

                    var header = CmdHeader.Parser.ParseFrom(bytes);
                    if (string.IsNullOrWhiteSpace(header.Identity)) return;
                    #region 反射执行Process
                    SocketConnection oppSocketConnection;
                    if (ReflactProcesses.Keys.Contains(header.CmdCode))
                    {
                        var objProcess = ReflactProcesses[header.CmdCode];
                        var param = objProcess.ArgType.Name.Equals("CmdHeader")
                            ? header
                            : objProcess?.ArgType.GetProperty("Parser")?
                                .PropertyType.GetMethod("ParseFrom", new[] {typeof(byte[])})?
                                .Invoke(objProcess.ArgType.GetProperty("Parser")?.GetValue(objProcess.RefObj),
                                    new object[] {bytes});
                        if (param == null) return;
                        try
                        {
                            objProcess?.ProcessType.InvokeMember("ProcessReqest",
                                BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Instance, null,
                                objProcess.RefObj, new[] { param, con, ClientRequest });
                        }
                        catch (Exception ex)
                        {
                            ShowMsg($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fffffff} 调用发生异常{(ex.InnerException != null ? ex.InnerException.StackTrace : ex.StackTrace)}");
                        }
                    }
                    else if (string.IsNullOrWhiteSpace(header.OppositeId)) //没有操作对象，不需要上位机处理
                    {
                        var msgBk = new CmdHeader
                        {
                            CmdCode = header.CmdCode,
                            Identity = header.Identity,
                            ResultCode = 1,
                            ServerId = ServerId,
                            //TimeToken = header.TimeToken
                        };
                        con.Send(msgBk.ToByteArray());
                    }
                    else if (DicSockectConnection.TryGetValue(header.OppositeId,
                        out oppSocketConnection))
                    {
                        ShowMsg($"{DateTime.Now:yyyy/MM/dd HH:mm:ss.fffffff} 透传控制查询：{header.OppositeId}");
                        oppSocketConnection.Send(bytes);
                    }
                    else //设备离线
                    {
                        var msgBk = new CmdHeader
                        {
                            CmdCode = header.CmdCode,
                            Identity = header.Identity,
                            OppositeId = header.OppositeId,
                            ResultCode = 3, //离线
                            ServerId = ServerId,
                            //TimeToken = header.TimeToken
                        };
                        con.Send(msgBk.ToByteArray());
                        if (con.SocketConnectType == SocketConnectType.DeviceSocket)
                        {
                            ClientRequest.DeviceOffLine(new DtoOffLine
                            {
                                ImeiNo = header.OppositeId,
                                RemoteIpEndPoint = "",
                                ServerIp = ""
                            });
                        }
                    }

                    #endregion
                }
            };
            ServerSocketListing(sktconfig2);
        }
        #endregion

        #region construct
        private SocketConnectionServerDispatcherRef(System.Net.Sockets.Socket connect):base(connect)
        {
        }
        #endregion
    }

}
