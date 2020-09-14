using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;

namespace WebApi
{
    public class PersonStore
    {
        private static HashSet<Person> Persons { get; } = new HashSet<Person>();

        public void Add(Person person)
        {
            person.SetId(GetNextId());
            Persons.Add(person);
        }

        public Person Delete(int id)
        {
            var person = Persons.FirstOrDefault(p => p.Id == id);
            var success = Persons.Remove(person);


            if (!success)
            {
                return null;
            }
            
            return person;
        }

        public IQueryable<Person> Get()
        {
            return Persons.AsQueryable();
        }

        public CommandState Update(Person person)
        {
            var personToUpdate = Persons.FirstOrDefault(p => p.Id == person.Id);
            if(personToUpdate == null)
            {
                return CommandState.NoPersonFound;
            }

            Persons.Remove(personToUpdate);
            Persons.Add(person);

            return CommandState.Success;
        }

        public int GetNextId()
        {
            if (Persons.Count == 0)
            {
                return 1;
            }

            var nextId = Persons.Max(p => p.Id) + 1;
            return nextId;
        }

        public static void DELETE_ALL()
        {
            Persons.Clear();
        }


    }

    public enum CommandState
    {
        Success,
        NoPersonFound
    }
}
