using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi_WPF
{
    
    public interface food
    {
        void AffectTamagochi();
    }

    public class Sugar : food // cахар
    {
        int _heal = -10;
        int _poison = 5;
        int _happy = 10;
        int _hungry = -5;
        public void AffectTamagochi()
        {

        }
    }

    public class Salt : food // соль
    {
        int _heal = -15;
        int _poison = 5;
        int _happy = 5;
        int _hungry = -5;
        public void AffectTamagochi() { }
    }

    public class Meet : food // мясо
    {
        int _heal = 10;
        int _poison = 20;
        int _happy = 10;
        int _hungry = -5;
        public void AffectTamagochi()
        {

        }
    }

    public class Water : food // вода
    {
        int _heal = 0;
        int _poison = -50;
        int _happy = 1;
        int _hungry = -5;
        public void AffectTamagochi()
        {

        }
    }

    public class Fire // огонь
    {
        int _heal = -40;
        int _poison = 20;
        int _happy = -30;
        int _hungry = 0;
        public void AffectTamagochi()
        {

        }
    }

    public class Duck : food // утка
    {
        int _heal = 30;
        int _poison = 50;
        int _happy = -30;
        int _hungry = -40;
        public void AffectTamagochi()
        {

        }
    }

    public class Corn : food // зерно
    {
        int _heal = 20;
        int _poison = 10;
        int _happy = 20;
        int _hungry = -30;
        public void AffectTamagochi()
        {

        }
    }

    public class Fish : food // рыба
    {
        int _heal = 30;
        int _poison = 30;
        int _happy = -30;
        int _hungry = -40;
        public void AffectTamagochi() { }
    }

    public class Egg : food // яичко
    {
        int _heal = 10;
        int _poison = 10;
        int _happy = 10;
        int _hungry = -10;
        public void AffectTamagochi() { }
    }

    public class Berry : food // ягода
    {
        int _heal = 5;
        int _poison = 0;
        int _happy = 5;
        int _hungry = -5;
        public void AffectTamagochi() { }
    }

    public class Mushroom : food // ну ты и гриб 
    {
        int _heal = 10;
        int _poison = 20;
        int _happy = 10;
        int _hungry = -10;
        public void AffectTamagochi() { }
    }

    public class Marshmallow : food // зефир
    {
        int _heal = 10;
        int _poison = 0;
        int _happy = 30;
        int _hungry = -10;
        public void AffectTamagochi() { }
    }

    public class Vegetable : food // овощь ( -_* )
    {
        int _heal = 15;
        int _poison = 0;
        int _happy = 15;
        int _hungry = -15;
        public void AffectTamagochi() { }
    }
    
    public class Flakes : food // хлопья = corn(зерно) + water(вода)
    {
        int _heal = 25;
        int _poison = 0;
        int _happy = 30;
        int _hungry = -50;
        public void AffectTamagochi() { }
    }

    public class Bread : food // хлебный мякиш = corn(зерно) + fire(огонь)
    {
        int _heal = 20;
        int _poison = 0;
        int _happy = 5;
        int _hungry = -20;
        public void AffectTamagochi() { }
    }
    
    public class Pie : food // пирог = bread(хлеб) + berry(ягода)
    {
        int _heal = 30;
        int _poison = 0;
        int _happy = 50;
        int _hungry = -35;
        public void AffectTamagochi() { }
    }
    
    public class Jam : food // варенье = berry(ягоды) + sugar(сахар)
    {
        int _heal = 10;
        int _poison = 0;
        int _happy = 20;
        int _hungry = -10;
        public void AffectTamagochi() { }
    }
    
    public class Compote : food // компот = berry(ягода) + water(вода)
    {
        int _heal = 5;
        int _poison = -20;
        int _happy = 10;
        int _hungry = -5;
        public void AffectTamagochi() { }
    }
    
    public class Jelly : food // болотная жижа = jam(варенье) + marshmallow(зефир) 
    {
        int _heal = 10;
        int _poison = -5;
        int _happy = 40;
        int _hungry = -15;
        public void AffectTamagochi() { }
    }
    
    public class Omelette : food // подгорелое яичко = egg(яйцо) + fire(огонь)
    {
        int _heal = 10;
        int _poison = 0;
        int _happy = 25;
        int _hungry = -25;
        public void AffectTamagochi() { }
    }

    public class Pancake : food // блинчик = jelly(желе) + bread(хлеб) 
    {
        int _heal = 20;
        int _poison = 0;
        int _happy = 25;
        int _hungry = -25;
        public void AffectTamagochi() { }
    }

    public class Toast : food // тост = corn(зерно) + fire(огонь)
    {
        int _heal = 10;
        int _poison = 0;
        int _happy = 10;
        int _hungry = -15;
        public void AffectTamagochi() { }
    }

    public class GrilledVegetables : food // подгорелый овощ = vegetable(овощ) + fire(огонь)
    {
        int _heal = 20;
        int _poison = -10;
        int _happy = 20;
        int _hungry = -25;
        public void AffectTamagochi() { }
    }

    public class Salad : food // салат = vegetable(овощ) + salt(соль)
    {
        int _heal = 20;
        int _poison = 0;
        int _happy = 15;
        int _hungry = -25;
        public void AffectTamagochi() { }
    }

    public class Steak : food // стейк = meat(мясо) + fire(огонь)
    {
        int _heal = 50;
        int _poison = -10;
        int _happy = 50;
        int _hungry = -25;
        public void AffectTamagochi() { }
    }

    public class Rice : food // рис = corn(зерно) + water(вода)
    {
        int _heal = 0;
        int _poison = 0;
        int _happy = 0;
        int _hungry = 0;
        public void AffectTamagochi() { }
    }

    public class RiceVegetables : food // рис с о. = rice(рис) + vegetable(овощ)
    {
        int _heal = 0;
        int _poison = 0;
        int _happy = 0;
        int _hungry = 0;
        public void AffectTamagochi() { }
    }

    public class Popcorn : food // попкорн = rice(рис) + fire(огонь)
    {
        int _heal = 5;
        int _poison = 0;
        int _happy = 5;
        int _hungry = -10;
        public void AffectTamagochi() { }
    }

    public class VegetableSoup : food // овощьной суп = vegetable(овощ) + water(вода)
    {
        int _heal = 20;
        int _poison = -30;
        int _happy = 50;
        int _hungry = -40;
        public void AffectTamagochi() { }
    }

    public class MushroomSoup : food // грибной суп = mushroom(гриб) + water(вода)
    {
        int _heal = 30;
        int _poison = -30;
        int _happy = 50;
        int _hungry = -45;
        public void AffectTamagochi() { }
    }

    public class FishSoup : food // рибный суп = fish(рыба) + water(вода)
    {
        int _heal = 40;
        int _poison = -30;
        int _happy = 50;
        int _hungry = -50;
        public void AffectTamagochi() { }
    }
}