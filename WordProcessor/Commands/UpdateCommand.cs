using System;
using System.Collections.Generic;
using System.Text;

namespace WordProcessor.Commands
{
    public class UpdateCommand : Command
    {
        public override string CommandName => "--update";

        public override void Execute()
        {
            string path = FilePrecessor.GetFilePath();
            DataBaseProcessor.AddData(FilePrecessor.GetWordsFromFile(path));
        }
    }
}
