using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tamagochi_WPF
{
    class Tamagochi
    {
        private string name_;
        public string Name { get { return name_; } set { name_ = value; } }

        private int happines_;
        public int Happines { get { return happines_; } set { happines_ = value; } }

        private int poisoning_;
        public int Poisoning { get { return poisoning_; } set { poisoning_ = value; } }

        private int saturation_;
        public int Saturation { get { return saturation_; } set { saturation_ = value; } }

        private int heal_;
        public int Heal { get { return heal_; } set { heal_ = value; } }

        private bool is_alive_;
        public bool IsAlive { get { return is_alive_; } set { is_alive_ = value; } }

        public InventoryController Inventory;

        public Tamagochi(List<IFood> food_)
        {
            StateCreate();
            Inventory = new InventoryController(food_);
        }

        public void StateCreate()
        {
            try
            {
                heal_ = 100;
                poisoning_ = 0;
                saturation_ = 100;
                happines_ = 100;
                is_alive_ = true;
            }
            catch (ExceptionController ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        // викликається під час створення персонажа. (╯✧▽✧)╯

        public void StateDestroy()
        {
            try
            {
                if (!is_alive_)
                {
                    throw new ExceptionController("Error: You are dead");
                }
                heal_ = 0;
                poisoning_ = 0;
                saturation_ = 0;
                happines_ = 0;
                is_alive_ = false;
                name_ = "";
            }
            catch (ExceptionController ex) 
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        // викликається за смерті персонажа.(╯✧▽✧)╯

        public void StateUpdate()
        {
            if (heal_ <= 0)
            {
                is_alive_ = false;
                //StateDestroy();
            }

            if (saturation_ > 75)
            {
                heal_ += 5;
                happines_ += 3;
            }

            if (poisoning_ > 0)
            {
                heal_ -= 4;
                poisoning_ -= 1;
            }

            if (happines_ <= 25)
            { poisoning_ += 1; heal_ -= 5;}
               
                //poisoning_ = poisoning_ + Math.Abs(happines_);

            if (saturation_ <= 75)
                heal_ -= 10;

            happines_ -= 5;
            saturation_ -= 5;

            if (heal_ > 100) heal_ = 100;

            if (poisoning_ > 100) poisoning_ = 100;

            if (saturation_ > 100) saturation_ = 100;

            if (happines_ > 100) happines_ = 100;

            if (happines_ < 0) happines_ = 0;

            if (heal_ < 0) heal_ = 0;

            if (poisoning_ < 0) poisoning_ = 0;

            if (saturation_ < 0) saturation_ = 0;
        }
        //викликається на кожен тик ігрового часу (кожні 3_сек. напевно).

        public void Eat(IFood food_)
        {
            try
            {
                if (!is_alive_)
                {
                    throw new ExceptionController("Error: You are dead");
                }

                if ((heal_ + food_.Heal) < 100)
                    heal_ += food_.Heal;
                else
                    heal_ = 100;

                if ((saturation_ + food_.Satiety) < 100)
                    saturation_ += food_.Satiety;
                else
                    saturation_ = 100;

                if ((poisoning_ + food_.Poison) < 100)
                    poisoning_ += food_.Poison;
                else
                    poisoning_ = 100;

                if ((happines_ + food_.Happy) < 100)
                    happines_ += food_.Happy;
                else
                    happines_ = 100;

                Console.WriteLine("Вы покушац");
            }
            catch (ExceptionController ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        // їм. (o･ω･o)
    }
}
