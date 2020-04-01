using System;
using System.IO;

namespace Ex4
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Input directory path to list");
            string searchDir = Console.ReadLine();
            Console.WriteLine("Input file path");
            string printFilePath = Console.ReadLine();
            Console.WriteLine("Input line start");
            Int32.TryParse(Console.ReadLine(), out var startL);
            Console.WriteLine("Input line end");
            Int32.TryParse(Console.ReadLine(), out var endL);
            ListDirectory(searchDir);
            PrintFileAtLines(printFilePath, startL, endL);
        }


        static void ListDirectory(string directory)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(directory))
                {
                    Console.WriteLine(d);
                    foreach (string f in Directory.GetFiles(d))
                    {
                        Console.WriteLine(f);
                    }
                    ListDirectory(d);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void PrintFileAtLines(string filePath, int lStart, int lEnd)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                System.Console.WriteLine($"Contents of {filePath}:");
                if (lStart < 0 || lEnd > lines.Length || lStart > lEnd)
                {
                    Console.WriteLine("Line numbers outside range");
                }
                else
                {
                    for (int i = lStart; i < lines.Length && i <= lEnd; i++)
                    {
                        Console.WriteLine("\t" + lines[i]);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
