using Persistence;
using System;
using System.Linq;
using Transactions;

namespace PersonTransactions
{
    public class GetPersonQuery : Command
    {
        public GetPersonQuery(string term = "")
        {
            Term = term;
        }

        PersonStore PersonStore = new PersonStore();
        public string Term { get; }

        public override void Execute()
        {
            var persons = PersonStore.Get()
                .Where(p =>
                    p.Id.ToString() == Term
                    || p.Name.Contains(Term, StringComparison.InvariantCultureIgnoreCase)
                    || p.Nationality.Contains(Term, StringComparison.InvariantCultureIgnoreCase)
                )
                .ToList();

            Result = new GetPersonResult(persons);
        }
    }
}