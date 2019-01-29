namespace Persistence.Dto
{
    public class DtoRegister
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
        /// <summary>
        /// 上位机对外端口地址
        /// </summary>
        public string ServerOutIp { get; set; }
        /// <summary>
        /// 设备类型
        /// </summary>
        public string ImeiType { get; set; }
        /// <summary>
        /// 设备版本号
        /// </summary>
        public string ImeiVersion { get; set; }
        /// <summary>
        /// 4G卡标识
        /// </summary>
        public string Iccid { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double? Lng { get; set; }
        /// <summary>
        /// 维度
        /// </summary>
        public double? Lat { get; set; }
    }
}