using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPP_testThreads
{
    public class Tracer
    {
        private TraceResult traceResult;
        public ArrayList MethodList;
        //public ThreadInfo threadInfo;
        private ConcurrentDictionary<int, ThreadInfo> threadsDictionary;
        private Stopwatch timer;

        public Tracer()
        {
            //threadInfo = new ThreadInfo();
            MethodList = new ArrayList();
        }
        //короля 16

        public void StartTrace()
        {
            var methodName = new StackTrace().GetFrame(1).GetMethod();
            string className = methodName.ReflectedType.ToString();
            int traceId = Thread.CurrentThread.ManagedThreadId;

            if (!threadsDictionary.ContainsKey(traceId))
            {
                threadsDictionary.TryAdd(traceId, new ThreadInfo(traceId));
            }

            var value = threadsDictionary[traceId];
            value.methodInfo.Add(new MethodInfo(methodName.ToString(), className));
            timer = new Stopwatch();
            timer.Start();

        }        
        public void StopTrace()
        {
            timer.Stop();
            long fullTime = timer.ElapsedMilliseconds;

        }

        public TraceResult GetTraceResult()
        {
            return traceResult;
        }
    }


    public class TraceResult
    {
        
    }
}
