using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreeContentCatalog;

namespace CatalogOfFreeContent
{
    //Task is not complete. Unfortunately I do not have time to finish it before the end date(Sunday), so I will continue on Monday.
    //This version has proper naming, 2 our of 3 methods are tested, logic is separated in different classes most of the bugs are fixed. 
    // TODO:  finsish unit tests, get high code coverage, search for bugs, add documentation in XML form.
    public class Application
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor cmdExecutor = new CommandExecutor();

            var commands = ReadInputCommands();
            foreach (ICommand command in commands)
            {
                cmdExecutor.ExecuteCommand(catalog, command, output);
            }

            Console.Write(output);
        }

        private static List<ICommand> ReadInputCommands()
        {
            List<ICommand> commandsList = new List<ICommand>();
            bool isEnd = false;

            do
            {
                string line = Console.ReadLine();
                isEnd = (line.Trim() == "End");
                if (!isEnd)
                {
                    commandsList.Add(new Command(line));
                }
            }
            while (!isEnd);

            return commandsList;
        }

        public static ICatalog catalog { get; set; }
    }
}
