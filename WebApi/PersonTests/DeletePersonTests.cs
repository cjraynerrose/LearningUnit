using NUnit.Framework;
using Persistence;
using PersonTransactions;

namespace PersonTests
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
            dpc.Execute();
            DeletePersonResult dpr = dpc.GetResult() as DeletePersonResult;

            Assert.IsTrue(dpr.Succeeded);
            Assert.AreEqual(1, dpr.Person.Id);
            Assert.AreEqual("Boris", dpr.Person.Name);
            Assert.AreEqual("Britian", dpr.Person.Nationality);

            GetPersonQuery gpq = new GetPersonQuery("Boris");
            gpq.Execute();
            GetPersonResult gpr = gpq.GetResult() as GetPersonResult;

            Assert.IsTrue(gpr.Succeeded);
            Assert.AreEqual(0, gpr.Persons.Count);
        }


    }
}
