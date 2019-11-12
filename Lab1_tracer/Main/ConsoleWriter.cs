using System;
using System.Collections.Generic;
using Tracing.Interfaces;
using Tracing.Tracing;

namespace Main
{
    public class ConsoleWriter 
    {
        public void WriteFile(IFileSerializer fileSerializer, List<TraceResult.ThreadResult> list)
        {
            Console.WriteLine(fileSerializer.Serialize(list));
        }
    }
}