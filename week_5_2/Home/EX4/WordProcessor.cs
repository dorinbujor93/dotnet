using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EX4
{
    class WordProcessor
    {
        private static readonly object Locker = new object();
        private const string FilesLocation = "D:\\Learning\\dotnet\\week_5_2\\Home\\EX4\\Files";
        public int WordCount;
        private List<string> datList = new List<string>();
        public List<string> FilesData = new List<string>();
        public Dictionary<string, string> DistinctWords = new Dictionary<string, string>();
        public Dictionary<string, List<string>> WordsBySize = new Dictionary<string, List<string>>();


        public WordProcessor()
        {
            Init();
        }

        private void Init()
        {
            var dir = new DirectoryInfo(FilesLocation);
            var datFiles = dir.GetFiles("*.dat");

            foreach (var file in datFiles)
            {
                datList.Add(file.Name);
            }

            WordsBySize.Add("xs", new List<string>());
            WordsBySize.Add("s", new List<string>());
            WordsBySize.Add("m", new List<string>());
            WordsBySize.Add("l", new List<string>());

            ProcessFiles();
        }


        public void ProcessFiles()
        {
            Task.WaitAll(datList.Select(file => Task.Factory.StartNew(() => { ProcessFile(file); })).ToArray());
        }


        public void ProcessFile(string fileName)
        {
            Console.WriteLine($"File: {fileName} processed by thread with id: {Thread.CurrentThread.ManagedThreadId}");

            var lines = File.ReadAllLines(FilesLocation + "\\" + fileName);

            lock (Locker)
            {
                foreach (var line in lines)
                {
                    FilesData.Add(line);
                    DistinctWords[line] = line;
                }

                foreach (var word in lines)
                {
                    if (word.Length <= 5)
                    {
                        WordsBySize["xs"].Add(word);
                    }
                    else if (word.Length <= 10)
                    {
                        WordsBySize["s"].Add(word);
                    }
                    else if (word.Length <= 15)
                    {
                        WordsBySize["m"].Add(word);
                    }
                    else
                    {
                        WordsBySize["l"].Add(word);
                    }
                }
            }

            WordCount += lines.Length;
        }
    }
}