using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tracing
{
    
    public class TraceResult
    {
        public ConcurrentDictionary<int, ThreadInfo> thread;
        
        public List<ThreadInfo> result;
        public TraceResult(ConcurrentDictionary<int, ThreadInfo> threadsDictionary)
        {
            thread = threadsDictionary;
            result = new List<ThreadInfo>();
            //GetResultList();
        }

        public List<ThreadInfo> GetResultList()
        { 
            foreach (KeyValuePair<int, ThreadInfo> keyValue in thread)
            {
                result.Add(keyValue.Value);
            }

            return result;
        }
    }
}
