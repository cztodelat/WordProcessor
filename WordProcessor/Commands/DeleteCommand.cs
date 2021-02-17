using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WordProcessor.Commands
{
    public class DeleteCommand : Command
    {
        public override string CommandName => "--delete";

        public async override Task Execute()
        {
            await DataBaseProcessor.RemoveDataAsync();
        }
    }
}
