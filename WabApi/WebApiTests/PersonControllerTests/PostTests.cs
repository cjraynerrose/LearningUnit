using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Persons;
using WebApi;

namespace WebApiTests.PersonControllerTests
{
    public class PostTests
    {
        PersonController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new PersonController();
        }

        [TearDown]
        public void TearDown()
        {
            PersonStore.DELETE_ALL();
        }

        [Test]
        public void Create_CreatedAt()
        {
            var model = new CreatePersonModel("Derek", "France");

            var result = _controller.Post(model);
            Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);

            var createdResult = result.Result as CreatedAtActionResult;
            Assert.AreEqual(201, createdResult.StatusCode);

            var value = createdResult.Value as Person;
            Assert.AreEqual(1, value.Id);
            Assert.AreEqual("Derek", value.Name);
            Assert.AreEqual("France", value.Nationality);
        }

        [Test]
        public void Create_BadRequest()
        {
            var model = new CreatePersonModel("", "");

            var result = _controller.Post(model);
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
        }
    }
}
