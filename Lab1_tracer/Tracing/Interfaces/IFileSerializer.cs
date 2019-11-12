using System.Collections.Generic;
using Tracing.Tracing;

namespace Tracing.Interfaces
{
    public interface IFileSerializer
    { 
        string Serialize(List<TraceResult.ThreadResult> list);
    }
}