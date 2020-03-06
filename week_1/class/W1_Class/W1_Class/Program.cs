using System;

namespace W1_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercise1();
            Exercise2();
        }

        static void Exercise1()
        {
            int len = 3;
            char[] chars = new char[len];

            for (int i = 0; i < len; i++)
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
        static void Exercise2()
        {
            char operation;
            int firstNr;
            int secondNr;
            int result;
            Console.WriteLine("Please insert first number: \n");
            firstNr = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please choose an operation from (+,-,*,/)\n");
            operation = Console.ReadKey().KeyChar;

            Console.WriteLine("Please insert second number: \n");
            secondNr = Convert.ToInt32(Console.ReadLine());


            switch (operation)
            {
                case '+':
                    result = firstNr + secondNr;
                    Console.WriteLine($"\n You result is: {result}" );
                    break;
                case '-':
                    result = firstNr - secondNr;
                    Console.WriteLine($"\n You result is: {result}");
                    break;
                case '*':
                    result = firstNr * secondNr;
                    Console.WriteLine($"\n You result is: {result}");
                    break;
                case '/':
                    result = firstNr / secondNr;
                    Console.WriteLine($"\n You result is: {result}");
                    break;
        
            }
        }
    }
}
