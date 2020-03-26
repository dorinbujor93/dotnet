namespace LinqAndLamdaExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<User> allUsers = ReadUsers("users.json");
            List<Post> allPosts = ReadPosts("posts.json");

            #region Demo

            // 1 - find all users having email ending with ".net".
            var users1 = from user in allUsers
                         where user.Email.EndsWith(".net")
                         select user;

            var users11 = allUsers.Where(user => user.Email.EndsWith(".net"));

            IEnumerable<string> userNames = from user in allUsers
                                            select user.Name;

            var userNames2 = allUsers.Select(user => user.Name);

            foreach (var value in userNames2)
            {
                Console.WriteLine(value);
            }

            IEnumerable<Company> allCompanies = from user in allUsers
                                                select user.Company;

            var users2 = from user in allUsers
                         orderby user.Email
                         select user;

            var netUser = allUsers.First(user => user.Email.Contains(".net"));
            Console.WriteLine(netUser.Username);

            #endregion

            // 2 - find all posts for users having email ending with ".net".
            IEnumerable<int> usersIdsWithDotNetMails = from user in allUsers
                                                       where user.Email.EndsWith(".net")
                                                       select user.Id;

            IEnumerable<Post> posts = from post in allPosts
                                      where usersIdsWithDotNetMails.Contains(post.UserId)
                                      select post;

            foreach (var post in posts)
            {
                Console.WriteLine(post.Id + " " + "user: " + post.UserId);
            }

            Console.WriteLine("------------------EX3------------");


            // 3 - print number of posts for each user.

            var postsByUser = allPosts.GroupBy(c => c.UserId)
                .Select(counter => new { xUser = allUsers.First(usr => usr.Id == counter.Key), postsCnt = counter.Count() });


            foreach (var userPosts in postsByUser)
            {
                Console.WriteLine("username: " + userPosts.xUser.Name + "| posts: " + userPosts.postsCnt);
            }


            Console.WriteLine("------------------EX4------------");

            // 4 - find all users that have lat and long negative.
            var nLatLongUsr = allUsers.Where(user => user.Address.Geo.Lat < 0 && user.Address.Geo.Lng < 0);
            foreach (var users in nLatLongUsr)
            {
                Console.WriteLine("userId: " + users.Id + " name: " + users.Name + " Lat: " + users.Address.Geo.Lat + " Lng: " + users.Address.Geo.Lng);
            }

            Console.WriteLine("------------------EX5------------");

            // 5 - find the post with longest body.
            var longestPost = allPosts.Select(post => new { postId = post.Id, postLen = post.Body.Length, post.UserId }).OrderBy(item => item.postLen).Last();
            Console.WriteLine("The longest post is:  " + longestPost.postId + "   " + longestPost.postLen);


            Console.WriteLine("------------------EX6------------");
            // 6 - print the name of the employee that have post with longest body.
            var longestPostUserName = allUsers.First(user => user.Id == longestPost.UserId);
            Console.WriteLine("The user with longest post is:  " + longestPostUserName.Name);

            Console.WriteLine("------------------EX7------------");
            // 7 - select all addresses in a new List<Address>. print the list.
            List<Address> addresses = allUsers.Select(user => user.Address).ToList();
            foreach (var address in addresses)
            {
                Console.WriteLine("City: " + address.City + " | Zip: " + address.Zipcode + " | Street " + address.Street);
            }

            Console.WriteLine("------------------EX7------------");
            // 8 - print the user with min lat
            var minLatUsr = allUsers.Select(user => new { userName = user.Name, latitude = user.Address.Geo.Lat }).OrderBy(item => item.latitude).First();

            Console.WriteLine(minLatUsr.userName + " latitude: " + minLatUsr.latitude);


            Console.WriteLine("------------------EX8------------");
            // 9 - print the user with max long
            var maxLongUsr = allUsers.Select(user => new { userName = user.Name, longitude = user.Address.Geo.Lng }).OrderBy(item => item.longitude).Last();
            Console.WriteLine(maxLongUsr.userName + " longitude: " + maxLongUsr.longitude);


            // 10 - create a new class: public class UserPosts { public User User {get; set}; public List<Post> Posts {get; set} }
            //    - create a new list: List<UserPosts>
            //    - insert in this list each user with his posts only
            List<UserPosts> usersAndPost = new List<UserPosts>();
            foreach (var user in allUsers)
            {
                var currentUserPosts = allPosts.Where(p => p.UserId == user.Id).ToList();
                var userWithPosts = new UserPosts { Posts = currentUserPosts, User = user };
                usersAndPost.Add(userWithPosts);
            }

            Console.WriteLine("------------------EX11------------");
            // 11 - order users by zip code
            var zipOrderedUsers = allUsers.OrderBy(item => item.Address.Zipcode);

            foreach (var user in zipOrderedUsers)
            {
                Console.WriteLine("userId: " + user.Id + " name: " + user.Name + " Zip: " + user.Address.Zipcode);
            }

            Console.WriteLine(maxLongUsr.userName + " longitude: " + maxLongUsr.longitude);

            Console.WriteLine("------------------EX12------------");
            // 12 - order users by number of posts

            var sortedByPostsNr = postsByUser.OrderBy(elem => elem.postsCnt);
            foreach (var sorted in sortedByPostsNr)
            {
                Console.WriteLine("username: " + sorted.xUser.Name + "| posts: " + sorted.postsCnt);
            }
        }

        public class UserPosts
        {
            public User User { get; set; }
            public List<Post> Posts { get; set; }
        }
        private static List<Post> ReadPosts(string file)
        {
            return ReadData.ReadFrom<Post>(file);
        }

        private static List<User> ReadUsers(string file)
        {
            return ReadData.ReadFrom<User>(file);
        }
    }
}
