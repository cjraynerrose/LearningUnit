using NUnit.Framework;
using Persistence;
using PersonTransactions;
using Transactions;

namespace PersonsTests
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
            Command unc = new UpdatePersonCommand(1, "Gazza", "Gurder");
            unc.Execute();
            UpdatePersonResult unr = unc.GetResult() as UpdatePersonResult;

            Assert.IsTrue(unr.Succeeded);
            Assert.AreEqual("Gazza", unr.Person.Name);

            Command gpq = new GetPersonQuery("1");
            gpq.Execute();
            GetPersonResult gpr = gpq.GetResult() as GetPersonResult;

            Assert.IsTrue(gpr.Succeeded);
            Assert.AreEqual(1, gpr.Persons.Count);
            Assert.AreEqual("Gazza", gpr.Persons[0].Name);
            Assert.AreEqual("Gurder", gpr.Persons[0].Nationality);
        }

        [Test]
        public void UpdatePersonFail()
        {
            Command unc = new UpdatePersonCommand(2, "Gazza", "Gurder");
            unc.Execute();
            UpdatePersonResult unr = unc.GetResult() as UpdatePersonResult;

            Assert.IsFalse(unr.Succeeded);
            Assert.AreEqual(TransactionState.NoPersonFound, unr.Status);
        }
    }
}
