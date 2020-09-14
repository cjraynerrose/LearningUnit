using System;
using System.Security.Cryptography.X509Certificates;

namespace WebApi
{
    public class UpdateCommand
    {
        public UpdateCommand(int id, string name, string nationality)
        {
            Person = new Person(id, name, nationality);
        }

        public UpdateCommand(Person person)
        {
            Person = person;
        }

        PersonStore PersonStore = new PersonStore();
        Person Person;

        public UpdatePersonResult Execute()
        {
            var state = PersonStore.Update(Person);
            var result = new UpdatePersonResult(state, Person);
            return result;
        }
    }
}