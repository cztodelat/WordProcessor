using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WordProcessor.Commands
{
    public class CreateCommand : Command
    {
        public override string CommandName => "--create";

        public async override Task Execute()
        {
            string path = FilePrecessor.GetFilePath();
            await DataBaseProcessor.SetNewData(FilePrecessor.GetWordsFromFile(path));
        }
    }
}
