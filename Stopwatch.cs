using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelearningConsole
{
    class Stopwatch
    {
        private bool isRunning = false;
        public DateTime? StartTime { get; private set;  }
        public DateTime? StopTime { get; private set; }

        TimeSpan? Duration
        {
            get
            {
                if (StartTime != null && StopTime != null)
                    return StopTime - StartTime;
                else if (StartTime != null)
                    return DateTime.Now - StartTime;
                else
                    return null;
            }
        }

        public void Start()
        {
            if (isRunning)
                throw new InvalidOperationException("Stopwatch already running.");

            StartTime = DateTime.Now;
            StopTime = null;
            isRunning = true;
        }

        public void Stop()
        {
            if (!isRunning)
                throw new InvalidOperationException("Stopwatch not running.");

            StopTime = DateTime.Now;
            isRunning = false;
        }
    }
}
