using PersonTransactions;

namespace WebApi
{
    public class CreatePersonModel
    {
        public CreatePersonModel() { }
        public CreatePersonModel(string name, string nationality)
        {
            Name = name;
            Nationality = nationality;
        }

        public string Name { get; set; }
        public string Nationality { get; set; }

        public CreatePersonCommand ToCommand() => new CreatePersonCommand(Name, Nationality);

    }
}