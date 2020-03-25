
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> L = new List<int>() { 1, 2, 3, 4, 5, 11, 12, 13, 14, 15 };
            DisplayList(L);


            Console.WriteLine();
            Console.WriteLine(L.Sum());
            Console.WriteLine(L.Average());
            Console.WriteLine(L.Product());
            Console.WriteLine(L.Max());
                
        }
        static void DisplayList(List<int> list)
        {
            foreach (int v in list)
            {
                Console.Write(v + " ");

            }
        }
    }
}