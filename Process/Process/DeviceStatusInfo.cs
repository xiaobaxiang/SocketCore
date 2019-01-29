using System.Collections.Generic;
using Google.Protobuf;
using Newtonsoft.Json;
using Persistence;
using Persistence.Dto;
using Socket.Core;
using Socket.Reflect;
using SocketCmd;

namespace Process
{
    [CmdCode(0x0103)]
    public class DeviceStatusInfo:IProcess<DeviceStatus>
    {
        /// <summary>
        /// 处理设备上报状态
        /// </summary>
        /// <param name="statusInfo"></param>
        /// <param name="con"></param>
        /// <param name="db"></param>
        public void ProcessReqest(DeviceStatus statusInfo, SocketConnection con, IClientRequest db)
        {
            if (!string.IsNullOrWhiteSpace(statusInfo.OppositeId))
            {//立即返回当前设备状态
                SocketConnection client;
                if(SocketConnectionServerDispatcher.DicSockectConnection.TryGetValue(statusInfo.OppositeId,out client)&&client.ConnectSocket.Connected)
                    client.Send(statusInfo.ToByteArray());
            }
            var statusBk = new CmdHeader
            {
                CmdCode = 0xFF03,
                Identity = con.Identity,
                ServerId = SocketConnectionServerDispatcher.ServerId,
                //TimeToken = statusInfo.TimeToken,
            };
            if (statusInfo.LightStatus == null)
            {
                statusBk.ResultCode = 0;
                con.Send(statusBk.ToByteArray());
                return;
            }
            var deviceStatus = new DtoStatusInfo
            {
                ImeiNo = statusInfo.Identity,
                LightStatus =new DtoLightStatus()
                    {
                        lightstatus = statusInfo.LightStatus.Status,
                        CellAddr = statusInfo.LightStatus.CellAddr,
                        lightBt = statusInfo.LightStatus.LightBt,
                        lightBu = statusInfo.LightStatus.LightBu,
                        lightLi = statusInfo.LightStatus.LightLi,
                        lightLu = statusInfo.LightStatus.LightLu,
                        lightPw = statusInfo.LightStatus.LightPw,
                        lightUi = statusInfo.LightStatus.LightUi,
                        lightUu = statusInfo.LightStatus.LightUu,
                        lightBgu = JsonConvert.SerializeObject(statusInfo.LightStatus.LightBgus)
                    } 
                };
            //foreach (var l in statusInfo.LightStatus)
            //{
            //    deviceStatus.LightStatus.Add(new DtoLightStatus
            //    {
            //        lightstatus = l.Status,
            //        CellAddr = l.CellAddr,
            //        //lightNo = l.LightNo,
            //        lightBt = l.LightBt,
            //        lightBu = l.LightBu,
            //        lightLi = l.LightLi,
            //        lightLu = l.LightLu,
            //        lightPw = l.LightPw,
            //        lightUi = l.LightUi,
            //        lightUu = l.LightUu,
            //        lightBgu = JsonConvert.SerializeObject(l.LightBgus)
            //    });
            //}

            statusBk.ResultCode = db.DeviceStatusInfo(deviceStatus);
            con.Send(statusBk.ToByteArray());
            SocketConnection.ShowMsg(statusInfo.ToString());
        }
    }
}