using System;
using System.IO;
using System.Text;

namespace Tracing.Serializer
{ 
    public static class FileOutput 
    { 
        public static string ReadXmlFile(string path)
        {
            StringBuilder xmlInfo = new StringBuilder();
            using(StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                try
                {
                    string str;
                    while ((str =reader.ReadLine())!= null)
                    {
                        xmlInfo.Append($"{str}\n");
                    }
                } 
                catch (IOException e)
                {
                    Console.WriteLine(e.Message); 
                }
            }

            return xmlInfo.ToString();
        }
    } 
}