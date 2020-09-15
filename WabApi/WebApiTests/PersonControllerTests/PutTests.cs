using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Persistence;
using PersonDomain;
using PersonTransactions;
using WebApi;

namespace WebApiTests.PersonControllerTests
{
    public class PutTests
    {
        PersonController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new PersonController();
            new CreatePersonCommand("Frodo", "Cider").Execute(); // 1
        }

        [TearDown]
        public void TearDown()
        {
            PersonStore.DELETE_ALL();
        }

        [Test]
        public void Update_Ok()
        {
            var model = new UpdatePersonModel(1, "Frodo", "The Shire");

            var result = _controller.Put(model);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);

            var value = (result.Result as OkObjectResult).Value as Person;
            Assert.AreEqual(1, value.Id);
            Assert.AreEqual("Frodo", value.Name);
            Assert.AreEqual("The Shire", value.Nationality);
        }

        [Test]
        public void Update_BadRequest()
        {
            var model = new UpdatePersonModel(0, "Frodo", "The Shire");

            var result = _controller.Put(model);
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
        }
    }
}
