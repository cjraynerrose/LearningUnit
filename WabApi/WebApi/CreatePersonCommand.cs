using System;
using Microsoft.AspNetCore.Mvc;

namespace WebApi
{
    public class CreatePersonCommand
    {
        public CreatePersonCommand(string name, string nationality)
        {
            Name = name;
            Nationality = nationality;
        }

        private PersonStore PersonStore = new PersonStore();
        public string Name { get; }
        public string Nationality { get; }

        public CreatePersonResult Execute()
        {
            Person newPerson = new Person(Name, Nationality);
            if (newPerson.IsValid())
            {
                PersonStore.Add(newPerson);
            }

            CreatePersonResult result = new CreatePersonResult(newPerson);
            return result;
        }
    }
}