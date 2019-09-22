using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Tracing
{
    [DataContract]
    public class MethodInfo
    {
        [DataMember]
        public string Name;
        [DataMember]
        public string ClassName;
        [DataMember]
        public long Time;
        [DataMember]
        public List<MethodInfo> methodInfo;

        public MethodInfo(string name, string className)
        {
            Name = name;
            ClassName = className;
            Time = 0;
            methodInfo = new List<MethodInfo>();
        }
    }
}
