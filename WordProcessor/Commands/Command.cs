using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WordProcessor.Commands
{
    public abstract class Command
    {
        public abstract string CommandName { get; }

        public abstract Task Execute();
    }
}
