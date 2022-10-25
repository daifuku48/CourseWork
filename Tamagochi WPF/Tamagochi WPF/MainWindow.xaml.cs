using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        
        DispatcherTimer timer , timerstart, timerEnd, timerForTamagochi;

        double MenuWidth , StartGameHeight, EndGameHeight;
        bool hiddenMenu , StartGamehidden , EndGamehidden;
        public Tamagochi tamagochi;


        public MainWindow()
        {
            tamagochi = new Tamagochi();
            this.DataContext = this;
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0 , 1);
            timer.Tick += Timer_Tick;
            timerstart = new DispatcherTimer();
            timerstart.Interval = new TimeSpan (0, 0, 0, 0 , 1);
            timerstart.Tick += Start_Tick;
            timerEnd = new DispatcherTimer();
            timerEnd.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timerEnd.Tick += End_Tick;

            EndGameHeight = EndGamePanel.Height;
            StartGameHeight = StartGamePanel.Height;
            MenuWidth = sideMenu.Width;

            timerForTamagochi = new DispatcherTimer();
            timerForTamagochi.Interval = new TimeSpan(0, 0, 0, 3);
            timerForTamagochi.Tick += Timer_Eat;
       
            
        }
        private void Timer_Eat(object sender, EventArgs e)
        {
            /*tamagochi.ProgressBarOfHappy.Value;*/
            ProgressBarOfHungry.Value = --tamagochi.Hunger;
            Label_HugerIndex.Content = tamagochi.Hunger;

            if (tamagochi.Heal == 0)
            {
                tamagochi.Die();
                
            }
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
                    timerForTamagochi.Start();
                }
            }
        }
        private void End_Tick(object sender, EventArgs e)
        {
            if (EndGamehidden)
            {
                EndGamePanel.Visibility = Visibility.Visible;
                EndGamePanel.Height += EndGameHeight / 20;
                if (EndGamePanel.Height >= EndGameHeight)
                {
                    timerEnd.Stop();
                    EndGamehidden = false;

                }
            }
            else
            {
                EndGamePanel.Height -= EndGameHeight / 20;
                if (EndGamePanel.Height <= 0)
                {
                    timerEnd.Stop();
                    EndGamehidden = true;
                    EndGamePanel.Visibility = Visibility.Hidden;
                    timerstart.Start();
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

        private void NameOfDuck_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Restart_Game(object sender, RoutedEventArgs e)
        {
            timerEnd.Start();
        }

        private void Button_Menu(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void Start_Game(object sender, RoutedEventArgs e)
        {
            if (NameOfDuck.Text.Length >= 3 && NameOfDuck.Text.Length <= 20)
            {
                timerstart.Start();
                tamagochi.Name = NameOfDuck.Text;
                Label_Name.Content = Label_Name.Content + " " + tamagochi.Name;
                tamagochi.Heal = 100;
                tamagochi.Hunger = 50;

                ProgressBarOfHeal.Value = tamagochi.Heal;         
                ProgressBarOfHappy.Value = tamagochi.Happines;
                ProgressBarOfHungry.Value = tamagochi.Hunger;
                ProgressBarOfPoison.Value = tamagochi.Poisoning;
                Label_healIndex.Content = tamagochi.Heal;
                Label_HappinessIndex.Content = tamagochi.Happines;
                Label_HugerIndex.Content = tamagochi.Hunger;
                Label_PoisoningIndex.Content = tamagochi.Poisoning;
            }
        }

        private void leftDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void MenuPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void GetFood(object sender, RoutedEventArgs e)
        {
            if (foodText.Text == "sugar")
            {
                tamagochi.Hunger += 10;
                tamagochi.Heal--;
                foodText.Text = "";
            }
        }










        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null) //оно будет реагировать на изменения 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public class Tamagochi : ObservedObj
        {
            private string _name;
            public string Name
            {
                get { return _name; }
                set
                {
                    if (value != _name)
                    {
                        _name = value;
                        OnPropertyChanged(nameof(_name));
                    }
                }
            }
            public byte Happines { get; set; }
            public byte Poisoning { get; set; }
            public byte Hunger { get; set; }
            public byte Heal { get; set; }
            public DateTime StartTime { get; }
            public DateTime CurrentTime { get; set; }
            public Tamagochi()
            {

            }
            public Tamagochi(ProgressBar happy, ProgressBar heal, ProgressBar hungry)
            {

                Happines = 50;
                Poisoning = 0;
                Hunger = 50;
                Heal = 100;
                DateTime StartTime = DateTime.Now;
                //ProgressBarOfHappy = happy;
            }

            
            //public ProgressBar ProgressBarOfHungry { get; set; }
            //public ProgressBar ProgressBarOfHeal { get; set; }
            //public ProgressBar ProgressBarOfHappy { get; set; }
            //public ProgressBar ProgressBarOfPoison { get; set; }

            public void Die()
            {
                CurrentTime = DateTime.Now;

                if (Heal == 0)
                {
                    //timerEnd.Start();
                }

            }


        }
    }
}
