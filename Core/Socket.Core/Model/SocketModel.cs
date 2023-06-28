using System;
using System.Collections.Generic;
using System.Text;

namespace Socket.Core.Model
{
    #region SocketModel
    public class SocketConnectConfig
    {
        /// <summary>
        /// 心跳间隔
        /// </summary>
        public int? KeepAliveTime;
        
        /// <summary>
        /// 处理消息等显示
        /// </summary>
        public Action<string> ShowMsg;

        /// <summary>
        /// 服务端监听socket
        /// </summary>
        public System.Net.Sockets.Socket ServerSocket;

        /// <summary>
        /// 处理连接建立的回调server端
        /// </summary>
        public Action<SocketConnection> AcceptCallback;

        /// <summary>
        /// 处理连接成功使用cliet端
        /// </summary>
        public Action<SocketConnection> ConnectCallback;

        /// <summary>
        /// 处理断开连接后的回调,不能再调用发送的命令了
        /// </summary>
        public Action<SocketConnection> DisConnectCallback;

        /// <summary>
        /// 处理接收消息完毕的回调
        /// </summary>
        public Action<byte[], SocketConnection> ReceiveCallback;

        /// <summary>
        /// 处理发送完毕的回调
        /// </summary>
        public Action<SocketConnection> SendCallback;

        /// <summary>
        /// 处理发生socket异常
        /// </summary>
        public Action<Exception> SocketConnectExceptionCallback;

        /// <summary>
        /// 断开所有链接后的回调
        /// </summary>
        public Action DisposeCallback;

        /// <summary>
        /// 发送之前的处理
        /// </summary>
        public Action<byte[], SocketConnection> BeforeSend;
    }

    public class SocketReceiveBack
    {
        /// <summary>
        /// 客户端连接的buffer
        /// </summary>
        public byte[] Buffer;
        /// <summary>
        /// websocket断包缓存
        /// </summary>
        public List<byte> Buffers = new List<byte>();
        /// <summary>
        /// 处理接收byte后的回调
        /// </summary>
        public Action<byte[], SocketConnection> ReceiveCallback;
        //public Action<string command,string statusCode,string seq,SocketConnection socketconntction>
        //msgRecevieCallBack;
        /// <summary>
        /// 处理接收消息完毕的回调
        /// </summary>
        public Action<byte[], SocketConnection> MsgRecevieCallBack;
    }

    /// <summary>
    /// 区分每个链接的类型
    /// </summary>
    public enum SocketConnectType
    {
        /// <summary>
        /// 默认后台socket
        /// </summary>
        DeviceSocket,//ConsoleSocket
        /// <summary>
        /// 服务器端客户端
        /// </summary>
        ConsoleServerSocket,
        /// <summary>
        /// H5连接
        /// </summary>
        WebSocket//WebSocket
    }
    #endregion

    #region DataFrame
    public class DataFrame
    {
        DataFrameHeader _header;
        private byte[] _extend = new byte[0];
        private byte[] _mask = new byte[0];
        public byte[] Content { get; private set; } 
        public string Text
        {
            get
            {
                if (_header.OpCode != 1)
                    return string.Empty;

                return Encoding.UTF8.GetString(Content);
            }
        }

        private byte[] Mask(byte[] data, byte[] mask)
        {
            for (var i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(data[i] ^ mask[i % 4]);
            }

            return data;
        }

        public DataFrame(byte[] buffer)
        {
            //帧头
            _header = new DataFrameHeader(buffer);
            //扩展长度
            if (_header.Length == 126)
            {
                _extend = new byte[2];
                Buffer.BlockCopy(buffer, 2, _extend, 0, 2);
            }
            else if (_header.Length == 127)
            {
                _extend = new byte[8];
                Buffer.BlockCopy(buffer, 2, _extend, 0, 8);
            }

            //是否有掩码
            if (_header.HasMask)
            {
                _mask = new byte[4];
                Buffer.BlockCopy(buffer, _extend.Length + 2, _mask, 0, 4);
            }

            //消息体
            if (_extend.Length == 0)
            {
                Content = new byte[_header.Length];
                Buffer.BlockCopy(buffer, _extend.Length + _mask.Length + 2, Content, 0, Content.Length);
            }
            else if (_extend.Length == 2)
            {
                int contentLength = _extend[0] * 256 + _extend[1];
                Content = new byte[contentLength];
                Buffer.BlockCopy(buffer, _extend.Length + _mask.Length + 2, Content, 0, contentLength > 1024 * 100 ? 1024 * 100 : contentLength);
            }
            else
            {
                long len = 0;
                int n = 1;
                for (int i = 7; i >= 0; i--)
                {
                    len += _extend[i] * n;
                    n *= 256;
                }
                Content = new byte[len];
                Buffer.BlockCopy(buffer, _extend.Length + _mask.Length + 2, Content, 0, Content.Length);
            }

            if (_header.HasMask) Content = Mask(Content, _mask);

        }

