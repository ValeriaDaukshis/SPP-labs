using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using Tracing.Interfaces;
using Tracing.Tracing;

namespace Tracing.Serializer
{
    public class XmlSerializer : ISerializer
    { 
        public string Serialize(List<TraceResult.ThreadResult> list)
        {
            var serializer = new DataContractSerializer(typeof(List<TraceResult.ThreadResult>));
            XmlWriterSettings settings = new XmlWriterSettings() {Indent = true};
            string outputFileName = "threads.xml";
            using(XmlWriter writer = XmlWriter.Create(outputFileName, settings))
            {
                serializer.WriteObject(writer, list);
            }

            return FileOutput.ReadXmlFile(outputFileName);
        }
    }
}