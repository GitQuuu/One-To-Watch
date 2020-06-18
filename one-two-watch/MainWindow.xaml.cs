using System;
using System.Collections.Generic;
using System.Globalization;
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
using one_two_watch.Interfaces;


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

        DispatcherTimer _timer;
        DateTime _start;

        // Show a running timer in a WPF window https://stackoverflow.com/questions/24922197/show-a-running-timer-in-a-wpf-window
        public void PowerOn(object sender, EventArgs e)
        {
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 50), DispatcherPriority.Background,
                PowerOn, Dispatcher.CurrentDispatcher); _timer.IsEnabled = true;
            _start = DateTime.Now;

            // C#, datetime formatting, mont name, cultureinfo danish https://stackoverflow.com/questions/42744760/c-datetime-formatting-mont-name-cultureinfo
            TimerDisplay.Text = Convert.ToString(_start.ToString("F", new CultureInfo("da-DK")));
        }



        // Shutdown app on button click https://stackoverflow.com/questions/2820357/how-do-i-exit-a-wpf-application-programmatically
        public void PowerOff(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void Mode(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
