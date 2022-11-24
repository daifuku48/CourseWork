using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi_WPF
{
    internal class ExceptionController : Exception
    {
        public ExceptionController() 
            : base("Error")
        {


        }

        public ExceptionController(string message_)
            : base(message_)
        {

        }
    }
}
