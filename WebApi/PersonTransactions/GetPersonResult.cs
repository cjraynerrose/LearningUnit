using PersonDomain;
using System.Collections.Generic;
using Transactions;

namespace PersonTransactions
{
    public class GetPersonResult : Result
    {
        public List<Person> Persons { get; }

        public GetPersonResult(List<Person> persons)
        {
            Persons = persons;
            Succeeded = ResolveResult();
        }

        protected override bool ResolveResult()
        {
            if (Persons == null)
            {
                return false;
            }

            return true;
        }
    }
}