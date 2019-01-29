using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Dto
{
    public class DtoDealRes
    {
        public int Res;
        public List<UsrClient> UsrClients=new List<UsrClient>();
        public List<CellLight> Lights=new List<CellLight>();
    }
    public class UsrClient
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        public string LoginNo { get; set; }
        /// <summary>
        /// 客户端标识
        /// </summary>
        public string ClientId { get; set; }
    }

    public class CellLight
    {
        public int CellAddr { get; set; }
        public string LightNo { get; set; }
    }
}
