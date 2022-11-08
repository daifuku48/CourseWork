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
    public partial class MainWindow : Window
    {
        
        DispatcherTimer timer , timerstart, timerEnd, timerForTamagochi, timerForTakeEat, timerOfLife;

        double MenuWidth , StartGameHeight, EndGameHeight;
        bool hiddenMenu , StartGamehidden , EndGamehidden;
        Tamagochi tamagochi;

        int timeOflife;

        public MainWindow()
        {
            tamagochi = new Tamagochi();
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

            timerForTakeEat = new DispatcherTimer();
            timerForTamagochi.Interval = new TimeSpan(0, 0, 0, 10);
            timerForTakeEat.Tick += Timer_Take_Eat;

            timerOfLife = new DispatcherTimer();
            timerOfLife.Interval = new TimeSpan(0, 0, 0, 60);
            timerOfLife.Tick += TimerOfLife_Tick;
        }

        private void TimerOfLife_Tick(object sender, EventArgs e)
        {
            timeOflife++;
            Label_AgeText.Content = "Age: " + Convert.ToString(timeOflife) + " years";
        }

        private void Timer_Eat(object sender, EventArgs e)
        {
            /*tamagochi.ProgressBarOfHappy.Value;*/
            tamagochi.StateUpdate();
            ProgressBarOfHungry.Value = tamagochi.Saturation;
            Label_HugerIndex.Content = tamagochi.Saturation;
            ProgressBarOfHappy.Value = tamagochi.Happines;
            Label_HappinessIndex.Content = tamagochi.Happines;
            ProgressBarOfHeal.Value = tamagochi.Heal;
            Label_healIndex.Content = tamagochi.Heal;
            ProgressBarOfPoison.Value = tamagochi.Poisoning;
            Label_PoisoningIndex.Content = tamagochi.Poisoning;
            if (!tamagochi.IsAlive)
            {
                EndGamehidden = true;
                timerForTamagochi.Stop();
                timerEnd.Start();
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
                    timerOfLife.Start();
                }
            }
        }
        //таймер с для вывода панели в начале игры для задавания имени персонажу
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
                    tamagochi.StateCreate();
                    timerstart.Start();
                    StartGamehidden = true;
                }
            }
        }
        //рестарт игры(если захотим, можно сюда еще допилить панель с результатами, сколько еды сёел и сколько минут прожил

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
                Label_Name.Content = "Name: " + tamagochi.Name;
                ProgressBarOfHeal.Value = tamagochi.Heal;         
                ProgressBarOfHappy.Value = tamagochi.Happines;
                ProgressBarOfHungry.Value = tamagochi.Saturation;
                ProgressBarOfPoison.Value = tamagochi.Poisoning;
                Label_healIndex.Content = tamagochi.Heal;
                Label_HappinessIndex.Content = tamagochi.Happines;
                Label_HugerIndex.Content = tamagochi.Saturation;
                Label_PoisoningIndex.Content = tamagochi.Poisoning;
            }
        }
        //передача начальных параметров в интерфейс
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

        String[] food = { };

        private void Timer_Take_Eat(object sender, EventArgs e)
        {

        }

        private void GetFood(object sender, RoutedEventArgs e)
        {
            
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected void OnPropertyChanged([CallerMemberName] string name = null) //оно будет реагировать на изменения 
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}

        //public class Tamagochi : ObservedObj
        //{
        //    private string _name;
        //    public string Name
        //    {
        //        get { return _name; }
        //        set
        //        {
        //            if (value != _name)
        //            {
        //                _name = value;
        //                OnPropertyChanged(nameof(_name));
        //            }
        //        }
        //    }
        //    public byte Happines { get; set; }
        //    public byte Poisoning { get; set; }
        //    public byte Hunger { get; set; }
        //    public byte Heal { get; set; }
        //    public DateTime StartTime { get; }
        //    public DateTime CurrentTime { get; set; }
        //    public Tamagochi()
        //    {

        //    }
        //    public Tamagochi(ProgressBar happy, ProgressBar heal, ProgressBar hungry)
        //    {

        //        Happines = 50;
        //        Poisoning = 0;
        //        Hunger = 50;
        //        Heal = 100;
        //        DateTime StartTime = DateTime.Now;
        //        //ProgressBarOfHappy = happy;
        //    }

            
        //    //public ProgressBar ProgressBarOfHungry { get; set; }
        //    //public ProgressBar ProgressBarOfHeal { get; set; }
        //    //public ProgressBar ProgressBarOfHappy { get; set; }
        //    //public ProgressBar ProgressBarOfPoison { get; set; }

        //    public void Die()
        //    {
        //        CurrentTime = DateTime.Now;

        //        if (Heal == 0)
        //        {
        //            //timerEnd.Start();
        //        }

        //    }


        //}
    }
}
