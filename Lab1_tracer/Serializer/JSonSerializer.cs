using System;
using System.Collections.Generic;
using System.IO;
using Tracing; 
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Serializer
{
    public class JSonSerializer : ISerializer
    {
        public string Serialize (List<ThreadInfo> value)
        {
            return JsonConvert.SerializeObject(value, Formatting.Indented);
        }
    }
    
    interface ISerializer
    {
        string Serialize(List<ThreadInfo> value);
    }
}
