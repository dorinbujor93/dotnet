using System;

namespace W1_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            int len = 3;
            char[] chars = new char[len];

            for(int i =0; i<len; i++)
            {
                Console.WriteLine("\nInsert a letter:  ");

                chars[len - i - 1] = Console.ReadKey().KeyChar;
            }

            Console.WriteLine("\n Reversed: \n");
            for (int i = 0; i < len; i++)
            {
                Console.WriteLine(chars[i]);
            }
        }
    }
}
