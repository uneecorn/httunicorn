using HttUnicorn.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttUnicorn.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Get().Result;
            foreach (var item in a)
            {
                Console.WriteLine(a);
            }
        }

        static async Task<List<Todo>> Get()
        {
            return await new HttUnicornSender()
                .SetUrl("https://jsonplaceholder.typicode.com/todos/")
                .GetAsync<List<Todo>>();
        }

        static async Task<string> GetJson()
        {
            return await new HttUnicornSender()
                .SetUrl("http://localhost:3000/todos/")
                .GetJsonAsync();
        }

        static async Task<Todo> Post()
        {
            return await new HttUnicornSender()
                .SetUrl("http://localhost:3000/todos/")
                .PostAsync<Todo, Todo>(new Todo
                {
                    completed = true,
                    title = "todo",
                    userId = 36
                });
        }
    }
}
