using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi_WPF
{
    class TamagochiJson
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public TamagochiJson(string name, int timeOflife)
        {
            Name = name;
            Rating = timeOflife;
        }
        public TamagochiJson()
        {
            Name = "";
            Rating = 0;
        }
    }
}
