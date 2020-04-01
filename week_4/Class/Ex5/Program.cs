using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex5
{
    class Program
    {
        static void Main(string[] args)
        {
            var checker = new SmoothChecker();
            
            string smoothSentence = "She eats super righteously";
            string sentence = "Carla swam masterfully.";

            Console.WriteLine(checker.IsSmooth(smoothSentence));
            Console.WriteLine(checker.IsSmooth(sentence));


        }

    }
}
