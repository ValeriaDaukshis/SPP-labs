using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics; 
using System.Threading;
using Interfaces;

namespace Tracing
{
    public class Tracer 
    {
        //private TraceResult traceResult;
        public ConcurrentDictionary<int, ThreadInfo> threadsDictionary { get; }
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
            TraceResult result = new TraceResult(threadsDictionary);
            return result;
        }
    }
}
