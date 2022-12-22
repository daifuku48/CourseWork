using System;

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
