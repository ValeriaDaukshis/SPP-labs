using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracing
{
    public class TraceResult
    {
        private ConcurrentDictionary<int, ThreadInfo> thread;
        public TraceResult(ConcurrentDictionary<int, ThreadInfo> threadsDictionary)
        {
            thread = threadsDictionary;
        }
    }
}
