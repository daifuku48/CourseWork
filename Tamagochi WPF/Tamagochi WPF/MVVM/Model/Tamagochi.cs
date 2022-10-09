using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;
using Tamagochi_WPF;

namespace Tamagochi_WPF
{
    class Tamagochi : ObservedObj
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
                    OnPropertyChanged("Name");
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
        public Tamagochi( ProgressBar happy,ProgressBar heal, ProgressBar hungry)
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
            
            //if (Heal == 0)
            //{
            //    Console.WriteLine("Он здох");//дописать сюда адекватный код который будет выводить сдохшего 
            //                                 //лезермена и делать запрос на нового лезермена // Звучит как план ( пс. максим )
            //}

        }
    }
}
