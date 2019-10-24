using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using HttUnicorn.Config;
using HttUnicorn.Sender;
using HttUnicorn.Tests.Model;
using HttUnicorn.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static HttUnicorn.Config.UnicornConfig;

namespace HttUnicorn.Tests
{
    [TestClass]
    public class DeleteTest
    {
        [TestMethod]
        public void DeleteResponse()
        {
            List<Todo> oldTodos = new Unicorn(UnicornConfigFactory.NewInstance(Constants.URL))
                .GetModelAsync<List<Todo>>().Result;
            Assert.IsTrue(oldTodos != null && oldTodos.Count > 0);

            int oldCount = oldTodos.Count;

            Todo first = oldTodos.FirstOrDefault();

            HttpResponseMessage result = new Unicorn(UnicornConfigFactory.NewInstance(Constants.URL))
                .DeleteResponseAsync(first.Id).Result;

            Assert.IsTrue(result.IsSuccessStatusCode);

            List<Todo> newTodos = new Unicorn(UnicornConfigFactory.NewInstance(Constants.URL))
                .GetModelAsync<List<Todo>>().Result;

            Assert.IsTrue(newTodos != null && newTodos.Count > 0);

            int newCount = newTodos.Count;

            Assert.IsTrue(newCount < oldCount);
        }

        [TestMethod]
        public void DeleteJson()
        {
            List<Todo> oldTodos = new Unicorn(UnicornConfigFactory.NewInstance(Constants.URL))
                .GetModelAsync<List<Todo>>().Result;
            Assert.IsTrue(oldTodos != null && oldTodos.Count > 0);

            int oldCount = oldTodos.Count;

            Todo first = oldTodos.FirstOrDefault();

            string result = new Unicorn(UnicornConfigFactory.NewInstance(Constants.URL))
                .DeleteStringAsync(first.Id).Result;

            List<Todo> newTodos = new Unicorn(UnicornConfigFactory.NewInstance(Constants.URL))
                .GetModelAsync<List<Todo>>().Result;

            Assert.IsTrue(newTodos != null && newTodos.Count > 0);

            int newCount = newTodos.Count;

            Assert.IsTrue(newCount < oldCount);
        }
    }
}
