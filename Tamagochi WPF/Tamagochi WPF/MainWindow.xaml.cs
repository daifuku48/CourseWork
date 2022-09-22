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

namespace Tamagochi_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer , timerstart;

        double MenuWidth , StartGameHeight;
        bool hiddenMenu , StartGamehidden;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0 , 1);
            timer.Tick += Timer_Tick;
            timerstart = new DispatcherTimer();
            timerstart.Interval = new TimeSpan (0, 0, 0, 0 , 1);
            timerstart.Tick += Start_Tick;

            StartGameHeight = StartGamePanel.Height;
            MenuWidth = sideMenu.Width;
        }
        private void Start_Tick(object sender, EventArgs e)
        {
            if (StartGamehidden)
            {
                StartGamePanel.Visibility = Visibility.Visible;
                StartGamePanel.Height += StartGameHeight / 20;
                if (StartGamePanel.Height >= StartGameHeight)
                {
                    timerstart.Stop();
                    StartGamehidden = false;
                }
            }
            else
            {
                StartGamePanel.Height -= StartGameHeight / 20;
                if (StartGamePanel.Height <= 0)
                {
                    timerstart.Stop();
                    StartGamehidden = true;
                    StartGamePanel.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hiddenMenu)
            {
                sideMenu.Visibility = Visibility.Visible;
                sideMenu.Width += MenuWidth/10;
                if (sideMenu.Width >= MenuWidth)
                {
                    timer.Stop();
                    hiddenMenu = false;
                }
            }
            else
            {    
                sideMenu.Width -= MenuWidth/10;       
                if (sideMenu.Width <= 0)
                {
                    timer.Stop();
                    hiddenMenu = true;
                    sideMenu.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Button_Menu(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
        private void Start_Game(object sender, RoutedEventArgs e)
        {
            timerstart.Start();
        }


        private void MenuPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

    }
}
