using System;
using System.Collections.Generic;
using Tracing.Interfaces;
using Tracing.Tracing;

namespace Main
{
    public class ConsoleWriter 
    {
        public void WriteFile(ISerializer serializer, List<TraceResult.ThreadResult> list)
        {
            Console.WriteLine(serializer.Serialize(list));
        }
    }
}