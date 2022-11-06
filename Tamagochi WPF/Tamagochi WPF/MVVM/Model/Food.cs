using System;


namespace Tamagochi_WPF
{
    public interface IFood
    {
        string Name { get; } // имя продукта
        int Heal { get; } // количество здоровья которое востанавливает продукт
        int Poison { get; } // количество отравление продуктом
        int Happy { get; } // количество счастья
        int Satiety { get; } // количество насыщения
        string[] Recipe { get; } // рецепт а точнеее список необходимых ингредиентов
        bool HasRecipe(); // является ли объект приготовляемый(true) или базовым(false) продуктом

        void AffectTamagochi();
    }

    public class Sugar : IFood
    {
        private string _name = "sugar";
        string IFood.Name { get { return _name; } }

        private int _heal = -10;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 5;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 10;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 5;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = null;
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Salt : IFood
    {
        private string _name = "salt";
        string IFood.Name { get { return _name; } }

        private int _heal = -10;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 5;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 10;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 5;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = null;
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Water : IFood
    {
        private string _name = "water";
        string IFood.Name { get { return _name; } }

        private int _heal = 0;
        int IFood.Heal { get { return _heal; } }

        private int _poison = -25;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 5;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 0;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = null;
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Fire : IFood
    {
        private string _name = "fire";
        string IFood.Name { get { return _name; } }

        private int _heal = -40;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 20;
        int IFood.Poison { get { return _poison; } }

        private int _happy = -30;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 0;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = null;
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Duck : IFood
    {
        private string _name = "duck";
        string IFood.Name { get { return _name; } }

        private int _heal = 30;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 50;
        int IFood.Poison { get { return _poison; } }

        private int _happy = -30;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 40;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = null;
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Corn : IFood
    {
        private string _name = "corn";
        string IFood.Name { get { return _name; } }

        private int _heal = 5;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 10;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 10;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 5;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = null;
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Fish : IFood
    {
        private string _name = "fish";
        string IFood.Name { get { return _name; } }

        private int _heal = 20;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 20;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 10;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 20;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = null;
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Egg : IFood
    {
        private string _name = "egg";
        string IFood.Name { get { return _name; } }

        private int _heal = 10;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 5;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 10;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 10;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = null;
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Mushroom : IFood
    {
        private string _name = "mushroom";
        string IFood.Name { get { return _name; } }

        private int _heal = 10;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 15;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 10;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 10;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = null;
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Marshmallow : IFood
    {
        private string _name = "marshmallow";
        string IFood.Name { get { return _name; } }

        private int _heal = 10;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 0;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 30;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 10;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = null;
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Vegetable : IFood
    {
        private string _name = "vegetable";
        string IFood.Name { get { return _name; } }

        private int _heal = 15;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 0;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 15;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 15;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = null;
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Flakes : IFood
    {
        private string _name = "flakes";
        string IFood.Name { get { return _name; } }

        private int _heal = 25;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 0;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 30;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 20;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = { "corn", "water" };
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Bread : IFood
    {
        private string _name = "bread";
        string IFood.Name { get { return _name; } }

        private int _heal = 20;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 0;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 5;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 20;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = { "corn", "fire" };
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Pie : IFood
    {
        private string _name = "pie";
        string IFood.Name { get { return _name; } }

        private int _heal = 35;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 0;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 50;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 25;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = { "bread", "berry" };
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Jam : IFood
    {
        private string _name = "jam";
        string IFood.Name { get { return _name; } }

        private int _heal = 15;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 0;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 30;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 10;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = { "berry", "sugar" };
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Compote : IFood
    {
        private string _name = "compote";
        string IFood.Name { get { return _name; } }

        private int _heal = 5;
        int IFood.Heal { get { return _heal; } }

        private int _poison = -20;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 20;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 10;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = { "berry", "water" };
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Jelly : IFood
    {
        private string _name = "jelly";
        string IFood.Name { get { return _name; } }

        private int _heal = 15;
        int IFood.Heal { get { return _heal; } }

        private int _poison = -15;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 55;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 40;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = { "jam", "marshmallow" };
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Omelette : IFood
    {
        private string _name = "omelette";
        string IFood.Name { get { return _name; } }

        private int _heal = 10;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 0;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 30;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 20;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = { "egg", "fire" };
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Pancake : IFood
    {
        private string _name = "pancake";
        string IFood.Name { get { return _name; } }

        private int _heal = 20;
        int IFood.Heal { get { return _heal; } }

        private int _poison = -10;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 40;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 40;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = { "jelly", "bread" };
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Toast : IFood
    {
        private string _name = "toast";
        string IFood.Name { get { return _name; } }

        private int _heal = 10;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 0;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 10;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 10;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = { "corn", "fire" };
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class GrilledVegetables : IFood
    {
        private string _name = "grilled_vegetables";
        string IFood.Name { get { return _name; } }

        private int _heal = 20;
        int IFood.Heal { get { return _heal; } }

        private int _poison = -10;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 15;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 20;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = { "vegetable", "fire" };
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Salad : IFood
    {
        private string _name = "salad";
        string IFood.Name { get { return _name; } }

        private int _heal = 20;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 0;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 15;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 15;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = { "vegetable", "vegetable" };
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Steak : IFood
    {
        private string _name = "steak";
        string IFood.Name { get { return _name; } }

        private int _heal = 35;
        int IFood.Heal { get { return _heal; } }

        private int _poison = -5;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 40;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 35;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = { "meat", "fire" };
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Rice : IFood
    {
        private string _name = "rice";
        string IFood.Name { get { return _name; } }

        private int _heal = 20;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 0;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 20;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 20;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = { "corn", "water" };
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class RiceVegetables : IFood
    {
        private string _name = "rice_vegetables";
        string IFood.Name { get { return _name; } }

        private int _heal = 30;
        int IFood.Heal { get { return _heal; } }

        private int _poison = -10;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 35;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 30;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = { "rice", "vegetable" };
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class Popcorn : IFood
    {
        private string _name = "popcorn";
        string IFood.Name { get { return _name; } }

        private int _heal = 25;
        int IFood.Heal { get { return _heal; } }

        private int _poison = 0;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 25;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 25;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = { "rice", "fire" };
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class VegetableSoup : IFood
    {
        private string _name = "vegetable_soup";
        string IFood.Name { get { return _name; } }

        private int _heal = 25;
        int IFood.Heal { get { return _heal; } }

        private int _poison = -30;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 40;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 40;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = { "vegetable", "water" };
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class MushroomSoup : IFood
    {
        private string _name = "mushroom_soup";
        string IFood.Name { get { return _name; } }

        private int _heal = 30;
        int IFood.Heal { get { return _heal; } }

        private int _poison = -30;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 45;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 45;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = { "mushroom", "water" };
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }

    public class FishSoup : IFood
    {
        private string _name = "fish_soup";
        string IFood.Name { get { return _name; } }

        private int _heal = 35;
        int IFood.Heal { get { return _heal; } }

        private int _poison = -30;
        int IFood.Poison { get { return _poison; } }

        private int _happy = 50;
        int IFood.Happy { get { return _happy; } }

        private int _satiety = 50;
        int IFood.Satiety { get { return _satiety; } }

        private string[] _recipe = { "fish", "water" };
        string[] IFood.Recipe { get { return _recipe; } }

        void IFood.AffectTamagochi() { }
        public bool HasRecipe()
        {
            return _recipe != null;
        }
    }
}

