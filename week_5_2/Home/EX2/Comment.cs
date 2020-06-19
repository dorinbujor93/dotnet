using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EX2
{
    public class Comment
    {
        public int PostId;
        public int Id;
        public string Name;
        public string Email;
        public string Body;
        public static Dictionary<int, List<Comment>> AvailableComments = new Dictionary<int, List<Comment>>();
        private static readonly object Locker = new object();


        public static void GetAllComments(List<Post> availablePosts)
        {
            var tasks = new List<Task>();

            foreach (var post in availablePosts)
            {
                tasks.Add(GetPostComments(post.Id));
            }
            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException e)
            {
                foreach (var t in e.InnerExceptions)
                {
                    Console.WriteLine($"\n---\n{t.ToString()}");
                }
            }
        }


        public static async Task GetPostComments(int postId)
        {

             var Client = new HttpClient();
            try
            {
                var responseBody = await Client.GetStringAsync("https://jsonplaceholder.typicode.com/comments?postId=" + postId);
                var comments = JsonConvert.DeserializeObject<List<Comment>>(responseBody);
                lock (Locker)
                {
                    AvailableComments.Add(postId, comments);
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
