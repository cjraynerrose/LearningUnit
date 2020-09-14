using System;

namespace WebApi
{
    public class DeletePersonCommand
    {
        public DeletePersonCommand(int id)
        {
            Id = id;
        }

        private PersonStore PersonStore = new PersonStore();
        public int Id { get; }

        public DeletePersonResult Execute()
        {
            var deletedPerson = PersonStore.Delete(Id);
            var result = new DeletePersonResult(deletedPerson);
            return result;
        }

        
    }
}