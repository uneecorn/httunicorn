# httunicorn
> Designed to help C# programmers creating HTTP Requests, this is The Hypertext Transfer Unicorn :unicorn:

#Usage
Our goal is to publish HttUnicorn as a NuGet Package in the future. But for now, to use it, you'll need:
1. Download or clone it;
2. Add the project to your solution;
3. Follow the examples below
###Get
```
List<Todo> todos = await new HttUnicornSender()
                      .SetUrl("http://localhost:3000/todos/")
                      .GetAsync<List<Todo>>();
                      
string todoJson = await new HttUnicornSender()
                    .SetUrl("http://localhost:3000/todos/")
                    .GetJsonAsync();
```
###Post
```
await new HttUnicornSender()
  .SetUrl("http://localhost:3000/todos/")
  .PostAsync<Todo, Todo>(new Todo
  {
    completed = true,
    title = "todo",
    userId = 36
  });
//this one will return de generated Todo, wich type is specified in the first type parameter
```
###Put
```
Todo updatedTodo = await new HttUnicornSender()
                    .SetUrl("http://localhost:3000/todos/" + todo.id)
                    .PutAsync<Todo, Todo>(todo);
//this one will return de edited Todo, wich type is specified in the first type parameter
```
###Delete
```
await new HttUnicornSender()
  .SetUrl("http://localhost:3000/todos/")
  .DeleteAsync(key);

MyApiResponse response = await new HttUnicornSender()
                          .SetUrl("http://localhost:3000/todos/")
                          .DeleteAsync<MyApiResponse>(key);
//this one is for situations when the requestes API returns an object in the body of the response
```
##Contact me
Tyler Mendes de Brito – [@colorigotica](https://twitter.com/colorigotica) – tyler.brito99@gmail.com

[https://github.com/tylerbryto/](https://github.com/tylerbryto/)

## Contributing

1. Fork it (<https://github.com/tylerbryto/ng-galery/fork>)
2. Create your feature branch (`git checkout -b feature/fooBar`)
3. Commit your changes (`git commit -am 'Add some fooBar'`)
4. Push to the branch (`git push origin feature/fooBar`)
5. Create a new Pull Request
