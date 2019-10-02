using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Tracing
{
    public class XmlSerializer : ISerializer
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

            return FileOutput.ReadXmlFile(outputFileName);

//            MemoryStream memoryStream = new MemoryStream();
//
//            var xmlSerializer = new XmlSerializer(typeof(List<ThreadResult>));
//
//            xmlSerializer.Serialize(memoryStream, list);
//            memoryStream.Position = 0;
//
//            StreamReader sr = new StreamReader(memoryStream);
//            return sr.ReadToEnd();
        }
    }
}