using Google.Protobuf;
using Persistence;
using Persistence.Dto;
using Socket.Core;
using Socket.Reflect;
using SocketCmd;

namespace Process
{
    [CmdCode(0x0101)]
    public class DeviceRegister:IProcess<Register>
    {
        /// <summary>
        /// 处理设备注册
        /// </summary>
        /// <param name="registerInfo"></param>
        /// <param name="con"></param>
        /// <param name="db"></param>
        public void ProcessReqest(Register registerInfo, SocketConnection con, IClientRequest db)
        {
            var registerBk=new CmdHeader
            {
                CmdCode = 0xFF01,
                Identity = registerInfo.Identity,
                ServerId = SocketConnectionServerDispatcher.ServerId,
                //TimeToken = registerInfo.TimeToken
            };
            SocketConnection.ShowMsg(registerInfo.ToString());
            var registerDto = new DtoRegister
            {
                Iccid = registerInfo.Iccid,
                ImeiNo = registerInfo.Identity,
                ImeiType = registerInfo.ImeiType,
                ImeiVersion = registerInfo.ImeiVersion,
                RemoteIpEndPoint = con.ConnectSocket.RemoteEndPoint.ToString(),
                ServerIp = con.ConnectSocket.LocalEndPoint.ToString(),
                ServerOutIp = SocketConnectionServerDispatcher.ServerOutIpEndPort,
                Lng = registerInfo.Lng,
                Lat = registerInfo.Lat
            };
            registerBk.ResultCode = db.DeviceRegister(registerDto);
            con.Send(registerBk.ToByteArray());
            SocketConnection.ShowMsg(registerBk.ToString());
        }
    }
}