
using System.Collections.Generic; 
using System.Linq;
using System.Threading;  
using Tracing;
using Tracing.Serializer;
using Tracing.TimeCounters;
using Tracing.Tracing;

namespace Main
{
    static class EntryPoint
    {
        private static Tracer _tracer;
        private static List<Thread> _threads;

        static void Main(string[] args)
        {
            _threads = new List<Thread>();
            _tracer = new Tracer(new StopWatcher());
            CreateThreads();
            var list = _tracer.GetTraceResult().ThreadsDictionary.Values.ToList();  
            new ConsoleWriter().WriteFile(new XmlSerializer(), list);
            new ConsoleWriter().WriteFile(new JSonSerializer(), list);
        }

        private static void CreateThreads()
        {
            for (int i = 0; i < 2; i++)
            {
                Thread thread = new Thread(TestMethod1);
                _threads.Add(thread);
                thread.Start();
            }

            foreach (Thread thread in _threads)
            {
                thread.Join();
            }
        }

        private static void TestMethod1()
        {
            _tracer.StartTrace();
            Thread.Sleep(1000);
            TestMethod2();
            _tracer.StopTrace();
        }

        private static void TestMethod2()
        {
            _tracer.StartTrace();
            Thread.Sleep(200); 
            _tracer.StopTrace();
        }
    }
}
