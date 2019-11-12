using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tracing.Tracing
{
    public class TraceResult
    {
        public readonly ConcurrentDictionary<int, ThreadResult> ThreadsDictionary;

        public TraceResult()
        {
            ThreadsDictionary = new ConcurrentDictionary<int, ThreadResult>();
        }

        // в [] - это атрибуты. Они нужны для сериализации(сохранение в файл с указанием полей и значений см файлы в папке serializer)
        // в 
        [DataContract]
        public class ThreadResult
        {
            [DataMember] public int Id;
            [DataMember] public long Time;
            [DataMember] public List<MethodResult> MethodInfo;

            public ThreadResult(int id)
            {
                Id = id;
                Time = 0;
                MethodInfo = new List<MethodResult>();
            }
        }

        [DataContract]
        public class MethodResult
        {
            [DataMember] public string Name;
            [DataMember] public string ClassName;
            [DataMember] public long Time;
            [DataMember] public List<MethodResult> MethodInfo;

            public MethodResult(string name, string className)
            {
                Name = name;
                ClassName = className;
                Time = 0;
                MethodInfo = new List<MethodResult>();
            }
        }
    }
}
