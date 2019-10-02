using System.Collections.Generic;

namespace Tracing
{
    public interface ISerializer
    { 
        string Serialize(List<ThreadResult> list);
    }
}