using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Tracing.Interfaces;

namespace Tracing.Tracing
{
    public class Tracer : ITracer
    {
        private TraceResult _traceResult;
        private ConcurrentDictionary<int, List<MethodResult>> _methodStack;
        private IStopWatcher _timer;
        public Tracer(IStopWatcher timer)
        {
            _traceResult = new TraceResult();
            _methodStack = new ConcurrentDictionary<int, List<MethodResult>>();
            _timer = timer;
        }

        public void StartTrace()
        { 
            var methodName = new StackTrace().GetFrame(1).GetMethod();
            if (methodName.ReflectedType != null)
            {
                string className = methodName.ReflectedType.ToString();
                int traceId = Thread.CurrentThread.ManagedThreadId; 
                ThreadResult threadInfo = new ThreadResult(traceId);
                MethodResult info = new MethodResult(methodName.Name, className);
               
                if (!_traceResult.ThreadsDictionary.ContainsKey(traceId))
                {
                    _traceResult.ThreadsDictionary.TryAdd(traceId, threadInfo);
                    _traceResult.ThreadsDictionary[traceId].MethodInfo.Add(info);
                }
                else
                {
                    var value = _methodStack[traceId][0];
                    value.MethodInfo.Add(info);
                }

                if (!_methodStack.ContainsKey(traceId))
                {
                    _methodStack.TryAdd(traceId, new List<MethodResult>());
                    _methodStack[traceId].Add(info);
                }
                else
                {
                    _methodStack[traceId].Insert(0, info); 
                }
            } 
            _timer.StartTrace();
        }

        public void StopTrace()
        {
            _timer.StopTrace();
            long fullTime = _timer.GetTraceResult();
            
            int traceId = Thread.CurrentThread.ManagedThreadId; 
            var info = _methodStack[traceId][0];
            _methodStack[traceId].RemoveAt(0);
            info.Time = fullTime;
            var value = _traceResult.ThreadsDictionary[traceId];
            value.Time += fullTime;
        } 
        public TraceResult GetTraceResult()
        {
            return _traceResult;
        }
    }
}
