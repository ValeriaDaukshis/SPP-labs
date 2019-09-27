using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace Tracer.Tests
{
    [TestFixture]
    public class TracerTests
    {
        [Test]
        public void Tracer_TestMethod1TimeLimit()
        {
            long expected = 201; 
            var testClass = new TestClass();
            testClass.InitializeTracer();
            var actual = testClass._tracer.GetTraceResult().ThreadsDictionary.Values.ToList()[0].MethodInfo[0].Time;
            Assert.IsTrue(actual <= expected);
        }
        
        [Test]
        public void Tracer_TestMethod2TimeLimit()
        {
            long expected = 101; 
            var testClass = new TestClass();
            testClass.InitializeTracer();
            var actual = testClass._tracer.GetTraceResult().ThreadsDictionary.Values.ToList()[0].MethodInfo[0].MethodInfo[0].Time;
            Assert.IsTrue(actual <= expected);
        }
        
        [Test]
        public void Tracer_TestMethod3TimeLimit()
        {
            long expected = 21; 
            var testClass = new TestClass();
            testClass.InitializeTracer();
            var actual = testClass._tracer.GetTraceResult().ThreadsDictionary.Values.ToList()[0].MethodInfo[0].MethodInfo[0].MethodInfo[0].Time;
            Assert.IsTrue(actual <= expected);
        } 
        
        [Test]
        public void Tracer_TestMethod1MethodName()
        {
            string expected = "Method1"; 
            var testClass = new TestClass();
            testClass.InitializeTracer();
            var actual = testClass._tracer.GetTraceResult().ThreadsDictionary.Values.ToList()[0].MethodInfo[0].Name;
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Tracer_TestMethod2MethodName()
        {
            string expected = "Method2"; 
            var testClass = new TestClass();
            testClass.InitializeTracer();
            var actual = testClass._tracer.GetTraceResult().ThreadsDictionary.Values.ToList()[0].MethodInfo[0].MethodInfo[0].Name;
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Tracer_TestMethod3ClassName()
        {
            string expected = "Method3"; 
            var testClass = new TestClass();
            testClass.InitializeTracer();
            var actual = testClass._tracer.GetTraceResult().ThreadsDictionary.Values.ToList()[0].MethodInfo[0].MethodInfo[0].MethodInfo[0].Name;
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Tracer_TestMethod1CountInnerMethods()
        {
            int expected = 2; 
            var testClass = new TestClass();
            testClass.InitializeTracer();
            var info = testClass._tracer.GetTraceResult().ThreadsDictionary.Values.ToList()[0].MethodInfo;
            int actual = 0;
            while (info[0].MethodInfo.Count > 0)
            {
                actual++;
                info = info[0].MethodInfo;
            }
            Assert.AreEqual(expected, actual);
        }
    }

    public class TestClass
    {
        public Tracing.Tracer _tracer;  
        public void InitializeTracer()
        {
            _tracer = new Tracing.Tracer(); 
            Method1();
        }
        
        private  void Method1()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            Method2();
            _tracer.StopTrace();
        } 
        private void Method2()
        {
            _tracer.StartTrace();
            Thread.Sleep(80);
            Method3();
            _tracer.StopTrace();
        }
        private void Method3()
        {
            _tracer.StartTrace();
            Thread.Sleep(20);
            _tracer.StopTrace();
        }
    }
    
}