

using Persistence;
using PersonDomain;
using Transactions;

namespace PersonTransactions
{
    public class UpdatePersonResult : Result
    {
        public Person Person { get; }
        public TransactionState Status { get; }

        public UpdatePersonResult(TransactionState status = TransactionState.Success, Person person = null)
        {
            Status = status;
            Person = person;
            Succeeded = ResolveResult();
        }

        protected override bool ResolveResult()
        {
            if (Status == TransactionState.NoPersonFound)
            {
                return false;
            }

            return true;
        }



    }

}