using Persistence;
using PersonDomain;
using Transactions;

namespace PersonTransactions
{
    public class CreatePersonCommand : Command
    {
        public CreatePersonCommand(string name, string nationality)
        {
            Name = name;
            Nationality = nationality;
        }

        private PersonStore PersonStore = new PersonStore();
        public string Name { get; }
        public string Nationality { get; }

        public override void Execute()
        {
            Person newPerson = new Person(Name, Nationality);
            if (newPerson.IsValid())
            {
                PersonStore.Add(newPerson);
            }

            Result = new CreatePersonResult(newPerson);
        }
    }
}