using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracing; 
using Newtonsoft.Json; 
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace Tracing 
{
    public class JSonSerializer
    {
        public string Serialize(List<ThreadInfo> list)
        {
             var serializer = new DataContractJsonSerializer(typeof(List<ThreadInfo>));
             
//            var serializer = new DataContractSerializer(typeof(TraceResult),new Type[]{ typeof(MethodInfo) , typeof(ThreadInfo)});
            FileStream fs = new FileStream("C:/Users/dauks/source/repos/SPP labs/threads.json", FileMode.OpenOrCreate);
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            //Console.WriteLine(json);
            // serializer.WriteObject(fs, list);  
            fs.Dispose();
            return json;
        }
    }
}
