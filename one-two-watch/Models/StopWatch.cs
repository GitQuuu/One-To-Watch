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
        private TimeSpan duration;
        private DateTime timeStart;
        private DateTime timeStop;
        public  TimeSpan Duration { get; set; }

        public DateTime TimeStart
        {
            get { return timeStart; }
            set
            {
                timeStart = value;
                OnPropertyChanged();
            }
        }

        public  DateTime TimeStop { get; set; }

        private ObservableCollection<DateTime> dateTimeLogsCollection = new ObservableCollection<DateTime>();

        public StopWatch StartTimer()
        {
            dateTimeLogsCollection.Add(TimeStart = DateTime.Now);

            return new StopWatch();
        }

        public void StopTimer()
        {
            TimeStop = DateTime.Now;
            dateTimeLogsCollection.Add(TimeStop);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
