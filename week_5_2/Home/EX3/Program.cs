using System;
using System.IO;
using System.Security.Permissions;
using System.Threading;

namespace EX3
{
    public class Watcher
    {
        public static void Main()
        {
            var manager = new FileManager();
            manager.Run();
        }
    }
}