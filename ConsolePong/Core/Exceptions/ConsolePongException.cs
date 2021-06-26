using System;

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
