using System;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var evernt = new MyEvent();
            evernt.MyEv += new OnMyEventHandler(Callback);

            while (true)
            {
                evernt.OnMyEvent();
                Thread.Sleep(2000);
            }
        }
        public static void Callback(object sender, EventArgs e)
        {
            Console.WriteLine("Callback FCT");
        }
    }
}
