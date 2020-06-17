using System;
using System.Collections.Generic;
using System.Linq;
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
using one_two_watch.Models;

namespace one_two_watch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {


            InitializeComponent();


        }


        // Show a running timer in a WPF window https://stackoverflow.com/questions/24922197/show-a-running-timer-in-a-wpf-window
        private void PowerOn(object sender, EventArgs e)
        {
            DispatcherTimer timer;
            DateTime start;

            timer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 50), DispatcherPriority.Background,
                PowerOn, Dispatcher.CurrentDispatcher); timer.IsEnabled = true;
            start = DateTime.Now;
            TimerDisplay.Text = Convert.ToString(DateTime.Now);
        }


        private void PowerOff(object sender, RoutedEventArgs e)
        {
            TimerDisplay.Text = "";
        }
    }
}
