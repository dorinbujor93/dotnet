using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "karunya123.edu  , www.karunya.edu, www.karunya.edu,  http://karunya.edu, https://karunya.edu, www.karunyauniversity.in  ,  https://mykarunya.edu, https://www.karunya.edu  ,  google.com,  google.co.in, www.google.com,  https://www.gmail.com, gmail.com";

            Console.WriteLine("---------1.Extract all the URLs");
            var urls = text.Replace(" ", "").Split(",");
            Display(urls);
            Console.WriteLine("---------2.Display all the URLs which start with https://");
            var urls2 = urls.Where(url => url.StartsWith("https://")).ToArray();
            Display(urls2);
            Console.WriteLine("---------3.URLs ending with .edu");
            var urls3 = urls.Where(url => url.EndsWith(".edu")).ToArray();
            Display(urls3);
            Console.WriteLine("---------4.Replace all the vowels in url with given character");
            var regExVovels = @"[aeiou]";
            var urls4 = urls.Select(url => Regex.Replace(url, regExVovels, "")).ToArray();
            Display(urls4);
            Console.WriteLine("---------5.Replace all the numbers in the URL with 1 and display");
            var regExNumbers = @"[234567890]";
            var urls5 = urls.Select(url => Regex.Replace(url, regExNumbers, "1")).ToArray();
            Display(urls5);
            Console.WriteLine("---------6.Display all duplicate URLs");
            var dupes = urls.GroupBy(x => x).Where(g => g.Count() > 1).ToDictionary(x => x.Key, y => y.Count());
            foreach (var url in dupes)
            {
                Console.WriteLine($"{url.Key} appears {url.Value} times");
            }
            Console.WriteLine("---------7.Concatenate any two URLs");
            var concat = urls[0] + urls[1];
            Console.WriteLine(concat);
            Console.WriteLine("---------8.Given any URL, display last occurence of any repeating character");
            var gUrl = urls[0];
            var sDupes = new String(gUrl.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key).ToArray());
            foreach (var dupe in sDupes)
            {
                Console.WriteLine($"Last occurence of {dupe} in {gUrl} is {gUrl.LastIndexOf(dupe)}");
            }
            Console.WriteLine("---------9.Insert [URL] at the beginning of URLs");
            var urls9 = new List<string>();
            foreach (var url in urls)
            {
                urls9.Add("[URL]" + url);
            }

            Display(urls9);
            Console.WriteLine("---------10.Find out first occurence of character in given url");
            var givenUrl = urls[0];
            var searchChar = 'a';
            Console.WriteLine($"Url to search in is: {givenUrl}, character searched is: {searchChar}");
            Console.WriteLine($"First occurence of {searchChar} is at position: " + givenUrl.IndexOf(searchChar));

            Console.WriteLine("---------11.List out all the URLs with substring 'oo' in it.");
            var urls11 = urls.Where(url => url.Contains("oo")).ToArray();
            Display(urls11);
        }



        public static void Display(IEnumerable<string> urls)
        {
            foreach (var url in urls)
            {
                Console.WriteLine(url + " ");
            }
        }


    }
}
