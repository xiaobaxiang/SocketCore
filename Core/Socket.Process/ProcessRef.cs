using System;

namespace Socket.Reflect
{
    public class ProcessRef
    {
        public Type ProcessType { get; set; }
        public object RefObj { get; set; }
        public Type ArgType { get; set; }
    }
}