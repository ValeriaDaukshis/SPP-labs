using System.Collections.Generic;
using Tracing.Tracing;

namespace Tracing.Interfaces
{
    public interface ISerializer
    { 
        string Serialize(List<ThreadResult> list);
    }
}