using System;
using Google.Protobuf;
using Persistence;
using Socket.Core;
using Socket.Reflect;
using SocketCmd;

namespace Process
{
    [CmdCode(0x0202)]
    public class UserLogin:IProcess<ClientLogin>
    {
        /// <summary>
        /// 处理用户单点登录
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <param name="con"></param>
        /// <param name="db"></param>
        public void ProcessReqest(ClientLogin clientInfo, SocketConnection con, IClientRequest db)
        {
            con.Identity = clientInfo.Identity;
            con.PhoneMac = clientInfo.PhoneMac;
            SocketConnection oldSocket;
            var loginBk = new LoginBk
            {
                CmdCode = 0xFF02,
                Identity = clientInfo.Identity,
                ServerId = SocketConnectionServerDispatcher.ServerId,
                //TimeToken = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                ResultCode = 1
            };
            con.Send(loginBk.ToByteArray());
            if (SocketConnectionServerDispatcher.DicSockectConnection.TryGetValue(clientInfo.Identity,
    out oldSocket) && !oldSocket.PhoneMac.Equals(con.PhoneMac))
            {
                loginBk.ResultCode = 4;
                oldSocket.Send(loginBk.ToByteArray()); //返回处理结果
            }
            SocketConnectionServerDispatcher.DicSockectConnection.AddOrUpdate(clientInfo.Identity, con, (key, old) => con);
            SocketConnection.ShowMsg(clientInfo.ToString());
        }
    }
}