using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using WebApi;

namespace WebApiTests
{
    public class ListPersonTests
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            PersonStore.DELETE_ALL();
            var cpc1 = new CreatePersonCommand("Alfred", "Africa").Execute();
            var cpc2 = new CreatePersonCommand("Billy", "Botswana").Execute();
            var cpc3 = new CreatePersonCommand("Chad", "Chad").Execute();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            PersonStore.DELETE_ALL();
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            PersonStore.DELETE_ALL();
        }

        [TestCase]
        public void ListPersons()
        {
            GetPersonQuery query = new GetPersonQuery();
            GetPersonResult result = query.Execute();

            Assert.AreEqual(result.Persons.Count, 3);
            Assert.AreEqual(result.Persons[0].Name, "Alfred");
            Assert.AreEqual(result.Persons[0].Nationality, "Africa");
            Assert.AreEqual(result.Persons[1].Name, "Billy");
            Assert.AreEqual(result.Persons[1].Nationality, "Botswana");
            Assert.AreEqual(result.Persons[2].Name, "Chad");
            Assert.AreEqual(result.Persons[2].Nationality, "Chad");
        }
    }
}
