# HttUnicorn v0.0.2-alfa

[![NuGet](https://img.shields.io/badge/nuget-v0.0.2--alfa-blue.svg)](https://www.nuget.org/packages/HttUnicorn/0.0.2-alfa)  

> Designed to help C# programmers creating HTTP Requests, this is The Hypertext Transfer Unicorn :unicorn:

## Usage

1. Install our [NuGet Package](https://www.nuget.org/packages/HttUnicorn/0.0.2-alfa);
2. Follow the examples below

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

[![](https://sourcerer.io/fame/tylerbryto/tylerbryto/httunicorn/images/0)](https://sourcerer.io/fame/tylerbryto/tylerbryto/httunicorn/links/0)[![](https://sourcerer.io/fame/tylerbryto/tylerbryto/httunicorn/images/1)](https://sourcerer.io/fame/tylerbryto/tylerbryto/httunicorn/links/1)[![](https://sourcerer.io/fame/tylerbryto/tylerbryto/httunicorn/images/2)](https://sourcerer.io/fame/tylerbryto/tylerbryto/httunicorn/links/2)[![](https://sourcerer.io/fame/tylerbryto/tylerbryto/httunicorn/images/3)](https://sourcerer.io/fame/tylerbryto/tylerbryto/httunicorn/links/3)[![](https://sourcerer.io/fame/tylerbryto/tylerbryto/httunicorn/images/4)](https://sourcerer.io/fame/tylerbryto/tylerbryto/httunicorn/links/4)[![](https://sourcerer.io/fame/tylerbryto/tylerbryto/httunicorn/images/5)](https://sourcerer.io/fame/tylerbryto/tylerbryto/httunicorn/links/5)[![](https://sourcerer.io/fame/tylerbryto/tylerbryto/httunicorn/images/6)](https://sourcerer.io/fame/tylerbryto/tylerbryto/httunicorn/links/6)[![](https://sourcerer.io/fame/tylerbryto/tylerbryto/httunicorn/images/7)](https://sourcerer.io/fame/tylerbryto/tylerbryto/httunicorn/links/7)

---

🦄
