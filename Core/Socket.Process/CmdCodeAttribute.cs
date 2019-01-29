using System;

namespace Socket.Reflect
{
    /// <summary>
    /// 设置命令头
    /// </summary>
    [AttributeUsage(AttributeTargets.Class,Inherited = false,AllowMultiple = true)]
    public class CmdCodeAttribute:Attribute
    {
        private uint _cmdCode;

        public uint CmdCode
        {
            get { return _cmdCode; }
            set { _cmdCode = value; }
        }
        public CmdCodeAttribute(uint cmd)
        {
            _cmdCode = cmd;
        }
    }
}