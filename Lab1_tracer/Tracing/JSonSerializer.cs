using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json; 
using Formatting = Newtonsoft.Json.Formatting;

namespace Tracing 
{
    public class JSonSerializer : ISerializer
    {
        public string Serialize(List<ThreadResult> list)
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
