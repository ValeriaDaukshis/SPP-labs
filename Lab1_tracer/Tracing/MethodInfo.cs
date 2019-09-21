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
        public string Name; 
        public string ClassName; 
        public long time;
        public List<MethodInfo> methodInfo;

        public MethodInfo(string name, string className)
        {
            Name = name;
            ClassName = className;
            time = 0;
            methodInfo = new List<MethodInfo>();
        }
    }
}
