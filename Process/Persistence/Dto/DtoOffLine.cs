namespace Persistence.Dto
{
    public class DtoOffLine
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public string ImeiNo { get; set; }
        /// <summary>
        /// 设备ip端口号
        /// </summary>
        public string RemoteIpEndPoint { get; set; }
        /// <summary>
        /// 上位机内网端口地址
        /// </summary>
        public string ServerIp { get; set; }
    }
}