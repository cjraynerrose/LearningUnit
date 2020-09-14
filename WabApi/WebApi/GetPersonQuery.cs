using System;
using System.Linq;

namespace WebApi
{
    public class GetPersonQuery
    {
        public GetPersonQuery(string term = "")
        {
            Term = term;
        }

        PersonStore PersonStore = new PersonStore();
        public string Term { get; }

        public GetPersonResult Execute()
        {
            var persons = PersonStore.Get()
                .Where(p =>
                    p.Id.ToString() == Term
                    || p.Name.Contains(Term, StringComparison.InvariantCultureIgnoreCase)
                    || p.Nationality.Contains(Term, StringComparison.InvariantCultureIgnoreCase)
                )
                .ToList();

            var result = new GetPersonResult(persons);
            return result;
        }
    }
}