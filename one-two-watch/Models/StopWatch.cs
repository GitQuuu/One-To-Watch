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
        private TimeSpan _duration;
        private DateTime _timeStart;
        private DateTime _timeStop;
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

        public  DateTime TimeStop { get; set; }
        private ObservableCollection<DateTime> _dateTimeLogsCollection = new ObservableCollection<DateTime>();
        public ObservableCollection<DateTime> DateTimeLogsCollection
        {
            get { return _dateTimeLogsCollection; }
        }

        
        public StopWatch StartTimer()
        {
            TimeStart = DateTime.Now;
            DateTimeLogsCollection.Add(TimeStart);

            return new StopWatch();
        }

        public void StopTimer()
        {
            TimeStop = DateTime.Now;
            DateTimeLogsCollection.Add(TimeStop);

        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
