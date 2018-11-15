using System.Net.Http;
using HttUnicorn.Config;
using HttUnicorn.Convertion;
using HttUnicorn.Sender;
using HttUnicorn.Tests.Model;
using HttUnicorn.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HttUnicorn.Tests
{
    [TestClass]
    public class PutTest
    {
        [TestMethod]
        public void PutResponse()
        {
            string url = Constants.URL + "/21";
            Todo oldModel = new Unicorn(new UnicornConfig(url)).GetModelAsync<Todo>().Result;
            Assert.IsNotNull(oldModel);
            Assert.IsTrue(oldModel.Id > 0);

            oldModel.Title = "My edited todo";

            using (HttpResponseMessage responseMessage =
                new Unicorn(new UnicornConfig(Constants.URL))
                .PutResponseAsync(oldModel, oldModel.Id).Result)
            {
                Assert.IsTrue(responseMessage.IsSuccessStatusCode);
                Todo newModel = Serializer.Deserialize<Todo>(responseMessage.ReadContentAsStringAsync().Result);
                Assert.IsNotNull(newModel);
                Assert.IsTrue(newModel.Id > 0);
                Assert.AreNotEqual(oldModel, newModel);
            }
        }

        [TestMethod]
        public void PutString()
        {
            string urlGet = Constants.URL + "/22";
            Todo oldModel = new Unicorn(new UnicornConfig(urlGet))
                .GetModelAsync<Todo>().Result;
            Assert.IsNotNull(oldModel);
            Assert.IsTrue(oldModel.Id > 0);

            oldModel.Title = "My edited todo";

            string stringResult = new Unicorn(new UnicornConfig(Constants.URL))
                .PutStringAsync(oldModel, oldModel.Id).Result;

            Todo newModel = Serializer.Deserialize<Todo>(stringResult);
            Assert.IsNotNull(newModel);
            Assert.IsTrue(newModel.Id > 0);
            Assert.AreNotEqual(oldModel, newModel);
        }

        [TestMethod]
        public void PutModel()
        {
            string urlGet = Constants.URL + "/23";
            Todo oldModel = new Unicorn(new UnicornConfig(urlGet))
                            .GetModelAsync<Todo>().Result;
            Assert.IsNotNull(oldModel);
            Assert.IsTrue(oldModel.Id > 0);

            oldModel.Title = "My edited todo";

            Todo newModel = new Unicorn(new UnicornConfig(Constants.URL))
                .PutModelAsync<Todo, Todo>(oldModel, oldModel.Id).Result;

            Assert.IsNotNull(newModel);
            Assert.IsTrue(newModel.Id > 0);
            Assert.AreNotEqual(oldModel, newModel);
        }
    }
}
