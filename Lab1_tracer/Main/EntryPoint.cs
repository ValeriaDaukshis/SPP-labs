using System;
using System.Collections.Generic;
using System.IO;
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
            GetMoreThreads();
            var result = tracer.GetTraceResult();
            List<ThreadInfo> list2 = tracer.GetTraceResult().GetResultList();

            string str = new JSonSerializer().Serialize(list2);
            Console.WriteLine(str); 
            
            Console.ReadKey();
        }

        static void GetMoreThreads()
        {
            for (int i = 0; i < 2; i++)
            {
                Thread thread = new Thread(TestMethod1);
                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread t in threads)
            {
                t.Join();
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
