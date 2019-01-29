
using Persistence.Dto;

namespace Persistence
{
    public interface IClientRequest
    {
        /// <summary>
        /// 处理硬件注册
        /// 判断当前Imei在数据库中是否存在，
        /// </summary>
        /// <param name="registerDto">注册实体</param>
        /// <returns>新增结果</returns>
        int DeviceRegister(DtoRegister registerDto);

        /// <summary>
        /// 处理硬件登录
        /// </summary>
        /// <param name="loginDto">登录实体</param>
        /// <returns>更新结果</returns>
        DtoDealRes DeviceLogin(DtoLogin loginDto);

        /// <summary>
        /// 硬件掉线记录，
        /// 可能存在重新注册链接的情况
        /// 这时候要根据imei号，判断当前socketIpEndPort还是不是数据库中存储的，如果不是，那就直接舍弃，如果是，那就更新状态Off
        /// </summary>
        /// <param name="offLineDto">掉线实体</param>
        /// <returns></returns>
        int DeviceOffLine(DtoOffLine offLineDto);

        /// <summary>
        /// 硬件上报状态
        /// </summary>
        /// <param name="statusDto">状态实体</param>
        /// <returns></returns>
        int DeviceStatusInfo(DtoStatusInfo statusDto);
        /// <summary>
        /// 报警消息
        /// </summary>
        /// <param name="waringDto">报警</param>
        /// <returns></returns>
        int AddWaringMessage(DtoWaring waringDto);
    }

}
