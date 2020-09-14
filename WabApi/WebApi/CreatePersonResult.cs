namespace WebApi
{
    public class CreatePersonResult
    {
        public Person Person { get; }
        public bool Succeeded { get; }

        public CreatePersonResult(Person person)
        {
            Person = person;
            Succeeded = ResolveResult();
        }

        private bool ResolveResult()
        {
            if(Person == null)
            {
                return false;
            }

            if(!Person.IsValid())
            {
                return false;
            }

            return true;
        }
    }
}