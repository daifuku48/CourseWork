using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi_WPF
{
    class TamagochiXml
    {
        public TamagochiXml() { }
        public TamagochiXml(Tamagochi t)
        {
            Name = t.Name;
            Happines = t.Happines;
            Poisoning = t.Poisoning;
            Saturation = t.Saturation;
            Heal = t.Heal;
        }
        public string Name { get; set; }
        public int Happines { get; set; }
        public int Poisoning { get; set; }
        public int Saturation { get; set; }
        public int Heal { get; set; }
    }
}
