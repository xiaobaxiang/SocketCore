using System;

namespace Socket.Core
{
    public interface ISocketConnection
    {
        #region construct dispose
        /// <summary>
        /// 断开socket连接
        /// </summary>
        /// <param name="disConnectCallback">断开连接后的回调</param>
        void Disconnect(Action<string> disConnectCallback = null);
        #endregion

        #region Receive
        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="receiveCallback">接收到数据后的上层处理</param>
        void ReceiveData(Action<byte[], SocketConnection> receiveCallback = null);

        /// <summary>
        /// 接收消息后的回调
        /// </summary>
        /// <param name="ar">接收消息后的回调异步对象</param>
        void ReceiveCallback(IAsyncResult ar);
        #endregion

        #region Send
        ///// <summary>
        ///// 发送字符串
        ///// </summary>
        ///// <param name="cmdBytes">帧类型</param>
        ///// <param name="identity">标识</param>
        ///// <param name="objId">操作对象</param>
        ///// <param name="msg">命令参数</param>
        ///// <param name="timetoken">时间戳</param>
        ///// <param name="sendCallBack">发送数据后的上层回调</param>
        //void Send(byte[] cmdBytes,string identity, byte[] objId, byte[] msg,long timetoken, Action<SocketConnection> sendCallBack = null);

        /// <summary>
        /// 发送字节数组
        /// </summary>
        /// <param name="byteData">发送字节</param>
        /// <param name="sendCallBack">发送数据后的上层回调</param>
        void Send(byte[] byteData, Action<SocketConnection> sendCallBack = null);

        /// <summary>
        /// 发送消息后的回调
        /// </summary>
        /// <param name="ar">发送成功后的回调异步对象</param>
        void SendCallback(IAsyncResult ar);
        #endregion
    }
}
