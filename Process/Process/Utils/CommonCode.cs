using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using com.igetui.api.openservice;
using com.igetui.api.openservice.igetui;
using com.igetui.api.openservice.igetui.template;
using Newtonsoft.Json;

namespace Process.Utils
{
    public class CommCode
    {
        public static string GetResponse<T>(string requestUrl, string requestMethod, T inPutModel)
        {
            string retString = null;
            //            var jssr = new JavaScriptSerializer();
            //            var postDataStr = jssr.Serialize(inPutModel);
            var postDataStr = typeof(T) == typeof(string) ? inPutModel as string :  JsonConvert.SerializeObject(inPutModel);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
            request.Method = requestMethod;
            request.ContentType = "application/json";
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            //request.Headers.Add("Token", "123");//这里可以添加自定义验证
            //Stream myRequestStream = request.GetRequestStream();
            //StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("utf-8"));
            //myStreamWriter.Write(postDataStr);
            //myStreamWriter.Close();
            byte[] byteArray = Encoding.UTF8.GetBytes(postDataStr);
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            if (myResponseStream != null)
            {
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                retString = myStreamReader.ReadToEnd();
                // ar retObj = new JavaScriptSerializer().Deserialize<AccountResultModel>(retString.Remove(retString.Length - 1, 1).Remove(0, 1).Replace("\\", ""));
                myStreamReader.Close();
            }
            myResponseStream?.Close();
            return retString;
        }

        public static string GetString(string url)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding=Encoding.UTF8;
                return wc.DownloadString(url);
            }
        }

        public static string AppSetting(string key)
        {
            AppSettingsReader asr = new AppSettingsReader();
            return (asr.GetValue(key, typeof(string)) ?? "").ToString();
        }

        public static string[] AppSettings(params string[] keys)
        {
            AppSettingsReader asr = new AppSettingsReader();
            if (keys == null) return new string[0];
            List<string> res = new List<string>();
            foreach (var k in keys)
            {
                try
                {
                    res.Add((asr.GetValue(k, typeof(string)) ?? "").ToString());
                }
                catch
                {
                    res.Add("");
                }
            }
            return res.ToArray();
        }

        public static string GeTuiMsg(string msgTitle, string msgBody, string appid, string appkey, string mastersecret,string clientId,DateTime? msgPostTime)
        {
            var HOST = "http://sdk.open.api.igexin.com/apiex.htm";

            var push = new IGtPush(HOST, appkey, mastersecret);
            // 定义"AppMessage"类型消息对象，设置消息内容模板、发送的目标App列表、是否支持离线发送、以及离线消息有效期(单位毫秒)
            var batch = new BatchImpl(appkey, push);
            //var message = new AppMessage();
            var message = new SingleMessage();
            //var template = NotificationTemplateDemo(msgTitle, msgBody, appid, appkey, msgPostTime);
            var template = TransmissionContent(msgTitle, msgBody, appid, appkey);
            message.IsOffline = true;                         // 用户当前不在线时，是否离线存储,可选
            message.OfflineExpireTime = 1000 * 3600 * 12;     // 离线有效时间，单位为毫秒，可选
            message.Data = template;
            message.PushNetWorkType = 0;

            var targetTrans = new Target
            {
                appId = appid,
                clientId = clientId
            };
            batch.add(message, targetTrans);
            try
            {
               return batch.submit();
            }
            catch
            {
                return batch.retry();
            }
        }
        //透传模板动作内容
        private static NotificationTemplate NotificationTemplateDemo(string msgTitle, string msgBody, string appid, string appkey,DateTime? msgPostTime)
        {
            var template = new NotificationTemplate
            {
                AppId = appid,
                AppKey = appkey,
                TransmissionType = "1",//应用启动类型，1：强制应用启动 2：等待应用启动
                Title = msgTitle, //传送标题
                Text = msgBody,//透传内容
                Logo = "can.png"
            };
            //TransmissionTemplate template = new TransmissionTemplate();

            //template.TransmissionContent = "{title:\""+ msgTitle + "\",content:\""+ msgBody + "\",payload:\"payload\"}";
            //设置通知定时展示时间，结束时间与开始时间相差需大于6分钟，消息推送后，客户端将在指定时间差内展示消息（误差6分钟）
            if (msgPostTime.HasValue)
            {
                template.setDuration(msgPostTime.Value.ToString("yyyy-MM-dd HH:mm:ss"), msgPostTime.Value.AddMinutes(10).ToString("yyyy-MM-dd HH:mm:ss"));
            }
            return template;
        }

        private static TransmissionTemplate TransmissionContent(string msgTitle, string msgBody,string appid, string appkey)
        {
            var template = new TransmissionTemplate
            {
                AppId = appid,
                AppKey = appkey,
                TransmissionType = "1",
                TransmissionContent = "{title:\"" + msgTitle + "\",content:\"" + msgBody + "\",payload:\"payload\"}"
            };
            return template;
        }


    }
}
