using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;

namespace Tracing
{
    public class XmlSerializer
    { 
        public void Serialize(List<ThreadInfo> list)
        {
            var serializer = new DataContractSerializer(typeof(List<ThreadInfo>));
            XmlWriterSettings settings = new XmlWriterSettings() {Indent = true};
            using(XmlWriter writer = XmlWriter.Create("C:/Users/dauks/source/repos/SPP labs/threads.xml", settings))
            {
                serializer.WriteObject(writer, list); 
            } 
            
        }
    }
}