using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Tracing.Interfaces;
using Tracing.Tracing;
using Formatting = Newtonsoft.Json.Formatting;

namespace Tracing.Serializer 
{
    public class JSonFileSerializer : IFileSerializer
    {
        public string Serialize(List<TraceResult.ThreadResult> list)
        {
            string jsonInfo;
            string outputFileName = "threads.json";
            // сериализация в json(там фигурные скобочки в файле)
            // сериализация просто одной строчкой делается (jsonInfo = ...)
            //Formatting.Indented - чтоб файлик выглядил красиво(тип с отступами)
            using(new FileStream(outputFileName, FileMode.OpenOrCreate))
            { 
                jsonInfo = JsonConvert.SerializeObject(list, Formatting.Indented);
            } 
            return jsonInfo;
        }
    }
}
