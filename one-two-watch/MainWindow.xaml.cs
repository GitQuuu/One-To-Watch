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



        
        public void ShowDisplay(object sender, EventArgs e)
        {
            if (Menu.IsVisible)
            {
                Menu.Visibility = Visibility.Hidden;
                Display.Visibility = Visibility.Visible;
            }
            else
            {
                Display.Visibility = Visibility.Visible;
            }
           
        }

        public void HideDisplay(object sender, EventArgs e)
        {
            if (Menu.IsVisible || Display.IsVisible)
            {
                Menu.Visibility = Visibility.Hidden;
                Display.Visibility = Visibility.Hidden;

            }
        }


        private void PowerOff(object sender, RoutedEventArgs e)
        {
           Application.Current.Shutdown();
        }

        private void Mode(object sender, RoutedEventArgs e)
        {
            if (Display.IsVisible)
            {
                Display.Visibility = Visibility.Hidden;
                Menu.Visibility = Visibility.Visible;
            }
            else
            {
                Menu.Visibility = Visibility.Visible;
            }
        }
    }
}
