using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using one_two_watch.Interfaces;
using one_two_watch.Models;



namespace one_two_watch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , ICommons
    {


        public MainWindow()
        {

            InitializeComponent();
          

        }

        private DispatcherTimer _timer;
        DateTime _start;

        // Show a running timer in a WPF window https://stackoverflow.com/questions/24922197/show-a-running-timer-in-a-wpf-window
        public void PowerOn(object sender, EventArgs e)
        {
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 50), DispatcherPriority.Background, PowerOn,
                Dispatcher.CurrentDispatcher) {IsEnabled = true};
            _start = DateTime.Now;

            // C#, datetime formatting, mont name, cultureinfo danish https://stackoverflow.com/questions/42744760/c-datetime-formatting-mont-name-cultureinfo
            Display.Text = Convert.ToString(_start.ToString("F", new CultureInfo("da-DK")));
            
            
        }

        private void PowerOff(object sender, RoutedEventArgs e)
        {
            Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
        }


        public void ShowDisplay(object sender, EventArgs e)
        {
            if (!Display.IsVisible)
            {
                Menu.Visibility = Visibility.Hidden;
                StopWatchBlock.Visibility = Visibility.Hidden;
                Display.Visibility = Visibility.Visible;
                TimeStampStart.Visibility = Visibility.Hidden;
                TimeStampStop.Visibility = Visibility.Hidden;
                Duration.Visibility = Visibility.Hidden;

                Display.Text = "Please power on watch";
            }
           
           
        }

        public void HideDisplay(object sender, EventArgs e)
        {
            if (Menu.IsVisible || Display.IsVisible || StopWatchBlock.IsVisible || StopWatchBlock.IsVisible || StopWatchButtons.IsVisible || CountdownGrid.IsVisible)
            {
                Menu.Visibility = Visibility.Hidden;
                Display.Visibility = Visibility.Hidden;
                StopWatchBlock.Visibility = Visibility.Hidden;
                StopWatchBlock.Visibility = Visibility.Hidden;
                StopWatchButtons.Visibility = Visibility.Hidden;
                TimeStampStart.Visibility = Visibility.Hidden;
                TimeStampStop.Visibility = Visibility.Hidden;
                Duration.Visibility = Visibility.Hidden;
                CountdownGrid.Visibility = Visibility.Hidden;
            }
        }


        private void Mode(object sender, RoutedEventArgs e)
        {
            if (!Menu.IsVisible)
            {
                Display.Visibility = Visibility.Hidden;
                StopWatchBlock.Visibility = Visibility.Hidden;
                Menu.Visibility = Visibility.Visible;
                

            }
           
        }

        private void StopWatch(object sender, RoutedEventArgs e)
        {
            if (!StopWatchBlock.IsVisible)
            {
                Display.Visibility = Visibility.Visible;
                Menu.Visibility = Visibility.Collapsed;
                CountdownGrid.Visibility = Visibility.Hidden;
                StopWatchGrid.Visibility = Visibility.Visible;



            }
            
        }


       StopWatch newStopwatch = new StopWatch();
        private void StartTimerClicked(object sender, RoutedEventArgs e)
        {
            newStopwatch.StartTimer();
            TimeStampStart.Text = Convert.ToString(newStopwatch.TimeStart.ToString("F", new CultureInfo("da-DK")));
            TimeStampStart.Visibility = Visibility.Visible;
            TimeStampStop.Visibility = Visibility.Visible;
            Duration.Visibility = Visibility.Hidden;

        }

        private void StopTimerClicked(object sender, RoutedEventArgs e)
        {
            newStopwatch.StopTimer();
            TimeStampStop.Text = Convert.ToString(newStopwatch.TimeStop.ToString("F", new CultureInfo("da-DK")));

            newStopwatch.Duration = newStopwatch.TimeStop - newStopwatch.TimeStart;
            Duration.Text = newStopwatch.Duration.ToString();

            TimeStampStart.Visibility = Visibility.Visible;
            TimeStampStop.Visibility = Visibility.Visible;
            Duration.Visibility = Visibility.Visible;
        }

        private void CountDown(object sender, RoutedEventArgs e)
        {
            CountdownGrid.Visibility = Visibility.Visible;
            StopWatchGrid.Visibility = Visibility.Hidden;
        }


        CountDown newCountDown = new CountDown();

        private void CountDownStart(object sender, RoutedEventArgs e)
        {
            // How to convert Text box value to int
            newCountDown.CountdownTime = Convert.ToInt32(CountdownInput.Text);
            newCountDown.Start();
           
        }

        
    }
}
