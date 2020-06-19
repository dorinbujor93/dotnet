using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EX4
{
    class Program
    {
        static void Main(string[] args)
        {

            var wordProcessor = new WordProcessor();
            Console.WriteLine($"Distinct words: {wordProcessor.DistinctWords.Count()}");
            Console.WriteLine($"Total words: {wordProcessor.WordCount}");

            Console.WriteLine("Grouped words stats:");
            foreach (var (key, value) in wordProcessor.WordsBySize)
            {
                Console.WriteLine($"{value.Count()} words of size {key}");
            }

            Console.WriteLine("Please insert word to search ");
            var exists = wordProcessor.DistinctWords.ContainsKey(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine(exists ? "Found!" : "Not found!");
        }
    }
}