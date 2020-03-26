using System;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            var testTime = new Clock("12 01 2020");
            Console.WriteLine(testTime.Today.ToString());
        }
    }
}
