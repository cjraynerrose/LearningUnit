using PersonDomain;
using Transactions;

namespace PersonTransactions
{
    public class DeletePersonResult : Result
    {
        public Person Person { get; }

        public DeletePersonResult(Person person)
        {
            Person = person;
            Succeeded = ResolveResult();
        }

        protected override bool ResolveResult()
        {
            if (Person == null)
            {
                return false;
            }

            return true;
        }
    }
}