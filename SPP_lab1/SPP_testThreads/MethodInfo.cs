using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_testThreads
{
    class MethodInfo
    {
        private readonly string _name;
        private readonly string _className;
        internal int _time;
        internal List<MethodInfo> methodInfo;

        public MethodInfo(string name, string className)
        {
            _name = name;
            _className = className;
            _time = 0;
            methodInfo = new List<MethodInfo>(); 
        }
    }
}
