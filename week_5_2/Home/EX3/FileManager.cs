using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EX3
{
    class FileManager
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim( 4);
        private readonly object padlock = new object();
        List<string> processed = new List<string>();

        public async Task Consume(string fullPath)
        {
            Console.WriteLine($"@@@ Thread with id: {Thread.CurrentThread.ManagedThreadId} waiting! @@@");

            _semaphore.Wait();  
            Console.WriteLine($">>>Thread with id: {Thread.CurrentThread.ManagedThreadId} inside sem>>>");
            try
            {
                await Task.Delay(3000);
                Process(fullPath);
            }
            finally
            {
                _semaphore.Release();
            }

            lock (padlock)
            {
                if (processed.Count >= 10)
                {
                    Display();
                }
            }
        }

        private void Process(string fullPath)
        {
            string text = File.ReadAllText(fullPath);
            lock (padlock)
            {
                processed.Add(text);
                Console.WriteLine("!!! Processed by Thread with id: " + Thread.CurrentThread.ManagedThreadId + " !!!");
            }
        }

        private void Display()
        {
            foreach (var item in processed)
            {
                Console.WriteLine(item);
            }
            processed.Clear();
        }

        public void Run()
        {
            // Create a new FileSystemWatcher and set its properties.
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = "D:\\Learning\\dotnet\\week_5_2\\Home\\EX3\\Files";

                // Watch for changes in LastAccess and LastWrite times, and
                // the renaming of files or directories.
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                       | NotifyFilters.LastWrite
                                       | NotifyFilters.FileName
                                       | NotifyFilters.DirectoryName;

                // Only watch text files.
                watcher.Filter = "*.txt";

                // Add event handlers.
                watcher.Created += OnChanged;

                // Begin watching.
                watcher.EnableRaisingEvents = true;

                // Wait for the user to quit the program.
                Console.WriteLine("Press 'q' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
        }

        // Define the event handlers.
        private async void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("************* FILE CONTENTS ***************");
             await Consume(e.FullPath);
        }
    }
}