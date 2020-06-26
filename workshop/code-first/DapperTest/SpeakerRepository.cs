using Dapper;
using System.Collections.Generic;
using System.Linq;
using ConferencePlanner.Entities;
using Microsoft.Data.SqlClient;
using Speaker = ConferencePlanner.Data.Entities.Speaker;

namespace DapperTest
{
    public class SpeakerRepository
    {
        private string sqlConnectionString = @"data source =.\SQLExpress; database = ConferencePlanner; integrated security = SSPI";
        public List<AllSessionsAndSpeakersView> DapperView()
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                var sessionsAndSpeakers = new AllSessionsAndSpeakersView();
                return connection.Query<AllSessionsAndSpeakersView>("select * from AllSessionsAndSpeakersView", new { sessionsAndSpeakers = sessionsAndSpeakers }).AsList();

            }
        }
        public List<Speaker> Demo()
        {
            var sqlSelect = "SELECT * FROM Speakers WHERE Id = @id;";
            var sqlInsert = "INSERT INTO Speakers (Bio, WebSite, FullName) Values (@Bio, @WebSite, @FullName);";

            using (var con = new SqlConnection(sqlConnectionString))
            {
                con.QueryFirstOrDefault(sqlSelect, new { id = 1 });
                con.Execute(sqlInsert, new Speaker { Bio = "Test speaker", WebSite = "speakersite.com", FullName = "Speaking Speaker" });

                return con.Query<Speaker>("select * from Speakers").ToList();
            }
        }

    }
}