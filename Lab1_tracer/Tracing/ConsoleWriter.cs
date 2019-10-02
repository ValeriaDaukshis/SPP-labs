using System;
using System.Collections.Generic;

namespace Tracing
{
    public class ConsoleWriter 
    {
        public void WriteFile(ISerializer serializer, List<ThreadResult> list)
        {
            Console.WriteLine(serializer.Serialize(list));
        }
    }
}