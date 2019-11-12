
using System.Collections.Generic; 
using System.Linq;
using System.Threading; 
using Tracing.Interfaces;
using Tracing.Serializer;
using Tracing.Tracing;

namespace Main
{
    static class EntryPoint
    {
        private static ITracer _tracer;
        private static List<Thread> _threads;

        static void Main(string[] args)
        {
            _threads = new List<Thread>();
            _tracer = new Tracer();
            CreateThreads();
            var list = _tracer.GetTraceResult().ThreadsDictionary.Values.ToList();  
            
            new ConsoleWriter().WriteFile(new XmlFileSerializer(), list);
            new ConsoleWriter().WriteFile(new JSonFileSerializer(), list);
        }

        private static void CreateThreads()
        {
            // создаем многопоточность. Количество потоков - 2
            for (int i = 0; i < 2; i++)
            {
                Thread thread = new Thread(TestMethod1);
                _threads.Add(thread);
                thread.Start();
            }

            // объединяем потоки в 1. Это в самом конце выполняется
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
