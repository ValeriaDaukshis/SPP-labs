using System;
using System.IO;
using System.Text;

namespace Tracing
{ 
    public static class FileOutput 
    { 
        public static string ReadXmlFile(string path)
        {
            StringBuilder xmlInfo = new StringBuilder();
            string str;
            using(FileStream fin = new FileStream(path, FileMode.Open))
            {
                StreamReader st_fin = new StreamReader(fin);
                try
                {
                    while ((str =st_fin.ReadLine())!= null)
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