namespace Tracing.Interfaces
{
    public interface IStopWatcher
    {
        void StartTrace();
        void StopTrace();
        long GetTraceResult();
    }
}