        public DataFrame(string content)
        {
            Content = Encoding.UTF8.GetBytes(content);
            int length = Content.Length;

            if (length < 126)
            {
                _extend = new byte[0];
                _header = new DataFrameHeader(true, false, false, false, 1, false, length);
                // _header = new DataFrameHeader(true, false, false, false, frameType, false, length);//1 传输文本2 传输二进制
            }
            else if (length < 65536)
            {
                _extend = new byte[2];
                _header = new DataFrameHeader(true, false, false, false, 1, false, 126);
                //_header = new DataFrameHeader(true, false, false, false, frameType, false, 126);//1 传输文本2 传输二进制
                _extend[0] = (byte)(length / 256);
                _extend[1] = (byte)(length % 256);
            }
            else
            {
                _extend = new byte[8];
                _header = new DataFrameHeader(true, false, false, false, 1, false, 127);
                //_header = new DataFrameHeader(true, false, false, false, frameType, false, 127);//1 传输文本2 传输二进制

                int left = length;
                int unit = 256;

                for (int i = 7; i > 1; i--)
                {
                    _extend[i] = (byte)(left % unit);
                    left = left / unit;

                    if (left == 0)
                        break;
                }
            }
        }

        public byte[] GetBytes()
        {
            byte[] buffer = new byte[2 + _extend.Length + _mask.Length + Content.Length];
            Buffer.BlockCopy(_header.GetBytes(), 0, buffer, 0, 2);
            Buffer.BlockCopy(_extend, 0, buffer, 2, _extend.Length);
            Buffer.BlockCopy(_mask, 0, buffer, 2 + _extend.Length, _mask.Length);
            Buffer.BlockCopy(Content, 0, buffer, 2 + _extend.Length + _mask.Length, Content.Length);
            return buffer;
        }

    }

    public class DataFrameHeader
    {
        private bool _fin;
        private bool _rsv1;
        private bool _rsv2;
        private bool _rsv3;
        private sbyte _opcode;
        private bool _maskcode;
        private long _payloadlength;

        public bool Fin { get { return _fin; } }

        public bool Rsv1 { get { return _rsv1; } }

        public bool Rsv2 { get { return _rsv2; } }

        public bool Rsv3 { get { return _rsv3; } }

        public sbyte OpCode { get { return _opcode; } }

        public bool HasMask { get { return _maskcode; } }

        public long Length { get { return _payloadlength; } }

        public DataFrameHeader(byte[] buffer)
        {
            if (buffer.Length < 2)
                throw new Exception("无效的数据头.");

            //第一个字节
            _fin = (buffer[0] & 0x80) == 0x80;
            _rsv1 = (buffer[0] & 0x40) == 0x40;
            _rsv2 = (buffer[0] & 0x20) == 0x20;
            _rsv3 = (buffer[0] & 0x10) == 0x10;
            _opcode = (sbyte)(buffer[0] & 0x0f);

            //第二个字节
            _maskcode = (buffer[1] & 0x80) == 0x80;
            _payloadlength = (sbyte)(buffer[1] & 0x7f);
            //if (_payloadlength == 126)
            //{
            //    //_payloadlength = IPAddress.NetworkToHostOrder(BitConverter.ToUInt16(buffer.Skip(2).Take(2).ToArray(), 0));
            //    _payloadlength = buffer[2]*256 + buffer[3];// BitConverter.ToUInt16(buffer.Skip(2).Take(2).ToArray(), 0);
            //}
            //else if (_payloadlength == 127)
            //{
            //    _payloadlength = IPAddress.NetworkToHostOrder(BitConverter.ToUInt16(buffer.Skip(2).Take(8).ToArray(), 0));
            //    //_payloadlength = BitConverter.ToUInt16(buffer.Skip(2).Take(8).ToArray(), 0);
            //}
        }

        //发送封装数据t f f f 2 f
        public DataFrameHeader(bool fin, bool rsv1, bool rsv2, bool rsv3, sbyte opcode, bool hasmask, int length)
        {
            _fin = fin;
            _rsv1 = rsv1;
            _rsv2 = rsv2;
            _rsv3 = rsv3;
            _opcode = opcode;
            //第二个字节
            _maskcode = hasmask;
            _payloadlength = (sbyte)length;
        }

        //返回帧头字节
        public byte[] GetBytes()
        {
            byte[] buffer = { 0, 0 };

            if (_fin) buffer[0] ^= 0x80;
            if (_rsv1) buffer[0] ^= 0x40;
            if (_rsv2) buffer[0] ^= 0x20;
            if (_rsv3) buffer[0] ^= 0x10;

            buffer[0] ^= (byte)_opcode;

            if (_maskcode) buffer[1] ^= 0x80;

            buffer[1] ^= (byte)_payloadlength;

            return buffer;
        }
    }
    #endregion
    
}
