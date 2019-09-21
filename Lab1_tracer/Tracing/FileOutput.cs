using System.IO;

namespace Tracing
{
   
        public class FileOutput 
        {
            public void OutputData(string text, string fileFormat)
            {
                File.WriteAllText(fileFormat, text); 
            }
        }
    
}