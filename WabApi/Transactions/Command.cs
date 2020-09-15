namespace Transactions
{
    public abstract class Command
    {
        protected Result Result { get; set; }
        public abstract void Execute();
        public virtual Result GetResult() => Result;
    }
}
