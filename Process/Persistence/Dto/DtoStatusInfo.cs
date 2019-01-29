using System.Collections.Generic;

namespace Persistence.Dto
{
    public class DtoStatusInfo
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public string ImeiNo { get; set; }
        //public List<DtoLightStatus> LightStatus=new List<DtoLightStatus>();

        public DtoLightStatus LightStatus { get; set; }
    }

    public class DtoLightStatus
    {
        /// <summary>
        /// 灯编号
        /// </summary>
        public uint CellAddr { get; set; }
        ///// <summary>
        ///// 灯编号
        ///// </summary>
        //public string lightNo { get; set; }
        /// <summary>
        /// 灯状态
        /// </summary>
        public string lightstatus { get; set; }
        /// <summary>
        /// 功率
        /// </summary>
        public int? lightPw { get; set; }
        /// <summary>
        /// 光伏电压
        /// </summary>
        public int? lightLu { get; set; }
        /// <summary>
        /// 光伏电流
        /// </summary>
        public int? lightLi { get; set; }
        /// <summary>
        /// 电池电压
        /// </summary>
        public int? lightBu { get; set; }
        /// <summary>
        /// 电池温度
        /// </summary>
        public int? lightBt { get; set; }
        /// <summary>
        /// 负载电压
        /// </summary>
        public int? lightUu { get; set; }
        /// <summary>
        /// 负载电流
        /// </summary>
        public int? lightUi { get; set; }
        /// <summary>
        /// 电池组电影
        /// </summary>
        public string lightBgu { get; set; }
    }
}