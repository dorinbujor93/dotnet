using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
   public class InvalidRangeException<T> : System.Exception
    {

        private const string DefaultMessage = "You are outside range default message.";

        public T RStart { get; set; }
        public T REnd { get; set; }

        public InvalidRangeException() : base(DefaultMessage) { }

        public InvalidRangeException(string message) : base(message) { }
        public InvalidRangeException(string message, System.Exception innerException)
            : base(message, innerException) { }

        public InvalidRangeException(string message, T rStart, T rEnd)
            : base(message)
        {
            RStart = rStart;
            REnd = rEnd;
        }
    }
}
