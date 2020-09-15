using System;
using System.Security.Cryptography.X509Certificates;

namespace Persons
{
    public class UpdatePersonCommand : Command
    {
        public UpdatePersonCommand(int id, string name, string nationality)
        {
            Person = new Person(id, name, nationality);
        }

        public UpdatePersonCommand(Person person)
        {
            Person = person;
        }

        PersonStore PersonStore = new PersonStore();
        public Person Person { get; }

        public override void Execute()
        {
            var state = PersonStore.Update(Person);
            Result = new UpdatePersonResult(state, Person);
        }
    }
}