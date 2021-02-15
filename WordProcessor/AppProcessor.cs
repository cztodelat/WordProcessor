using System;
using System.Collections.Generic;
using WordProcessor.Commands;
using System.Linq;

namespace WordProcessor
{
    public static class AppProcessor
    {
        private static List<Command> commands = new List<Command>();
        public static void ExecuteApp(string[] args)
        {
            string path = String.Empty;
            string commandName = "";
            
            if (args.Length == 0)
            {
                DictionaryProcessor.ExecuteDictionary();
                return;
            } else
            {
                commandName = args[0];

                foreach (var command in commands)
                {
                    if (command.CommandName == commandName)
                    {
                        command.Execute();
                        return;
                    }
                }
            }

            Console.WriteLine("Wrong command pleace try again :)");
            
        }

        static AppProcessor()
        {
            //Initializing commands

            commands.Add(new CreateCommand());
            commands.Add(new UpdateCommand());
            commands.Add(new DeleteCommand());
        }
    }
}
