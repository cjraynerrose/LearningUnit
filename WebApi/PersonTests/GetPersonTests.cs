using NUnit.Framework;
using Persistence;
using PersonTransactions;

namespace PersonTests
{
    public class GetPersonTests
    {
        PersonStore PersonStore = new PersonStore();

        [OneTimeSetUp]
        public void SetUp()
        {
            PersonStore.DELETE_ALL();
            new CreatePersonCommand("Avocado", "Brazil").Execute();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            PersonStore.DELETE_ALL();
        }

        [TestCase("Avocado")]
        [TestCase("AvOcaDo")]
        [TestCase("avocado")]
        [TestCase("AVOCADO")]
        [TestCase("Avo")]
        [TestCase("Brazil")]
        [TestCase("Br")]
        [TestCase("1")]
        [TestCase("")]
        public void GetPerson(string term)
        {
            GetPersonQuery query = new GetPersonQuery(term);
            query.Execute();
            GetPersonResult result = query.GetResult() as GetPersonResult;

            Assert.IsTrue(result.Succeeded);
            Assert.AreEqual(1, result.Persons.Count);
            Assert.AreEqual(1, result.Persons[0].Id);
            Assert.AreEqual("Avocado", result.Persons[0].Name);
            Assert.AreEqual("Brazil", result.Persons[0].Nationality);
        }

        [TestCase("a v o c a d o")]
        [TestCase("TRAIN")]
        [TestCase(" ")]
        [TestCase("2")]
        public void GetPersonFail(string term)
        {
            GetPersonQuery query = new GetPersonQuery(term);
            query.Execute();
            GetPersonResult result = query.GetResult() as GetPersonResult;

            Assert.IsTrue(result.Succeeded);
            Assert.AreEqual(0, result.Persons.Count);
        }
    }
}
