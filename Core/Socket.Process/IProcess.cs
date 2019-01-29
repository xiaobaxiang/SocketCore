using Persistence;
using Socket.Core;

namespace Socket.Reflect
{
    /// <summary>
    /// 逆变泛型，通过反射取得需要的实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IProcess<in T>
    {
        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="statusInfo">通讯契约</param>
        /// <param name="con">当前连接对象</param>
        /// <param name="db">数据库对象</param>
        void ProcessReqest(T statusInfo, SocketConnection con, IClientRequest db);
    }
}