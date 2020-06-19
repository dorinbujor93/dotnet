using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EX2
{
    public class Post
    {
        public int UserId;
        public int Id;
        public string Title;
        public string Body;
        public static List<Post> AvailablePosts = new List<Post>();
        private static readonly object Locker = new object();

        public static async Task GetPosts()
        {
            try
            {
                var client = new HttpClient();
                var responseBody = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
                lock (Locker)
                {
                    AvailablePosts = JsonConvert.DeserializeObject<List<Post>>(responseBody);
                }
            }

            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}