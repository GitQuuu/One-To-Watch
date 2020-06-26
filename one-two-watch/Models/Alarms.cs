using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using one_two_watch.Annotations;

namespace one_two_watch.Models
{
    public class Alarms: INotifyPropertyChanged
    {
        private DateTime _alertTime;
        private int _id;
        private string _status = "Under development";
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }
        public DateTime AlertTime
        {
            get { return _alertTime; }
            set { _alertTime = value; OnPropertyChanged(); }
        }

        public string Status
        {
            get { return _status; }
            set { _status= value; OnPropertyChanged(); }
        }

        public void LogAlarm()
        {
            AlertTime = DateTime.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
