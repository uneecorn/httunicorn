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
            var x = Post().Result;
            x = Post().Result;
            x = Post().Result;
            x = Post().Result;
            var a = Get().Result;
            Console.Write(GetJson().Result);
            var c = a.FirstOrDefault();
            
            var b = Delete(c.id);
            Console.Write(GetJson().Result);
        }

        static async Task<List<Todo>> Get()
        {
            return await new HttUnicornSender()
                .SetUrl("http://localhost:3000/todos/")
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

        static async Task<Todo> Put(Todo todo)
        {
            return await new HttUnicornSender()
                .SetUrl("http://localhost:3000/todos/" + todo.id)
                .PutAsync<Todo, Todo>(todo);
        }

        static async Task Delete(object key)
        {
            await new HttUnicornSender()
                .SetUrl("http://localhost:3000/todos/")
                .DeleteAsync<Todo>(key);
        }
    }
}
