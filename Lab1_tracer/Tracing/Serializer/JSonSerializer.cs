using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Tracing.Interfaces;
using Tracing.Tracing;
using Formatting = Newtonsoft.Json.Formatting;

namespace Tracing.Serializer 
{
    public class JSonSerializer : ISerializer
    {
        public string Serialize(List<TraceResult.ThreadResult> list)
        {
            string jsonInfo;
            string outputFileName = "threads.json";
            using(new FileStream(outputFileName, FileMode.OpenOrCreate))
            { 
                jsonInfo = JsonConvert.SerializeObject(list, Formatting.Indented);
            } 
            return jsonInfo;
        }
    }
}
