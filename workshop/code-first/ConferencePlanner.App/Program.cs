using ConferencePlanner.Data.Entities;

namespace ConferencePlanner.App
{
    using System;
    using System.Linq;
    using Data;
    using Microsoft.EntityFrameworkCore;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // OnConfiguring we have connection string 
            // Migrations created with: dotnet ef migrations add MigrationName
            // Migrations were run with: dotnet ef database update
            using var context = new ApplicationDbContext();

            Ex06.Run(context);
        }
    }

    internal class Ex01
    {
        public static void Run(ApplicationDbContext context)
        {
            // write a simple query to validate ApplicationDbContext
            var a = context.Attendees.Add(new Attendee
            {
                FirstName = "Sanda",
                LastName = "Ioan",
                UserName = "SandaUSR",
                EmailAddress = "Test@tt.com"
            });
            context.Tracks.Add(new Track { Name = "Track" });
            context.SaveChanges();
        }
    }

    internal class Ex02
    {
        public static void Run(ApplicationDbContext context)
        {
            // on Tracks table, add PHP, C# tracks with a seed
            // update ApplicationDbContext to run a seed
        }
    }

    internal class Ex03
    {
        public static void Run(ApplicationDbContext context)
        {
            // Todo
            // on Attendee model, add a new property, date of birth
            // add a migration, run the migration
            // insert then read a Attendee
            var attendee = context.Attendees.Add(new Attendee
            {
                FirstName = "Alex",
                LastName = "Sstest",
                UserName = "alexUSR",
                EmailAddress = "alex@mail.com",
                DateOfBirth = DateTime.Now
            });
        }
    }

    internal class Ex04
    {
        public static void Run(ApplicationDbContext context)
        {

            var repo = new GenericRepo<Attendee>(context);
            var atendee1 = repo.Get(1);

            var repo2 = new GenericRepo<Track>(context);
            var tracks = repo2.Get();

        }
    }

    internal class Ex05
    {
        // todo
        // rename the Speaker.Name to Speaker.FullName
        // you should add a migration

        //An operation was scaffolded that may result in the loss of data. Please review the migration for accuracy.
    }

    internal class Ex06
    {
        public static void Run(ApplicationDbContext context)
        {
            // all Sessions that title contains ".NET" on query results using Repository
            var netTitle = context.Sessions.Where(t => t.Title.Contains(".Net")).ToList();

            // number of sessions for each speaker using direct context
            var session = context.SessionSpeaker
                .GroupBy(sessionSpeaker => sessionSpeaker.SpeakerId)
                .Select(sessionSpeakers => new {
                    Id = sessionSpeakers.Key,
                    Count = sessionSpeakers.Count()
                })
                .ToList();

            // number of tracks per session

            // all tracks for each session
        }
    }

    internal class Ex07
    {
        public static void Run(ApplicationDbContext context)
        {
            // get all sessions for one speaker
            var speakerWithSessions = context.Speakers.Include(c => c.SessionSpeakers).ToList();
        }
    }

    internal class Ex08
    {
        public static void Run()
        {
    
            // create a separate project for dapper
            // implement the ISpeakerRepository using dapper
        }
    }

    internal class Ex09
    {
        public static void Run()
        {
            // create view
            /*
               create view AllSessionsAndSpeakersView as
               select ses.Title, sp.Name, ses.StartTime from Sessions ses
               join SessionSpeaker ss on ses.Id = ss.SessionId
               join Speakers sp on sp.Id = ss.SpeakerId
            */

            // use the view from Dapper
            // display all information at console
        }
    }

    internal class Ex10
    {
        public static void Run()
        {
            // todo
            // use Dapper Plus
            // bulk insert 10 attendees
        }
    }
}
