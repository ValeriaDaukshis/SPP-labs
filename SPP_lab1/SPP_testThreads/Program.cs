using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPP_testThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            //StackTrace trace = new StackTrace(1, true);
            A.method1();
            var a = new StackTrace().GetFrame(0).GetMethod();
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }

    static class A
    {
        public static void method1()
        {
            StackTrace trace = new StackTrace(1, true);
            int a = trace.FrameCount;
            for (int i = 0; i < a; i++)
                Console.WriteLine(trace.GetFrame(i).GetMethod().Name);
            method2();
        }

        public static void method2()
        {
            Console.WriteLine("******");
            StackTrace trace = new StackTrace(1, true);
            int a = trace.FrameCount;
            for (int i = 0; i < a; i++)
                Console.WriteLine(trace.GetFrame(i).GetMethod().Name);
            Console.WriteLine("******");
        }
    }

    
}
