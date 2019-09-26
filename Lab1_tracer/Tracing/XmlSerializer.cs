using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;

namespace Tracing
{
    public class XmlSerializer
    { 
        public string Serialize(List<ThreadResult> list)
        {
            var serializer = new DataContractSerializer(typeof(List<ThreadResult>));
            XmlWriterSettings settings = new XmlWriterSettings() {Indent = true};
            string outputFileName = "threads.xml";
            using(XmlWriter writer = XmlWriter.Create(outputFileName, settings))
            {
                serializer.WriteObject(writer, list);
            }

            return outputFileName;
        }
    }
}