using System;

namespace Tamagochi_WPF
{
    public class Tamagochi
    {
        //=VARS==============================================================
        #region [ VARS ]
        //=PRIVATE===========================================================
        private int     heal_;
        private bool    is_alive_;
        private int     saturation_;
        private int     poisoning_;
        private int     happines_;
        private string  name_;
        //=END_PRIVATE=======================================================

        //=PUBLIC============================================================
        public string   Name 
        { get { return name_; } set { name_ = value; } }
        public int      Happines 
        { get { return happines_; } set { happines_ = value; } }
        public int      Poisoning 
        { get { return poisoning_; } set { poisoning_ = value; } }
        public int      Saturation 
        { get { return saturation_; } set { saturation_ = value; } }
        public int      Heal 
        { get { return heal_; } set { heal_ = value; } }
        public bool     IsAlive 
        { get { return is_alive_; } set { is_alive_ = value; } }
        public InventoryController Inventory;
        //=END_PUBLIC========================================================
        #endregion
        //=END_VARS==========================================================


        //=FUNCTIONS=========================================================
        #region [ FUNCTIONS ]
        // constructor
        public Tamagochi()
        {
            StateCreate();
            Inventory = new InventoryController();
        }
        // викликається під час створення персонажа. (╯✧▽✧)╯
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
        // викликається за смерті персонажа.(╯✧▽✧)╯
        public void StateDestroy()
        {
            try
            {
                name_ = "";
                if (!is_alive_)
                {
                    throw new ExceptionController("Error: You are dead");
                }
                heal_ = 0;
                poisoning_ = 0;
                saturation_ = 0;
                happines_ = 0;
                is_alive_ = false;

            }
            catch (ExceptionController ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        //викликається на кожен тик ігрового часу (кожні 3_сек. напевно).
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
            { poisoning_ += 1; heal_ -= 5; }

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
        // їм. (o･ω･o)
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
        #endregion
        //=END_FUNCTIONS=====================================================
    }
}
