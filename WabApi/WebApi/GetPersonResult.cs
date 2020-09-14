using System.Collections.Generic;

namespace WebApi
{
    public class GetPersonResult
    {
        public List<Person> Persons { get; }
        public bool Succeeded { get; private set; }

        public GetPersonResult(List<Person> persons)
        {
            Persons = persons;
            Succeeded = ResolveResult();
        }

        private bool ResolveResult()
        {
            if(Persons == null)
            {
                return false;
            }

            return true;
        }
    }
}