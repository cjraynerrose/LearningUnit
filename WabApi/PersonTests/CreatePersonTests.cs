using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Persons;

namespace PersonsTests
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
            command.Execute();
            CreatePersonResult result = command.GetResult() as CreatePersonResult;

            Assert.IsTrue(result.Succeeded);
            Assert.AreEqual(name, result.Person.Name);
            Assert.AreEqual(nationality, result.Person.Nationality);
        }
    }
}

