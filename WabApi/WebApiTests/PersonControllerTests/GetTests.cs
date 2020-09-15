using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Persistence;
using PersonDomain;
using PersonTransactions;
using System.Collections.Generic;
using WebApi;

namespace WebApiTests.PersonControllerTests
{
    public class GetTests
    {
        PersonController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new PersonController();
            new CreatePersonCommand("Gandelf", "Hogwarts").Execute(); // 1
            new CreatePersonCommand("Frodo", "Cider").Execute(); // 2
            new CreatePersonCommand("Legolas", "Tree").Execute(); // 3
            new CreatePersonCommand("Sauron", "Spicy Hill").Execute(); // 4
            new CreatePersonCommand("Bill", "The Pony").Execute(); // 5
        }

        [TearDown]
        public void TearDown()
        {
            PersonStore.DELETE_ALL();
        }

        [Test]
        public void Get_All_Ok()
        {
            var result = _controller.Get();
            Assert.IsInstanceOf<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);

            var data = okResult.Value as List<Person>;
            Assert.AreEqual(5, data.Count);
            Assert.AreEqual("Gandelf", data[0].Name);
        }

        [Test]
        public void Get_OneByQuery_Ok()
        {
            var result = _controller.Get("Gandelf");
            Assert.IsInstanceOf<OkObjectResult>(result.Result);

            var data = ((result.Result as OkObjectResult).Value) as List<Person>;
            Assert.AreEqual(1, data.Count);
            Assert.AreEqual(1, data[0].Id);
            Assert.AreEqual("Gandelf", data[0].Name);
            Assert.AreEqual("Hogwarts", data[0].Nationality);
        }

        [Test]
        public void Get_NoContent()
        {
            var result = _controller.Get("nothing to be found here");
            Assert.IsInstanceOf<NoContentResult>(result.Result);
        }
    }
}