using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong.Core.Exceptions
{
    class ConsolePongException : Exception
    {
        public ConsolePongException(string message) : base(message)
        {

        }
        public ConsolePongException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
