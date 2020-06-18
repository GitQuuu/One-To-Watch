using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace one_two_watch.Interfaces
{
    interface ICommons
    {
        void PowerOn(object sender, EventArgs e);
        void PowerOff(object sender, EventArgs e);
        void Mode(object sender, EventArgs e);
    }
}
