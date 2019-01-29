using System;
using Google.Protobuf;
using Newtonsoft.Json;
using Persistence;
using Persistence.Dto;
using Process.Utils;
using Socket.Core;
using Socket.Reflect;
using SocketCmd;

namespace Process
{
    [CmdCode(0x010F)]
    public class DeviceWaring:IProcess<Waring>
    {
        private readonly string _gettuiappid = CommCode.AppSetting("gettuiappid");
        private readonly string _gettuiappkey = CommCode.AppSetting("gettuiappkey");
        private readonly string _gettuimasterkey = CommCode.AppSetting("gettuimasterkey");
        public void ProcessReqest(Waring waringInfo, SocketConnection con, IClientRequest db)
        {
            var fbdb = db as StreetLightPersistence;
            if (fbdb == null) return;
            var comBk = new CmdHeader
            {
                CmdCode = 0xFF0F,
                Identity = waringInfo.Identity,
                ResultCode = fbdb.AddWaringMessage(new DtoWaring
                {
                    ImeiNo = waringInfo.Identity,
                    ImeiLightNo = waringInfo.LightNo,
                    WaringCode = waringInfo.WaringCode,
                    WaringMessage = waringInfo.WaringDesc,
                    ImeiWaringMsgContent = JsonConvert.SerializeObject(waringInfo)
                }),
                ServerId = SocketConnectionServerDispatcher.ServerId,
                //TimeToken = waringInfo.TimeToken
            };
            con.Send(comBk.ToByteArray());
            switch (waringInfo.WaringCode)
            {
                case "0001"://设置门未开报警
                    break;
            }
            SocketConnection.ShowMsg(waringInfo.ToString());
            //if (con.StateData?.BoundList == null) return;
            //foreach (var usr in con.StateData.BoundList)
            //{
            //    //if (string.IsNullOrWhiteSpace(usr.ClientId) || usr.ClientId.Equals("null")) continue;
            //    //var res = CommCode.GeTuiMsg("设备报警", $"设备{waringInfo.Identity}发生警报,{waringInfo.WaringDesc}", _gettuiappid, _gettuiappkey, _gettuimasterkey, usr.ClientId, null);
            //    //SocketConnection.ShowMsg(res);
            //    #region 直接发送异常信息
            //    //SocketConnection clientSkt;
            //    //if (SocketConnectionServerDispatcher.DicSockectConnection.TryGetValue(usr, out clientSkt) && clientSkt.ConnectSocket.Connected)
            //    //{
            //    //    var waringBk = new WaringBkPb
            //    //    {
            //    //        CmdCode = "FF06",
            //    //        Identity = usr,
            //    //        OppositeId = con.Identity,
            //    //        ResultCode = dealRes.res,
            //    //        ServerId = SocketConnectionServerDispatcher.ServerId,
            //    //        TimeToken = waringInfo.TimeToken,
            //    //        WaringCode = waringInfo.WaringCode,
            //    //        WaringDesc = waringInfo.WaringDesc
            //    //    };
            //    //    clientSkt.Send(waringBk.ToByteArray());
            //    //}
            //    #endregion
            //}
        }
        
        private string SendUnlockDoorTemplateMsg(string token,string openId, string imei, string waringDesc)
        {
            string requestUrl = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + token;
            //发送模板消息
            TemplateMsg tmg = new TemplateMsg
            {
                touser = openId,
                template_id = "SxyiblJwBw8cZedVHyopLMP1B10RprgY2hJKqlVu9s8",
                data = new PreOrderTemMsg
                {
                    first = new PreOrderEle { value = "您好,"+ waringDesc },
                    keyword1 = new PreOrderEle { value = imei },
                    keyword2 = new PreOrderEle { value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                    remark = new PreOrderEle { value = "请尽快处理！感谢您的使用,如有疑问,请致电" + CommCode.AppSetting("platTel") + "联系我们" }
                }
            };
            var res = CommCode.GetResponse(requestUrl, "POST", tmg);
            return res;
        }
    }

    #region Model
    public class TemplateMsg
    {
        public string touser;
        public string template_id = "";
        public string url = "#";
        public string color = "#FF0000";
        public IData data;
        public TemplateMsg()
        {

        }
        //public TemplateMsg(string touser, string User, string Date, string CardNumber, string Type, string Money, string DeadTime, string Left)
        //{
        //    this.touser = touser;
        //    data = new TemplatData(User, Date, CardNumber, Type, Money, DeadTime, Left);
        //}
    }
    public interface IData { }

    public class PreOrderTemMsg : IData
    {
        public PreOrderEle first { get; set; }
        public PreOrderEle keyword1 { get; set; }
        public PreOrderEle keyword2 { get; set; }
        public PreOrderEle keyword3 { get; set; }
        public PreOrderEle keyword4 { get; set; }
        public PreOrderEle keyword5 { get; set; }
        public PreOrderEle remark { get; set; }
    }

    public class PreOrderEle
    {
        public string value;
        public string color = "#173177";
    }

    public class AccessToken
    {
        public string token { get; set; }
    }
    #endregion
}