using Persons;
using System;

namespace WebApi
{
    public class UpdatePersonModel
    {
        public UpdatePersonModel() { }
        public UpdatePersonModel(int id, string name, string nationality)
        {
            Id = id;
            Name = name;
            Nationality = nationality;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }

        public UpdatePersonCommand ToCommand() => new UpdatePersonCommand(Id, Name, Nationality);
    }
}