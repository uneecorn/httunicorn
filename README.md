# HttUnicorn v0.0.2-alfa

> Designed to help C# programmers creating HTTP Requests, this is The Hypertext Transfer Unicorn :unicorn:

## Usage

Our goal is to publish HttUnicorn as a NuGet Package in the future. But for now, to use it, you'll need:

1. Download or clone it;
2. Add the project to your solution;
3. Follow the examples below

### Get

```csharp
List<Todo> todos = await new HttUnicornSender()
                      .SetUrl("http://localhost:3000/todos/")
                      .GetAsync<List<Todo>>();
                      
string todoJson = await new HttUnicornSender()
                    .SetUrl("http://localhost:3000/todos/")
                    .GetAsync();
```

### Post

```csharp
await new HttUnicornSender()
  .SetUrl("http://localhost:3000/todos/")
  .PostAsync<Todo, Todo>(new Todo
  {
    Completed = true,
    Title = "todo",
    UserId = 36
  });
//This one will return the generated Todo, wich type is specified in the first type parameter.

```


### Put

```csharp
Todo updatedTodo = await new HttUnicornSender()
                    .SetUrl("http://localhost:3000/todos/" + todo.id)
                    .PutAsync<Todo, Todo>(todo);
//This one will return the edited Todo, wich type is specified in the first type parameter.

```


### Delete

```csharp
await new HttUnicornSender()
  .SetUrl("http://localhost:3000/todos/")
  .DeleteAsync(key);

MyApiResponse response = await new HttUnicornSender()
                          .SetUrl("http://localhost:3000/todos/")
                          .DeleteAsync<MyApiResponse>(key);
//This one is for situations when the requested API returns an object in the body of the response.

```


## Contact me

Tyler Mendes de Brito - [@tylerbryto (Github)](https://github.com/tylerbryto) – [colorigotica (Twitter)](https://twitter.com/colorigotica) – tyler.brito99@gmail.com

## Contributing

See [git flow cheatsheet](https://danielkummer.github.io/git-flow-cheatsheet/).

1. Fork it (<https://github.com/tylerbryto/httunicorn/fork>)
2. Create your feature branch (`git checkout -b feature/fooBar`)
3. Commit your changes (`git commit -am 'Add some fooBar'`)
4. Push to the branch (`git push origin feature/fooBar`)
5. Create a new Pull Request
6. Wait for my response

---

🦄
