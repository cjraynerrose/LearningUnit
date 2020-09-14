using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using WebApi;

namespace WebApiTests
{
    public class CreatePersonTests
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            PersonStore.DELETE_ALL();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            PersonStore.DELETE_ALL();
        }

        [TestCase("Derek", "Nigerian")]
        public void CreatePerson(string name, string nationality)
        {
            CreatePersonCommand command = new CreatePersonCommand(name, nationality);
            CreatePersonResult result = command.Execute();

            Assert.IsTrue(result.Succeeded);
            Assert.AreEqual(result.Person.Name, name);
            Assert.AreEqual(result.Person.Nationality, nationality);
        }
    }
}

