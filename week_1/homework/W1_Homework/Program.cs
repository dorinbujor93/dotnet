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
                    case 7:
                        Ex7();
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

            //Increment count of key if already in dict, initialize with 1 if not
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
            int[] listElements = new[] { 1, 2, 3, 4, 5, 6, 7 };
            LinkedList<int> linkedList = new LinkedList<int>(listElements);

            Console.WriteLine("\nStarting List elements:");
            DispalyLinkedList(linkedList);

            //  Iterative reverse
            LinkedListNode<int> head = linkedList.First;
            while (head.Next != null)
            {
                var next = head.Next;
                linkedList.Remove(next);
                linkedList.AddFirst(next.Value);
            }
            Console.WriteLine("\nIterative reversed:");
            DispalyLinkedList(linkedList);

            //Recursive reverse
            Console.WriteLine("\nRecursive reversed:");
            RevRecursive(linkedList.First);
            DispalyLinkedList(linkedList);
        }

        static void Ex5()
        {
            int[] listElements = new[] { 11, 2, 3, 3, 12, 46, 11, 3, 9, 11, 12 };
            LinkedList<int> linkedList = new LinkedList<int>(listElements);
            DispalyLinkedList(linkedList);
            //When a HashSet is created, all duplicates are ignored
            HashSet<int> hashSet = new HashSet<int>(linkedList);

            //In case we need a linked list
            LinkedList<int> noDupesLinkedList = new LinkedList<int>(hashSet);

            DispalyLinkedList(noDupesLinkedList);
        }

        static void Ex6()
        {
            string sentence = "Given a string s consists of upper or lower case alphabets and empty space characters";
            int len = 0;

            //Count from end untill first space
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


        public static void Ex7()
        {
            //--- Arrays ---

            //2.1
            int[] newArray = new int[5];
            //2.2
            newArray[0] = 5;
            int fromArray = newArray[0];
            //2.3
            Console.WriteLine("\nArray values\n");
            foreach (int arrayVal in newArray)
            {
                Console.WriteLine(arrayVal + " ");
            }

            //--- Lists ---

            //3.1
            List<string> newList = new List<string>();
            //3.2
            newList.Add("Value1");
            newList.Add("Value2");
            newList.Add("Value3");
            newList.Add("Value4");
            newList.Add("Value5");
            string fromList = newList[0];
            //3.3
            newList.Remove("Value1");
            //3.4
            newList.RemoveAt(2);
            //3.5
            Console.WriteLine("\nList values\n");
            foreach (string listVal in newList)
            {
                Console.WriteLine(listVal + " ");
            }

            //--- Dictionaries ---

            //4.1
            Dictionary<int, int> newDictionary = new Dictionary<int, int>();
            //4.2
            newDictionary.Add(1, 2);
            newDictionary.Add(3, 4);
            newDictionary.Add(5, 6);
            newDictionary.Add(7, 8);
            int fromDictionary = newDictionary[1];
            //4.3
            newDictionary.Remove(7);
            //4.4
            Console.WriteLine("\nDictionary values\n");
            foreach (KeyValuePair<int, int> dictPair in newDictionary)
            {
                Console.WriteLine(dictPair.Key + " " + dictPair.Value);
            }

            //--- Queues ---

            //5.1
            Queue<string> newQueue = new Queue<string>();
            //5.2
            newQueue.Enqueue("Ion");
            newQueue.Enqueue("Larisa");
            newQueue.Enqueue("Horatiu");
            //5.3
            Console.WriteLine("\nQueue values\n");
            while (newQueue.Count > 0)
            {
                Console.WriteLine(newQueue.Dequeue() + " ");
            }

            //--- Stacks ---

            //6.1
            Stack<int> newStack = new Stack<int>();
            //6.2
            newStack.Push(3);
            newStack.Push(0);
            newStack.Push(1);
            //6.3
            Console.WriteLine("\nStack values\n");
            while (newStack.Count > 0)
            {
                Console.WriteLine(newStack.Pop());
            }


            //--- Linked Lists ---

            //7.1
            LinkedList<string> names = new LinkedList<string>();
            //7.2
            names.AddLast("Ion");
            names.AddFirst("Ioana");
            LinkedListNode<string> nameFromList = names.Find("Ioana");

            //7.3
            names.RemoveFirst();
            names.RemoveLast();
        }

        /*
        * Display Linked List
        * 
        */
        public static void DispalyLinkedList(LinkedList<int> lList)
        {
            foreach (int element in lList)
            {
                Console.Write(element + " ");
            }
        }


        /*
         * Reverse Linked List Recursive
         * 
         */
        static LinkedListNode<int> RevRecursive(LinkedListNode<int> current)
        {
            if (current == null || current.Next == null)
            {
                return current;
            }

            LinkedListNode<int> newNode = RevRecursive(current.Next);

            newNode.List.AddLast(current.Value);
            newNode.List.Remove(current);

            return newNode;
        }
    }
}
