namespace Transactions
{
    public abstract class Result
    {
        public bool Succeeded { get; protected set; }

        protected abstract bool ResolveResult();
    }
}