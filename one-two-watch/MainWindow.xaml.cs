using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<StopWatch> _dateTimeLogsCollection = new ObservableCollection<StopWatch>();
        public ObservableCollection<StopWatch> DateTimeLogsCollection
        {
            get { return _dateTimeLogsCollection; }
        }

        public MainWindow()
        {

            InitializeComponent();
            this.DataContext = this;
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
                DataGridDisplay.Visibility = Visibility.Hidden;
                Display.Visibility = Visibility.Visible;

                Display.Text = "Please power on watch";
            }
           
           
        }

        public void HideDisplay(object sender, EventArgs e)
        {
            if (Menu.IsVisible || Display.IsVisible || DataGridDisplay.IsVisible || DataGridDisplay.IsVisible || StopWatchButtons.IsVisible || CountdownGrid.IsVisible)
            {
                Menu.Visibility = Visibility.Hidden;
                Display.Visibility = Visibility.Hidden;
                DataGridDisplay.Visibility = Visibility.Hidden;
                DataGridDisplay.Visibility = Visibility.Hidden;
                StopWatchButtons.Visibility = Visibility.Hidden;
                CountdownGrid.Visibility = Visibility.Hidden;
            }
        }


        private void Mode(object sender, RoutedEventArgs e)
        {
            if (!Menu.IsVisible)
            {
                Display.Visibility = Visibility.Hidden;
                Menu.Visibility = Visibility.Visible;
                

            }
           
        }

        private void StopWatch(object sender, RoutedEventArgs e)
        {
            if (!StopWatchGrid.IsVisible)
            {
               
                Display.Visibility = Visibility.Visible;
                StopWatchGrid.Visibility = Visibility.Visible;
                DataGridDisplay.Visibility = Visibility.Visible;
                Menu.Visibility = Visibility.Collapsed;
                CountdownGrid.Visibility = Visibility.Hidden;
                



            }
            
        }


        private StopWatch newStopwatch = new StopWatch();
        private void StartTimerClicked(object sender, RoutedEventArgs e)
        {

            newStopwatch.Id++;
            newStopwatch.TimeStart = DateTime.Now;
            DateTimeLogsCollection.Add(newStopwatch);


        }

        private void StopTimerClicked(object sender, RoutedEventArgs e)
        {
         
            newStopwatch.TimeStop = DateTime.Now;
            DateTimeLogsCollection.Add(newStopwatch);



        }

        private void CountDown(object sender, RoutedEventArgs e)
        {
            CountdownGrid.Visibility = Visibility.Visible;
            StopWatchGrid.Visibility = Visibility.Hidden;
        }


        CountDown newCountDown = new CountDown();

        private void CountDownStart(object sender, RoutedEventArgs e)
        {
            // How to convert Text box value to int http://www.beansoftware.com/ASP.NET-FAQ/TextBox-Integer.aspx
            newCountDown.CountdownTime = Convert.ToInt32(CountdownInput.Text);
            
            newCountDown.Start();
           
        }

        
    }
}
