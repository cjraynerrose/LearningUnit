using PersonDomain;
using Transactions;

namespace PersonTransactions
{
    public class CreatePersonResult : Result
    {
        public Person Person { get; }

        public CreatePersonResult(Person person)
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

            if (!Person.IsValid())
            {
                return false;
            }

            return true;
        }
    }
}