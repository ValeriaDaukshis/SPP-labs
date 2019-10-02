﻿using Tracing.Tracing;

namespace Tracing.Interfaces
{
    public interface ITracer
    {
        void StartTrace();
        void StopTrace();
        TraceResult GetTraceResult();
    }
}
