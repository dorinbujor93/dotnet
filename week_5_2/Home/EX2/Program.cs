using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EX2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var posts = new PostsManager();
            await Post.GetPosts();

            Comment.GetAllComments(Post.AvailablePosts);

            Console.WriteLine($"Posts retrieved: {Post.AvailablePosts.Count}");
            Console.WriteLine($"Comments retrieved: {Comment.AvailableComments.Count}");
        }
    }
}