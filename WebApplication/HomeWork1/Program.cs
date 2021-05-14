using HomeWork1;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;

namespace WebApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var tasks = postsIds.Select(postsIds => postHandler.GetPostAsync(uri, postsIds));

            var postsIds = new List<int>() { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            var uri = "https://jsonplaceholder.typicode.com/posts/";
            var fileName = "result.txt";
            var postHandler = new PostHandler();
            var fileHadler = new FileHandler();
            List<Post> posts = new List<Post>();

            

            foreach (var postId in postsIds)
            {
                try
                {
                    var post = await postHandler.GetPostAsync(uri, postId);
                    posts.Add(post);
                }
                
                catch (HttpRequestException exception)
                {
                    Console.WriteLine($"Ошибка: {exception.Message}");
                    Console.WriteLine($"{exception.InnerException}");
                }
            }

            fileHadler.WriteToFileAndSave(fileName, posts);
            Console.ReadKey();
        }
    }
}
