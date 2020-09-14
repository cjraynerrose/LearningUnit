using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using WebApi;

namespace WebApiTests
{
    public class DeletePersonTests
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            PersonStore.DELETE_ALL();
            new CreatePersonCommand("Boris", "Britian").Execute();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            PersonStore.DELETE_ALL();
        }

        [Test]
        public void DeletePerson()
        {
            DeletePersonCommand dpc = new DeletePersonCommand(1);
            DeletePersonResult dpr = dpc.Execute();

            Assert.IsTrue(dpr.Succeeded);
            Assert.AreEqual(1, dpr.Person.Id);
            Assert.AreEqual("Boris", dpr.Person.Name);
            Assert.AreEqual("Britian", dpr.Person.Nationality);

            GetPersonQuery gpq = new GetPersonQuery("Boris");
            GetPersonResult gpr = gpq.Execute();

            Assert.IsTrue(gpr.Succeeded);
            Assert.AreEqual(0, gpr.Persons.Count);
        }


    }
}
