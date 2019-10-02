using System.Diagnostics;
using Tracing.Interfaces;

namespace Tracing.TimeCounters
{
    public class StopWatcher : IStopWatcher
    {
        private readonly Stopwatch _timer;
        public StopWatcher()
        {
            _timer = new Stopwatch();
        }
        public void StartTrace()
        {
            _timer.Start();
        }

        public void StopTrace()
        {
            _timer.Stop();
        }

        public long GetTraceResult()
        {
            return _timer.ElapsedMilliseconds;
        }
    }
}