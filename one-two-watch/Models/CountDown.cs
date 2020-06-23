using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using one_two_watch.Annotations;

namespace one_two_watch.Models
{
    public class CountDown:Watch, INotifyPropertyChanged
    {
        // Simple Countdown with c# WPF  https://www.youtube.com/watch?v=o_F_v_ISeDk
        private int countdownTime;

        public int CountdownTime { get; set; }

        public DispatcherTimer CounTDownTimer;

        public void Start()
        {
            CounTDownTimer = new DispatcherTimer();
            CounTDownTimer.Interval = new TimeSpan(0, 0, 1);
            CounTDownTimer.Tick += Timer_Tick;
            CounTDownTimer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            if (CountdownTime > 0)
            {
                CountdownTime--;
                // https://stackoverflow.com/questions/17001486/how-to-access-wpf-mainwindow-controls-from-my-own-cs-file
                ((MainWindow)System.Windows.Application.Current.MainWindow).DisplayCountDown.Text = string.Format("00:0{0}:{1}", CountdownTime / 60, CountdownTime % 60);
            }
            else
            {
                CounTDownTimer.Stop();
                MessageBox.Show("Countdown finished");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
