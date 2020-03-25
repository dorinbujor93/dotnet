using System;

namespace Ex6
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray64 testArray64 = new BitArray64(16);
            
            
            // Display my ARR before change 
            foreach (var bit in testArray64)
            {
                Console.Write(bit + " ");
            }
            Console.WriteLine();

            //Make first bit  1 (transform 16 into 17)
            testArray64[0] = 1;

            // Display my ARR after change 
            foreach (var bit in testArray64)
            {
                Console.Write(bit + " ");
            }

            Console.WriteLine();

            //Display Hash
            Console.WriteLine(testArray64.GetHashCode());
            //Check unchanged bits
            Boolean equalUnchanged = testArray64[3] == testArray64[2];
            Console.WriteLine(equalUnchanged);
            //Check changed bits
            Boolean equalAfterChange = testArray64[0] == testArray64[1];
            Console.WriteLine(equalAfterChange);
            //Compare Arrays(should be false)
            Boolean inequal = testArray64.Equals(new BitArray64(49998));
            Console.WriteLine(inequal);
            //Compare Arrays(should be true)
            Boolean equal = testArray64.Equals(new BitArray64(17));
            Console.WriteLine(equal);

        }
    }
}