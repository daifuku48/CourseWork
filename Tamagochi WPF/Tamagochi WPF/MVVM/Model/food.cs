using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi_WPF.MVVM.Model
{
    
    public interface food
    {
        void AffectTamagochi();
    }

    public class Sugar : food
    {
        int _heal = -10;
        int _poison = 1;
        int _happy = 10;
        int _hungry = -5;
        public void AffectTamagochi()
        {

        }
    }

    public class Meet : food
    {
        int _heal = 10;
        int _poison = 3;
        int _happy = 10;
        int _hungry = -5;
        public void AffectTamagochi()
        {

        }
    }

    public class Water : food
    {
        int _heal = 0;
        int _poison = 0;
        int _happy = 1;
        int _hungry = -3;
        public void AffectTamagochi()
        {

        }
    }

    public class Duck : food
    {
        int _heal = 30;
        int _poison = 50;
        int _happy = -30;
        int _hungry = -40;
        public void AffectTamagochi()
        {

        }
    }

    public class Corn : food
    {
        int _heal = 20;
        int _poison = 0;
        int _happy = 20;
        int _hungry =-30;
        public void AffectTamagochi()
        {

        }
    }

    public class Fire
    {
        int _heal = -40;
        int _poison = 0;
        int _happy = -30;
        int _hungry = 0;
        public void AffectTamagochi()
        {

        }
    }

}
