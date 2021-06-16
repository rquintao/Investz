using System;

namespace Investz.Exceptions
{
    public class InvalidLoginException : Exception
    {
        public InvalidLoginException() 
        {
        }

        public InvalidLoginException(string message) : base(message)
        {
        }

        public InvalidLoginException(string message,
            Exception exception) : base(message, exception)
        {
        }
    }
}
