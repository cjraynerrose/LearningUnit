using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using WebApi;

namespace WebApiTests
{
    public class UpdatePersonTests
    {
        PersonStore PersonStore = new PersonStore();

        [OneTimeSetUp]
        public void SetUp()
        {
            PersonStore.DELETE_ALL();
            new CreatePersonCommand("Gary", "Gondor").Execute();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            PersonStore.DELETE_ALL();
        }

        [Test]
        public void UpdatePerson()
        {
            UpdateCommand unc = new UpdateCommand(1, "Gazza", "Gurder");
            UpdatePersonResult unr = unc.Execute();

            Assert.IsTrue(unr.Succeeded);
            Assert.AreEqual("Gazza", unr.Person.Name);

            GetPersonResult gpr = new GetPersonQuery("1").Execute();

            Assert.IsTrue(gpr.Succeeded);
            Assert.AreEqual(1, gpr.Persons.Count);
            Assert.AreEqual("Gazza", gpr.Persons[0].Name);
            Assert.AreEqual("Gurder", gpr.Persons[0].Nationality);
        }

        [Test]
        public void UpdatePersonFail()
        {
            UpdateCommand unc = new UpdateCommand(2, "Gazza", "Gurder");
            UpdatePersonResult unr = unc.Execute();

            Assert.IsFalse(unr.Succeeded);
            Assert.AreEqual(CommandState.NoPersonFound, unr.Status);
        }
    }
}
