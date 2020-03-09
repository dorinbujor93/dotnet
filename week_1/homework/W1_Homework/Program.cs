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
                        Ex4();
                        break;
                    case 5:
                        Ex5();
                        break;
                    case 6:
                        Ex6();
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

            foreach (char ch in toCountString)
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
            foreach (var chToCnt in charCount)
            {
                Console.WriteLine($"{chToCnt.Key} | {chToCnt.Value}");
            }

        }

        static void Ex4()
        {
            int[] listElements = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            LinkedList<int> linkedList = new LinkedList<int>(listElements);
            DispalyLinkedList(linkedList);
            LinkedListNode<int> head = linkedList.First;

            while (head.Next != null)
            {
                var next = head.Next;
                linkedList.Remove(next);
                linkedList.AddFirst(next.Value);
            }

            DispalyLinkedList(linkedList);

        }


     
        static void Ex5()
        {
            int[] listElements = new[] { 11, 2, 3, 3, 12, 46, 11, 3, 9, 11, 12 };
            LinkedList<int> linkedList = new LinkedList<int>(listElements);
            DispalyLinkedList(linkedList);
            HashSet<int> hashSet = new HashSet<int>(linkedList);

            //In case we need a linked list
            LinkedList<int> noDupesLinkedList = new LinkedList<int>(hashSet);

            DispalyLinkedList(noDupesLinkedList);
        }

        static void Ex6()
        {
            string sentence = "Given a string s consists of upper or lower case alphabets and empty space characters";
            int len = 0;

            for (int i = sentence.Length - 1; i >= 0; i--)
            {
                if (sentence[i] != ' ')
                {
                    len++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine($"Last word in string: \n{sentence}\n - is {len} characters long \n");
        }

        //Fct
        public static void DispalyLinkedList(LinkedList<int> lList)
        {
            Console.WriteLine("\nLinked List elements:");
            foreach (int element in lList)
            {
                Console.Write(element + " ");
            }
        }
    }
}
