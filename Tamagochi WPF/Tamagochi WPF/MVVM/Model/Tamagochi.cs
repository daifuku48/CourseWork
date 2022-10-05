using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tamagochi_WPF.MVVM.Model
{
    class Tamagochi : INotifyPropertyChanged
    {
        public string Name{ get; set; }
        public byte Happines { get; set; }
        public byte Poisoning { get; set; }
        public byte Hunger { get; set; }
        public byte Heal { get; set; }
        public DateTime StartTime { get; }
        public DateTime CurrentTime { get; set; }  
        public Tamagochi(string name, ProgressBar happy,ProgressBar heal, ProgressBar hungry)
        {
            Name = name;
            Happines = 50;
            Poisoning = 0;
            Hunger = 50;
            Heal = 100;
            DateTime StartTime = DateTime.Now;
            ProgressBarOfHappy = happy;
        }
        public ProgressBar ProgressBarOfHungry;
        public ProgressBar ProgressBarOfHeal, ProgressBarOfHappy, ProgressBarOfPoison;

        public void Die()
        {
            //if (Heal == 0)
            //{
            //    Console.WriteLine("Он здох");//дописать сюда адекватный код который будет выводить сдохшего 
            //                                 //лезермена и делать запрос на нового лезермена // Звучит как план ( пс. максим )
            //}

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
