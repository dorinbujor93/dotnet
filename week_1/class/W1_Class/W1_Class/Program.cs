using System;

namespace W1_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercise1();
            //Exercise2();
            // Exercise3();
            //Exercise5(); 
            //Exercise6();
            Exercise7();
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
            double result;
            Console.WriteLine("Please insert first number: \n");
            firstNr = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please choose an operation from (+,-,*,/)\n");
            operation = Console.ReadKey().KeyChar;

            Console.WriteLine("\nPlease insert second number: \n");
            secondNr = Convert.ToInt32(Console.ReadLine());


            switch (operation)
            {
                case '+':
                    result = firstNr + secondNr;
                    Console.WriteLine($"\n You result is: {result}");
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
                    result = (double)firstNr / secondNr;
                    Console.WriteLine($"\n You result is: {result}");
                    break;

            }
        }

        static void Exercise3()
        {
            char character;
            string vovels = "aeiou";
            string digit = "1234567890";
            Console.WriteLine("Please insert a character \n");
            character = Console.ReadKey().KeyChar;

            if (vovels.IndexOf(character) >= 0)
            {
                Console.WriteLine(" - It's a lowercase vowel \n");
            }
            else if (digit.IndexOf(character) >= 0)
            {
                Console.WriteLine(" - It's a digit \n");
            }
            else
            {
                Console.WriteLine(" - It's something else! \n");
            }
        }

        static void Exercise4()
        {
            int height;
            height = Convert.ToInt32(Console.ReadLine());

            if (height <= 140)
            {
                Console.WriteLine("The person is Dwarf. \n");
            }
            else if (height <= 180)
            {
                Console.WriteLine("The person is normal. \n");
            }
            else
            {
                Console.WriteLine("The person is pretty high. \n");
            }
        }
        static void Exercise5()
        {
            int a, b, c;
            Console.WriteLine("Insert edge A lenght: \n");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert edge B lenght: \n");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert edge C lenght: \n");
            c = Convert.ToInt32(Console.ReadLine());


            if (a == b && b == c)
            {
                Console.WriteLine("\n This triangle is Equilateral!");
            }
            else if (a == b || a == c || b == c)
            {
                Console.WriteLine("\n This triangle is Isosceles!");
            }
            else
            {
                Console.WriteLine("\n This triangle is Scalene!");
            }
        }

        static void Exercise6()
        {
            int termsNumber;
            int even = 0;
            int sum = 0;
            Console.WriteLine("Please input number of terms!\n");
            termsNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("The even numbers are: ");
            for (int i = 0; i < termsNumber; i++)
            {
                even += 2;
                sum += even;
                Console.Write($"{even} ");
            }
            Console.WriteLine($"\nThe Sum of even Natural Number up to {termsNumber} terms: {sum}");
        }

        static void Exercise7()
        {

            Console.WriteLine("Please insert outside temp \n");

            bool isTemp = int.TryParse(Console.ReadLine(), out int temperature);
            if (isTemp)
            {
                if (temperature < 0)
                {
                    Console.WriteLine("Freezing!");
                }
                else if (temperature <= 10)
                {
                    Console.WriteLine("Very Cold weather!");
                }
                else if (temperature <= 20)
                {
                    Console.WriteLine("Cold weather!");
                }
                else if (temperature <= 30)
                {
                    Console.WriteLine("Normal weather!");
                }
                else if (temperature <= 40)
                {
                    Console.WriteLine("Its Hot!");
                }
                else
                {
                    Console.WriteLine("Its Very Hot!");
                }
            }
            else
            {
                Console.WriteLine("Something went wrong!");

            }
        }

        static void Exercise8()
        {

        }
    }
}