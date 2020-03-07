using System;

namespace W1_Class
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
                        Exercise1();
                        break;
                    case 2:
                        Exercise2();
                        break;
                    case 3:
                        Exercise3();
                        break;
                    case 4:
                        Exercise4();
                        break;
                    case 5:
                        Exercise5();
                        break;
                    case 6:
                        Exercise6();
                        break;
                    case 7:
                        Exercise7();
                        break;
                    case 8:
                        Exercise8();
                        break;
                    case 9:
                        Exercise9();
                        break;
                    case 10:
                        Exercise10();
                        break;
                    case 11:
                        Exercise11();
                        break;
                    case 12:
                        Exercise12();
                        break;
                    case 13:
                        Exercise12();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Wrong exercise number!");
            }
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
            bool surcharge = false;
            decimal charge;

            Console.WriteLine("Please input customer name\n");
            string customerName = Console.ReadLine();
            Console.WriteLine("Please input customer IDNO\n");
            bool isId = int.TryParse(Console.ReadLine(), out int customerId);
            Console.WriteLine("Please input ammount consumed\n");
            bool isConsumedUnit = int.TryParse(Console.ReadLine(), out int consumedUnits);
            if (isId && isConsumedUnit && consumedUnits > 0)
            {
                if (consumedUnits < 200)
                {
                    charge = 1.2m;
                }
                else if (consumedUnits < 400)
                {
                    charge = 1.5m;

                }
                else if (consumedUnits < 600)
                {
                    charge = 1.8m;
                    surcharge = true;
                }
                else
                {
                    charge = 2m;
                    surcharge = true;
                }
                decimal chargesAmt = consumedUnits * charge;
                decimal surchargeAmt = surcharge ? chargesAmt * 0.15m : 0;
                decimal paidAmt = chargesAmt + surchargeAmt;

                Console.WriteLine($"Customer IDNO: {customerId}\n");
                Console.WriteLine($"Customer Name: {customerName}\n");
                Console.WriteLine($"Units Consumed: {consumedUnits}\n");
                Console.WriteLine($"Amount Charges @Rs. {String.Format("{0:N2}", charge)} per unit: {String.Format("{0:N2}", chargesAmt)}\n");
                Console.WriteLine($"Surcharge ammount: {String.Format("{0:N2}", surchargeAmt)}\n");
                Console.WriteLine($"Net Amount Paid By the Customer: {String.Format("{0:N2}", paidAmt)}\n");
            }
            else
            {
                Console.WriteLine("Data format is wrong!\n");
            }
        }

        static void Exercise9()
        {
            Console.WriteLine("How many Fibonacci series numbers you want to display?\n");
            if (int.TryParse(Console.ReadLine(), out int fibNrCount))
            {
                int term1 = 0;
                int term2 = 1;
                int nextterm;
                for (int i = 0; i < fibNrCount; i++)
                {
                    Console.Write($"{term1} ");
                    nextterm = term1 + term2;
                    term1 = term2;
                    term2 = nextterm;
                }
            }
            else
            {
                Console.WriteLine("Data format is wrong!\n");

            }
        }


        static void Exercise10()
        {
            Console.WriteLine("How many rows you want to display?\n");
            if (int.TryParse(Console.ReadLine(), out int rowsCount))
            {
                for (int i = 1; i <= rowsCount; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        Console.Write(j + " ");
                    }
                    for (int j = i - 1; j > 0; j--)
                    {
                        Console.Write(j + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Data format is wrong!\n");
            }
        }
        static void Exercise11()
        {
            int[] valuesArr = new int[] { 4, 5, 63, 5, 3, 3, 4, 6, 7, 87, 5, 4, 3, 2, 5, 7, 8 };
            int[] freq = new int[valuesArr.Length];
            int visited = -1;
            for (int i = 0; i < valuesArr.Length; i++)
            {
                int cnt = 1;
                for (int j = i + 1; j < valuesArr.Length; j++)
                {
                    if (valuesArr[i] == valuesArr[j])
                    {
                        cnt++;
                        freq[j] = visited;
                    }
                }
                if (freq[i] != visited)
                {
                    freq[i] = cnt;
                }
            }
            Console.WriteLine("Elements count:");
            for (int i = 0; i < valuesArr.Length; i++)
            {
                if (freq[i] != -1)
                {
                    Console.Write(" (" + valuesArr[i] + " -> " + freq[i] + ") ");
                }
            }

        }

        static void Exercise12()
        {
            Console.WriteLine("Input the size of the array (positive integer)");
            if (int.TryParse(Console.ReadLine(), out int arrSize) && arrSize > 0)
            {
                Console.WriteLine($"Input {arrSize} elements in the array in ascending order:\n");
                int element;
                int[] initialArr = new int[arrSize];

                for (int i = 0; i < arrSize; i++)
                {
                    Console.WriteLine($"Element - {i}:");
                    if (int.TryParse(Console.ReadLine(), out element))
                    {
                        initialArr[i] = element;
                    }
                    else
                    {
                        throw new Exception("You are dumb!");
                    }
                }

                Console.WriteLine("Input the value to be inserted\n");
                bool isValue = int.TryParse(Console.ReadLine(), out int newElement);
                Console.WriteLine("Input the position to be inserted at\n");
                bool isPosition = int.TryParse(Console.ReadLine(), out int position);
                if (isValue && isPosition)
                {
                    int[] newArr = new int[arrSize + 1];
                    for (int i = 0; i < arrSize + 1; i++)
                    {
                        if (i < position -1)
                        {
                            newArr[i] = initialArr[i];
                        }
                        else if (i == position - 1)
                        {
                            newArr[i] = newElement;
                        }
                        else
                        {
                            newArr[i] = initialArr[i - 1];
                        }
                    }
                    Console.WriteLine("Initial Array: ");
                    for (int i = 0; i < initialArr.Length; i++)
                    {
                        Console.Write(initialArr[i] + " ");
                    }
                    Console.WriteLine("\nUpdated Array: ");
                    for (int i = 0; i < newArr.Length; i++)
                    {
                        Console.Write(newArr[i] + " ");
                    }

                }
                else
                {
                    throw new Exception("Wrong data format!");
                }
            }
            else
            {
                Console.WriteLine("Wrong data format!");
            }
        }

    }
}