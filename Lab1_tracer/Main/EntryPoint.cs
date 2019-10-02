using System;
using System.Collections.Generic; 
using System.Linq;
using System.Threading;  
using Tracing;

namespace Main
{
    class EntryPoint
    {
        private static Tracer tracer;
        private static List<Thread> threads;

        static void Main(string[] args)
        {
            threads = new List<Thread>();
            tracer = new Tracer();
            CreateThreads();
            var list = tracer.GetTraceResult().ThreadsDictionary.Values.ToList();  
            new ConsoleWriter().WriteFile(new XmlSerializer(), list);
            new ConsoleWriter().WriteFile(new JSonSerializer(), list);
        }

        private static void CreateThreads()
        {
            for (int i = 0; i < 2; i++)
            {
                Thread thread = new Thread(TestMethod1);
                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }

        private static void TestMethod1()
        {
            tracer.StartTrace();
            Thread.Sleep(1000);
            TestMethod2();
            tracer.StopTrace();
        }

        private static void TestMethod2()
        {
            tracer.StartTrace();
            Thread.Sleep(200); 
            tracer.StopTrace();
        }
    }
}
