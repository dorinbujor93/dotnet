using System;
using System.Linq;

namespace ConsoleApp4
{
    internal class Program
    {
        public static readonly int[] Numbers = new int[10];
        private static void Main(string[] args)
        {

            int rangeStart = 0;
            int rangeEnd = 13;
            Console.WriteLine("Please insert a number");
            int numberToVerify = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            if (numberToVerify < rangeStart || numberToVerify > rangeEnd)
            {
                throw new InvalidRangeException<int>("You are outside the range", 0, 13);
            }
            else
            {
                Console.WriteLine("Your int was within the range!");
            }

            Console.WriteLine("Please insert a date to verify");
            DateTime dateToVerify = DateTime.Parse(Console.ReadLine());
            DateTime rStart = DateTime.Parse("01.01.2000");
            DateTime rEnd = DateTime.Now;

            if (dateToVerify < rStart || dateToVerify > rEnd)
            {
                throw new InvalidRangeException<DateTime>("You have introduced a date which is outside the range!", rStart, rEnd);
            }
            else
            {
                Console.WriteLine("Your date was within the range!");
            }



            //--------------------------- EX 5---------------------


            try
            {
                Console.WriteLine($"Please insert 10 numbers between {rangeStart} and {rangeEnd}");
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine($"Number: {i}");
                    int nr = GetUserNumber(rangeStart, rangeEnd);
                    SaveUserNumber(nr, i);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Your input is not an int!");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Please make sure your nr fits into an integer!");
                return;
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            DisplayUserNumbers();

        }
        public static int GetUserNumber(int rStart, int rEnd)
        {
            int nr = int.Parse(Console.ReadLine());

            if (nr < rStart || nr > rEnd)
            {
                throw new InvalidRangeException<int>("You are outside the range", rStart, rEnd);
            }

            return nr;
        }

        static void SaveUserNumber(int nr, int pos)
        {
            if (pos - 1 > 0 && Numbers[pos - 2] > nr)
            {
                throw new Exception("The inequality is false");
            }

            Numbers[pos - 1] = nr;
        }

        public static void DisplayUserNumbers()
        {
            var message = Numbers.Aggregate("", (current, nr) => current + (nr + " < "));

            Console.WriteLine("\n" + message);
        }


    }
}