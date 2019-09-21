using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracing
{
    public class ThreadInfo
    {
        public readonly int _id;
        public long _time;
        public List<MethodInfo> methodInfo;

        public ThreadInfo(int id)
        {
            _id = id;
            _time = 0;
            methodInfo = new List<MethodInfo>();
        }
    }
}
