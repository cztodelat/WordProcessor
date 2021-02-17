using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WordProcessor.Commands
{
    public class UpdateCommand : Command
    {
        public override string CommandName => "--update";

        public async override Task Execute()
        {
            string path = FilePrecessor.GetFilePath();
            await Task.Run(() => DataBaseProcessor.AddData(FilePrecessor.GetWordsFromFile(path)));
        }
    }
}
