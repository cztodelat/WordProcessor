using System;
using System.Collections.Generic;
using System.Text;

namespace WordProcessor.Commands
{
    public abstract class Command
    {
        public abstract string CommandName { get; }

        public abstract void Execute();
    }
}
