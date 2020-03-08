using System;
using System.Collections.Generic;

namespace W1_Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert exercise number \n");
            if (int.TryParse(Console.ReadLine(), out int exNumber))
            {
                switch (exNumber)
                {
                    case 1:
                        Ex1();
                        break;
                    case 2:
                        Ex1();
                        break;
                    case 3:
                        Ex1();
                        break;
                    case 4:
                        Ex1();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Wrong exercise number!");
            }
        }

        static void Ex1()
        {
            Console.WriteLine("Please input a string:\n");
            string withDuplicates = Console.ReadLine();
            string noDuplicates = string.Empty;

            //simple way
            for (int i = 0; i < withDuplicates.Length; i++)
            {
                if (!noDuplicates.Contains(withDuplicates[i]))
                {
                    noDuplicates += withDuplicates[i];
                }
            }
            Console.WriteLine($"Simple No duplicates: {noDuplicates}");

            //using hashset
            string hsNoDuplicates = string.Empty;
            var unique = new HashSet<char>(withDuplicates);
            foreach (char ch in unique)
            {
                hsNoDuplicates += ch;
            }
            Console.WriteLine($"\nHashSet No duplicates: {hsNoDuplicates}");
        }
    }
}
