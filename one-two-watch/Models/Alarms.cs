using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace one_two_watch.Models
{
    class Alarms: Stopwatch
    {
        ObservableCollection<DateTime> alarmsCollection = new ObservableCollection<DateTime>();
        public DateTime AlertTime { get; set; }
    }
}
