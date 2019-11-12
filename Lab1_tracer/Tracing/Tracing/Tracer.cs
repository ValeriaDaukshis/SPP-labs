using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Tracing.Interfaces;

namespace Tracing.Tracing
{
    public class Tracer : ITracer
    {
        private readonly TraceResult _traceResult;
        //словарь(ключ - значение), где ключ - trace id (идентификатор потока(смотреть в main класс entryPoint))
        // значение - стэк методов
        private readonly ConcurrentDictionary<int, Stack<TraceResult.MethodResult>> _methodStack;
        // класс для замера времени выполнения
        private readonly Stopwatch _timer;
        
        public Tracer()
        {
            _traceResult = new TraceResult();
            _methodStack = new ConcurrentDictionary<int, Stack<TraceResult.MethodResult>>();
            _timer = new Stopwatch();
        }

        public void StartTrace()
        { 
            var methodName = new StackTrace().GetFrame(1).GetMethod();
            if (methodName.ReflectedType != null)
            {
                string className = methodName.ReflectedType.ToString();
                int traceId = Thread.CurrentThread.ManagedThreadId; 
                TraceResult.ThreadResult threadInfo = new TraceResult.ThreadResult(traceId);
                TraceResult.MethodResult info = new TraceResult.MethodResult(methodName.Name, className);
               
                if (!_traceResult.ThreadsDictionary.ContainsKey(traceId))
                {
                    _traceResult.ThreadsDictionary.TryAdd(traceId, threadInfo);
                    _traceResult.ThreadsDictionary[traceId].MethodInfo.Add(info);
                }
                else
                {
                    var value = _methodStack[traceId].Peek();
                    value.MethodInfo.Add(info);
                }

                if (!_methodStack.ContainsKey(traceId))
                {
                    _methodStack.TryAdd(traceId, new Stack<TraceResult.MethodResult>());
                    _methodStack[traceId].Push(info);
                }
                else
                {
                    _methodStack[traceId].Push(info); 
                }
            } 
            _timer.Start();
        }

        public void StopTrace()
        {
            _timer.Stop();
            long fullTime = _timer.ElapsedMilliseconds;
            
            int traceId = Thread.CurrentThread.ManagedThreadId; 
            var info = _methodStack[traceId].Peek();
            info.Time = fullTime;
            _methodStack[traceId].Pop();
            var value = _traceResult.ThreadsDictionary[traceId];
            value.Time += fullTime;
        } 
        public TraceResult GetTraceResult()
        {
            return _traceResult;
        }
    }
}
