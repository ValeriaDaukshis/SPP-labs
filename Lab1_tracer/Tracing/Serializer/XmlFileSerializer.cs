using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using Tracing.Interfaces;
using Tracing.Tracing;

namespace Tracing.Serializer
{
    public class XmlFileSerializer : IFileSerializer
    { 
        //сериализация в xml. В файле все в фигурных скобках
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