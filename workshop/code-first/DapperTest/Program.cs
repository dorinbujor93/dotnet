using System;

namespace DapperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new SpeakerRepository();
            var speakers = repository.Demo();
            Console.WriteLine("***** Speakers: ******");
            foreach (var speaker in speakers)
            {
                Console.WriteLine("Speaker information: Bio:" + speaker.Bio + " FullName:" + speaker.FullName + " WebSite:" + speaker.WebSite);
            }
            var viewResults = repository.DapperView();

            Console.WriteLine("***** Sessions: ******");
            foreach (var result in viewResults)
            {
                Console.WriteLine("Session information: Title:" + result.Title + " FullName:" + result.FullName + " StartTime:" + result.StartTime);
            }
        }
    }
}