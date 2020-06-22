using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace one_two_watch.Models
{
    public class StopWatch:Watch
    {
        public  TimeSpan Duration { get; set; }
        public  DateTime TimeStart { get; set; }
        public  DateTime TimeStop { get; set; }

        public StopWatch StartTimer()
        {
            TimeStart = DateTime.Now;

            return new StopWatch();
        }

        public void StopTimer()
        {
            TimeStop = DateTime.Now;
        }

    }
}
