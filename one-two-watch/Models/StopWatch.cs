using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using one_two_watch.Annotations;

namespace one_two_watch.Models
{
    public class StopWatch:Watch, INotifyPropertyChanged
    {
        public StopWatch()
        {
            
        }

        public StopWatch(DateTime timeStart, DateTime timeStop , TimeSpan duration)
        {
            TimeStart = timeStart;
            TimeStop = timeStop;
            Duration = duration;
        }

        // fields
        private TimeSpan _duration;
        private DateTime _timeStart;
        private DateTime _timeStop;

        // properties
        public  TimeSpan Duration { get; set; }

        public DateTime TimeStart
        {
            get { return _timeStart; }
            set
            {
                _timeStart = value;
                OnPropertyChanged();
            }
        }

        public DateTime TimeStop
        {
            get { return _timeStop; }
            set
            {
                _timeStop = value;
                OnPropertyChanged();
            }
        }



        // Methods
        public DateTime StartTimer()
        {
           return TimeStart = DateTime.Now;
        }

        public DateTime StopTimer()
        {
            return TimeStop = DateTime.Now;
            

        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
