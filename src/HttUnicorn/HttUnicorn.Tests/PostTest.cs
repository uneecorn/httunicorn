using System.Net.Http;
using HttUnicorn.Config;
using HttUnicorn.Sender;
using HttUnicorn.Tests.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HttUnicorn.Tests
{
    [TestClass]
    public class PostTest
    {
        const string URL = "http://localhost:3000/todo/";

        [TestMethod]
        public void PostResponse()
        {

            using (HttpResponseMessage result = new Unicorn(new UnicornConfig(URL)).PostRespnseAsync(new Todo
            {
                Completed = true,
                Title = "My todo",
                UserId = 2
            }).Result)
            {
                Assert.IsTrue(result.IsSuccessStatusCode);
            }
        }

        [TestMethod]
        public void PostJson()
        {
            string result = new Unicorn(new UnicornConfig(URL)).PostJsonAsync<Todo>(new Todo
            {
                Completed = true,
                Title = "My todo",
                UserId = 2
            }).Result;

            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void PostModel()
        {
            var result = new Unicorn(new UnicornConfig(URL)).PostModelAsync<Todo, Todo>(new Todo
            {
                Completed = true,
                Title = "My todo",
                UserId = 2
            }).Result;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Id > 0);
        }
    }
}
