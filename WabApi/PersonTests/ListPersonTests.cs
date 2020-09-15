using NUnit.Framework;
using Persons;

namespace PersonsTests
{
    public class ListPersonTests
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            PersonStore.DELETE_ALL();
            new CreatePersonCommand("Alfred", "Africa").Execute();
            new CreatePersonCommand("Billy", "Botswana").Execute();
            new CreatePersonCommand("Chad", "Chad").Execute();
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
            query.Execute();
            GetPersonResult result = query.GetResult() as GetPersonResult;

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
