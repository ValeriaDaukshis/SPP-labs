using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracing; 
using System.Runtime.Serialization; 


namespace Serializer
{
    public class JSonSerializer
    {
        public void Serialize(MethodInfo methodInfo, ThreadInfo threadInfo)
        {
            var serializer = new DataContractSerializer(typeof(MethodInfo));
        }
    }
}
