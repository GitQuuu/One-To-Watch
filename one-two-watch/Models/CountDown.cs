using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace one_two_watch.Models
{
    public class CountDown:Watch
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

    }
}
