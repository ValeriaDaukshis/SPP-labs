using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            tracer.GetTraceResult();

            //var writer = new TWriter();
            //{
            //    var formatter = new TXmlSerializer();
            //    writer.WriteToConsole(formatter.Serialize(tracer.GetTraceResult()));
            //    writer.WriteToFile(formatter.Serialize(tracer.GetTraceResult()), "XmlTrace.XML");
            //}
            //{
            //    var formatter = new TJsonSerializer();
            //    writer.WriteToConsole(formatter.Serialize(tracer.GetTraceResult()));
            //    writer.WriteToFile(formatter.Serialize(tracer.GetTraceResult()), "JsonTrace.json");
            //}
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
