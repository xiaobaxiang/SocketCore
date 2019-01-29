using System;
using Google.Protobuf;
using Persistence;
using Persistence.Dto;
using Socket.Core;
using Socket.Core.Model;
using Socket.Reflect;
using SocketCmd;

namespace Process
{
    [CmdCode(0x0102)]
    public class DeviceLogin:IProcess<CmdHeader>
    {
        /// <summary>
        /// 处理设备登录
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="con"></param>
        /// <param name="db"></param>
        public void ProcessReqest(CmdHeader loginInfo, SocketConnection con, IClientRequest db)
        {
            con.Identity = loginInfo.Identity;
            con.SocketConnectType=SocketConnectType.DeviceSocket;
            SocketConnectionServerDispatcher.DicSockectConnection.AddOrUpdate(loginInfo.Identity, con, (key, old) => con);
            var loginDto = new DtoLogin
            {
                ImeiNo = loginInfo.Identity,
                RemoteIpEndPoint = con.ConnectSocket.RemoteEndPoint.ToString(),
                ServerIp = con.ConnectSocket.LocalEndPoint.ToString(),
                ServerOutIp = SocketConnectionServerDispatcher.ServerOutIpEndPort
            };
            var res = db.DeviceLogin(loginDto);
            //con.StateData.BoundList = res.UsrClients;
            var loginBk = new LoginBk
            {
                CmdCode = 0xFF02,
                Identity = loginInfo.Identity,
                ServerId = SocketConnectionServerDispatcher.ServerId,
                TimeToken = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                ResultCode = res.Res
            };
            //TODO 根据链接的多个服务器返回新的上位机地址
            con.Send(loginBk.ToByteArray());
            SocketConnection.ShowMsg(loginBk.ToString());
            //var appconfig = CommCode.AppSettings("gettuiappid", "gettuiappkey", "gettuimasterkey");
            //if (con.StateData.BoundList == null) return;
            //foreach (var usrClient in con.StateData.BoundList)
            //{
            //    CommCode.GeTuiMsg("设备通知", "设备" + con.Identity + "上线", appconfig[0], appconfig[1], appconfig[2], usrClient.ClientId, null);
            //}
        }
    }
}