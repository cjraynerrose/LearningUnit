using NUnit.Framework;
using Persistence;
using PersonTransactions;

namespace PersonTests
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

