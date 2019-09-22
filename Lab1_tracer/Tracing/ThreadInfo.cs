using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tracing
{
    [DataContract, KnownType(typeof(MethodInfo))]
    public class ThreadInfo
    {
        [DataMember]
        public readonly int Id;
        [DataMember]
        public long Time;
        [DataMember]
        public List<MethodInfo> MethodInfo;

        public ThreadInfo(int id)
        {
            Id = id;
            Time = 0;
            MethodInfo = new List<MethodInfo>();
        }
    }
}
