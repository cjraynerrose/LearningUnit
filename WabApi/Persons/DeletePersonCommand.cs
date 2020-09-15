using System;

namespace Persons
{
    public class DeletePersonCommand : Command
    {
        public DeletePersonCommand(int id)
        {
            Id = id;
        }

        private PersonStore PersonStore = new PersonStore();
        public int Id { get; }

        public override void Execute()
        {
            var deletedPerson = PersonStore.Delete(Id);
            Result = new DeletePersonResult(deletedPerson);
        }

        
    }
}