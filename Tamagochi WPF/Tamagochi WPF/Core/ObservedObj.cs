using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi_WPF
{
    class ObservedObj : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null) //оно будет реагировать на изменения 
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
