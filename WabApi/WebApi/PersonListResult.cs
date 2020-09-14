using System.Collections.Generic;

namespace WebApi
{
    public class PersonListResult
    {
        public List<Person> Persons;
        public bool Succeeded { get; private set; }

        public PersonListResult(List<Person> persons)
        {
            Persons = persons;
            Succeeded = ResolveResult();
        }

        private bool ResolveResult()
        {
            if(Persons.Count < 0)
            {
                return false;
            }

            return true;
        }
    }
}