using Persistence.Dto;

namespace Persistence
{
    public interface IStreetLightPersistence:IClientRequest
    {
        /// <summary>
        /// 设置上报时间间隔
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        int UpdateSettingsTimeSpan(DtoSettingTimeSpan timeSpan);
    }
}