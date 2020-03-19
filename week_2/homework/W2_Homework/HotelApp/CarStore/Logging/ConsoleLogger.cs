using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarStore.Logging
{
    class ConsoleLogger : ILogger
    {
      
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
