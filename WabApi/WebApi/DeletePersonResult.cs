namespace WebApi
{
    public class DeletePersonResult
    {
        public bool Succeeded { get; }
        public Person Person { get; }

        public DeletePersonResult(Person person)
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

            return true;
        }
    }
}