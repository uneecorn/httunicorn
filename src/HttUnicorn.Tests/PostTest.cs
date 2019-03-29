﻿using System.Net.Http;
using HttUnicorn.Config;
using HttUnicorn.Sender;
using HttUnicorn.Tests.Model;
using HttUnicorn.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HttUnicorn.Tests
{
    [TestClass]
    public class PostTest
    {
        [TestMethod]
        public void PostResponse()
        {

            using (HttpResponseMessage result =
                new Unicorn(new UnicornConfig(Constants.URL))
                .PostRespnseAsync(new Todo
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
        public void PostString()
        {
            string result = new Unicorn(new UnicornConfig(Constants.URL))
                .PostStringAsync(new Todo
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
            Todo result = new Unicorn(new UnicornConfig(Constants.URL)).PostModelAsync<Todo, Todo>(new Todo
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
