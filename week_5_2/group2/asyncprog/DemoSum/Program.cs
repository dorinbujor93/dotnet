using System.Threading;

namespace DemoSum
{
    using System;
    using System.Diagnostics;

    internal class Program
    {
        private static int sum;

        private static void Main(string[] args)
        {
            var arraySize = 50000000; // 50 000 000
            var array = BuildAnArray(arraySize);
            int cores = Environment.ProcessorCount;

            for (int i = 0; i < cores; i++)
            {
                Thread t = new Thread(() =>
                {
                    for (int j = 0; j < arraySize / 2; j++)
                    {
                        Interlocked.Add(ref sum, array[j]);
                    }
                });

                t.Start();
            }

            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < arraySize / 2; i++)
                {
                    Interlocked.Add(ref sum, array[i]);
                }
            });

            Thread t2 = new Thread(() =>
            {
                for (int i = arraySize/2; i < arraySize ; i++)
                {
                    Interlocked.Add(ref sum, array[i]);

                }
            });


            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();


            int test = 0;
            for (int i = 0; i < arraySize; i++)
            {
                test += array[i];

            }
            Console.WriteLine($"Sum is: {sum}");
            Console.WriteLine($"Sum is: {test}");

            var stopwatch = Stopwatch.StartNew();

            var arrayProcessor = new ArrayProcessor(array, 0, arraySize);

            arrayProcessor.CalculateSum();
            var totalSum = arrayProcessor.Sum;

            stopwatch.Stop();

            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine($"Sum: {totalSum}");
        }

        public static int[] BuildAnArray(int size)
        {
            var array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            return array;
        }
    }
}
