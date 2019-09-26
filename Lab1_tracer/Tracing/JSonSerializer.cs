using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json; 
using Formatting = Newtonsoft.Json.Formatting;

namespace Tracing 
{
    public class JSonSerializer
    {
        public string Serialize(List<ThreadResult> list)
        {
            string jsonInfo;
            using(new FileStream("threads.json", FileMode.OpenOrCreate))
            { 
                jsonInfo = JsonConvert.SerializeObject(list, Formatting.Indented);
            } 
            return jsonInfo;
        }
    }
}
