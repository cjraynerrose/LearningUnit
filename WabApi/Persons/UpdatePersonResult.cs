

namespace Persons
{
    public class UpdatePersonResult : Result
    {
        public Person Person { get; }
        public CommandState Status { get; }

        public UpdatePersonResult(CommandState status = CommandState.Success, Person person = null)
        {
            Status = status;
            Person = person;
            Succeeded = ResolveResult();
        }

        protected override bool ResolveResult()
        {
            if (Status == CommandState.NoPersonFound)
            {
                return false;
            }

            return true;
        }



    }

}