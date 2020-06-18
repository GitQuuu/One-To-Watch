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
        void ShowDisplay(object sender, EventArgs e);
        void HideDisplay(object sender, EventArgs e);
       
    }
}
