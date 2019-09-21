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
        public readonly int _id;
        [DataMember]
        public long _time;
        [DataMember]
        public List<MethodInfo> methodInfo;

        public ThreadInfo(int id)
        {
            _id = id;
            _time = 0;
            methodInfo = new List<MethodInfo>();
        }
    }
}
