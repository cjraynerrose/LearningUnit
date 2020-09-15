using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persons
{
    public abstract class Command
    {
        protected Result Result { get; set; }
        public abstract void Execute();
        public virtual Result GetResult() => Result;
    }
}
