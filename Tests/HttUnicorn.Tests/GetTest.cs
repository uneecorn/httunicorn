using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using HttUnicorn.Config;
using HttUnicorn.Sender;
using HttUnicorn.Tests.Model;
using HttUnicorn.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HttUnicorn.Tests
{
    [TestClass]
    public class GetTest
    {
        [TestMethod]
        public void GetResponse()
        {
            using (HttpResponseMessage responseMessage =
                new Unicorn(new UnicornConfig(Constants.URL))
                .GetResponseAsync().Result)
            {
                Assert.IsTrue(responseMessage.IsSuccessStatusCode);
            }
        }

        [TestMethod]
        public void GetString()
        {
            string jsonString = new Unicorn(new UnicornConfig(Constants.URL)).GetStringAync().Result;
            Assert.IsTrue(jsonString.Length > 0);
        }

        [TestMethod]
        public void GetModel()
        {
            List<Todo> todos = new Unicorn(new UnicornConfig(Constants.URL)).GetModelAsync<List<Todo>>().Result;

            Assert.IsTrue(todos != null && todos.Count > 0);

            Todo model = new Unicorn(new UnicornConfig(Constants.URL + "/" + todos.FirstOrDefault().Id)).GetModelAsync<Todo>().Result;
            Assert.IsNotNull(model);
            Assert.IsTrue(model.Id > 0);
        }
    }
}
