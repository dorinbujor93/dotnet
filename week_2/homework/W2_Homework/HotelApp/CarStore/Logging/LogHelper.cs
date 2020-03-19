using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Logging
{
    public static class LogHelper
    {
        public enum LogTarget
        {
            File, Console
        }
        public static void Log(LogTarget target, string message)
        {
            switch (target)
            {
                case LogTarget.File:
                    FileLogger flogger = new FileLogger();
                    flogger.Log(message);
                    break;
                case LogTarget.Console:
                    ConsoleLogger clogger = new ConsoleLogger();
                    clogger.Log(message);
                    break;
                default:
                    return;
            }
        }
    }
}
