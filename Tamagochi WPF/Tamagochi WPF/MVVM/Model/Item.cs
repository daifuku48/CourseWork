namespace Tamagochi_WPF
{
    public class Item
    {
        //=VARS==============================================================
        #region [ VARS ]
        public IFood    food;
        public int      amount;
        #endregion
        //=END_VARS==========================================================


        //=FUNCTINOS=========================================================
        #region [ FUNCTIONS ]
        public Item() 
        { 

        }

        public Item(IFood food_, int amount_ = 1)
        {
            food = food_;
            amount = amount_;
        }

        public static bool operator ==(Item this_, Item other_)
        {
            return this_.food == other_.food;
        }

        public static bool operator !=(Item this_, Item other_)
        {
            return this_.food != other_.food;
        }
        #endregion
        //=END_FUNCTIONS=====================================================
    }
}
