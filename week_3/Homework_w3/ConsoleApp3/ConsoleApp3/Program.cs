
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

            dynamic sum = L.Sum();

            dynamic average = L.Average();
            dynamic product = L.Product();
            dynamic min = L.Min();
            dynamic max = L.Max();
            DisplayList(L);


            Console.WriteLine();
            Console.WriteLine(sum);
            Console.WriteLine(average);
            Console.WriteLine(product);
            Console.WriteLine(min);
            Console.WriteLine(max);

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