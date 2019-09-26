using System.Collections.Generic;
using System.IO;
using System.Xml;
using Tracing;

namespace Serialize
{
    public class JSonSerializer
    {
        public string Serialize(List<ThreadResult> list)
        {
            //var serializer = new DataContractJsonSerializer(typeof(List<ThreadResult>));
            string jsonInfo;
            using(FileStream fs = new FileStream("C:/Users/dauks/source/repos/SPP labs/threads.json", FileMode.OpenOrCreate))
            { 
                jsonInfo = JsonConvert.SerializeObject(list, Formatting.Indented);
            } 
            return jsonInfo;
        }
    }
}