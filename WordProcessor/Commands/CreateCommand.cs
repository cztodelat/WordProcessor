using System;
using System.Collections.Generic;
using System.Text;

namespace WordProcessor.Commands
{
    public class CreateCommand : Command
    {
        public override string CommandName => "--create";

        public override void Execute()
        {
            string path = FilePrecessor.GetFilePath();
            DataBaseProcessor.SetNewData(FilePrecessor.GetWordsFromFile(path));
        }
    }
}
