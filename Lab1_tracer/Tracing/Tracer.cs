using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics; 
using System.Threading;
using Interfaces;

namespace Tracing
{
    public class Tracer : ITracer
    {
        private TraceResult traceResult;
        private ConcurrentDictionary<int, ThreadInfo> threadsDictionary;
        private Stopwatch timer;
        private ConcurrentStack<MethodInfo> methodStack;

        public Tracer()
        {
            methodStack = new ConcurrentStack<MethodInfo>();
            threadsDictionary = new ConcurrentDictionary<int, ThreadInfo>();
        }

        public void StartTrace()
        {
            var methodName = new StackTrace().GetFrame(1).GetMethod();
            string className = methodName.ReflectedType.ToString();
            int traceId = Thread.CurrentThread.ManagedThreadId;
            MethodInfo info = new MethodInfo(methodName.Name, className);
            ThreadInfo threadInfo = new ThreadInfo(traceId);
            if (!threadsDictionary.ContainsKey(traceId))
            {
                threadsDictionary.TryAdd(traceId, threadInfo);
                threadsDictionary[traceId].methodInfo.Add(info);
            }
            else
            {
                MethodInfo value;
                methodStack.TryPeek(out value);
                value.methodInfo.Add(info);
            }

            methodStack.Push(info);
            timer = new Stopwatch();
            timer.Start();
        }

        public void StopTrace()
        {
            timer.Stop();
            long fullTime = timer.ElapsedMilliseconds;
            MethodInfo info;
            methodStack.TryPop(out info);
            info.time = fullTime;
            var value = threadsDictionary[Thread.CurrentThread.ManagedThreadId];
            value._time += fullTime;
        }


        public TraceResult GetTraceResult()
        { 
            List<ThreadInfo> result = new List<ThreadInfo>();
            foreach (KeyValuePair<int, ThreadInfo> keyValue in threadsDictionary)
            {
                result.Add(keyValue.Value);
            }
            return new TraceResult(threadsDictionary);
        }
    }
}
