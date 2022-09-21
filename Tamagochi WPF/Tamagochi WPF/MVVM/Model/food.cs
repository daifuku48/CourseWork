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
        void GetProperties();
        
    }

    public class Sugar : food
    {
        int _heal = -10;
        int _poison = 1;
        int _happy = 10;
        int _hungry = 5;
        public void AffectTamagochi()
        {
            
        }
        public void GetProperties()
        {
            
        }
    }
}
