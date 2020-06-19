using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace one_two_watch.Models
{
    public abstract class Watch
    {
        public DateTime LocalTime { get; set; }
        public DateTime Timespan { get; set; }

        public DateTime Date { get; set; }

    }
}
