using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Persons;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi;

namespace WebApiTests.PersonControllerTests
{
    public class DeleteTests
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
        public void Delete_Ok()
        {
            var command = new DeletePersonCommand(1);

            var result = _controller.Delete(command);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);

            var value = (result.Result as OkObjectResult).Value as Person;
            Assert.AreEqual(1, value.Id);
            Assert.AreEqual("Gandelf", value.Name);
            Assert.AreEqual("Hogwarts", value.Nationality);
        }

        [Test]
        public void Delete_BadRequest()
        {
            var command = new DeletePersonCommand(0);

            var result = _controller.Delete(command);
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
        }
    }
}
