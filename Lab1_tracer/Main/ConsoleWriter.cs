using System;
using System.Collections.Generic;
using Tracing;
using Tracing.Interfaces;
using Tracing.Tracing;

namespace Main
{
    public class ConsoleWriter 
    {
        public void WriteFile(ISerializer serializer, List<ThreadResult> list)
        {
            Console.WriteLine(serializer.Serialize(list));
        }
    }
}