using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarStore.Logging
{
    class FileLogger : ILogger
    {
        public string filePath = @"D:\Log.txt";
        public void Log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, append: true))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
    }
}
