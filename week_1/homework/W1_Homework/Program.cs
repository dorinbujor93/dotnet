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
                        Ex2();
                        break;
                    case 3:
                        Ex3();
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

        static void Ex2()
        {
            int[] unsortedArr = new int[] { 1, 4, 5, 6, 75, 5, 5, 6, 5, 5, 5, 2, 4, 5, 5, 5 };
            Console.WriteLine("This is the unsorted array:");
            foreach (int i in unsortedArr)
            {
                Console.Write(i + " ");
            }

            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < unsortedArr.Length; i++)
            {
                if (dict.ContainsKey(unsortedArr[i]))
                {
                    int cnt = dict[unsortedArr[i]] + 1;
                    if (cnt > unsortedArr.Length / 2)
                    {
                        Console.WriteLine($"\nElement with more than 50% appearences is: {unsortedArr[i]}");
                        return;
                    }
                    else
                    {
                        dict[unsortedArr[i]] = cnt;
                    }
                }
                else
                {
                    dict[unsortedArr[i]] = 1;
                }
            }
            Console.WriteLine("\nThere is no element with more than 50% appearences!");
        }

        static void Ex3()
        {
            Console.WriteLine("Please input a string for char counting:\n");
            string toCountString = Console.ReadLine();
            var charCount = new Dictionary<char, int>();

            foreach(char ch in toCountString)
            {
                if (charCount.ContainsKey(ch))
                {
                    charCount[ch] += 1;
                }
                else
                {
                    charCount[ch] = 1;
                }
            }
            Console.WriteLine("Character | Count \n");
            foreach(var chToCnt in charCount)
            {
                Console.WriteLine($"{chToCnt.Key} | {chToCnt.Value}");
            }

        }
    }
}
