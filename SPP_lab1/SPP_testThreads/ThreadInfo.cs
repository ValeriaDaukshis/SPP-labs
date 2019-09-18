using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_testThreads
{
    public class ThreadInfo
    {
        private readonly int _id;
        internal long _time;
        internal List<MethodInfo> methodInfo;
        

        public ThreadInfo(int id)
        {
            _id = id;
            _time = 0;
            methodInfo = new List<MethodInfo>(); 
        }
    }
}
