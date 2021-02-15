using System;
using System.Collections.Generic;
using System.Text;

namespace WordProcessor.Commands
{
    public class DeleteCommand : Command
    {
        public override string CommandName => "--delete";

        public override void Execute()
        {
            DataBaseProcessor.RemoveData();
        }
    }
}
