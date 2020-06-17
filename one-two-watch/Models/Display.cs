using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace one_two_watch.Models
{
    class Display
    {
        public DateTime DateTime { get; set; }
        public DateTime TimeSpan { get; set; }

        DispatcherTimer t;
        DateTime start;
    }
}
