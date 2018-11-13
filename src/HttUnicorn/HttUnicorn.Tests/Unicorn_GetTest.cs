using System.Net.Http;
using HttUnicorn.Config;
using HttUnicorn.Sender;
using HttUnicorn.Tests.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HttUnicorn.Tests
{
    [TestClass]
    public class Unicorn_GetTest
    {
        const string URL = "https://jsonplaceholder.typicode.com/todos/1";

        [TestMethod]
        public void GetResponse()
        {
            using (HttpResponseMessage responseMessage =
                new Unicorn(new UnicornConfig(URL))
                .GetResponseAsync().Result)
            {
                Assert.IsTrue(responseMessage.IsSuccessStatusCode);
            }
        }

        [TestMethod]
        public void GetJson()
        {
            string jsonString = new Unicorn(new UnicornConfig(URL)).GetJsonAync().Result;
            Assert.IsTrue(jsonString.Length > 0);
        }

        [TestMethod]
        public void GetModel()
        {
            Todo model = new Unicorn(new UnicornConfig(URL)).GetModelAsync<Todo>().Result;
            Assert.IsNotNull(model);
            Assert.IsTrue(model.Id > 0);
        }
    }
}
