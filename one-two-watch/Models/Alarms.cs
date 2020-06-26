using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace one_two_watch.Models
{
    public class Alarms: Stopwatch
    {
        public DateTime AlertTime { get; set; }
    }
}
