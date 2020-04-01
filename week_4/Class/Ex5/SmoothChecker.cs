using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex5
{
    public class SmoothChecker
    {
        public bool IsSmooth(string sentence)
        {
            bool isSmooth = true;

            var words = sentence.Replace(".", "").Split(" ");

            for (int i = 0; i < words.Length - 1; i++)
            {
                var startsWith = words[i+1].First();
                var endsWith = words[i].Last();
                if (endsWith != startsWith)
                {
                    isSmooth = false;
                }
            }

            return isSmooth;
        }
    }
}
