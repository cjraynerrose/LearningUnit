

namespace WebApi
{
    public class UpdatePersonResult
    {
        public bool? Succeeded { get; private set; }
        public Person Person { get; }
        public CommandState Status { get; }

        public UpdatePersonResult(CommandState status = CommandState.Success, Person person = null)
        {
            Status = status;
            Person = person;
            Succeeded = ResolveResult();
        }

        private bool ResolveResult()
        {
            if (Status == CommandState.NoPersonFound)
            {
                return false;
            }

            return true;
        }

        

    }
    
}