using CatalogOfFreeContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeContentCatalog
{
    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog contentCatalog, ICommand command, StringBuilder output)
        {
            switch (command.Type)
            {
                case CommandType.AddBook:
                    var book = new ContentItem(ContentItemType.Book, command.Parameters);
                    contentCatalog.Add(book);
                    output.AppendLine("Book added");
                    break;

                case CommandType.AddMovie:
                    var movie = new ContentItem(ContentItemType.Movie, command.Parameters);
                    contentCatalog.Add(movie);
                    output.AppendLine("Movie added");
                    break;

                case CommandType.AddSong:
                    var song = new ContentItem(ContentItemType.Song, command.Parameters);
                    contentCatalog.Add(song);
                    output.AppendLine("Song added");
                    break;

                case CommandType.AddApplication:
                    var application = new ContentItem(ContentItemType.Application, command.Parameters);
                    contentCatalog.Add(application);
                    output.AppendLine("Application added");
                    break;

                case CommandType.Update:
                    UpdateCommand(contentCatalog, command, output);
                    break;

                case CommandType.Find:
                    ProcessFindCommand(contentCatalog, command, output);
                    break;

                default:
                    {
                        throw new InvalidOperationException("Unknown command!");
                    }
            }
        }

        private static void UpdateCommand(ICatalog contentCatalog,
            ICommand command, StringBuilder output)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of parameters!");
            }

            int itemsUpdated =
                contentCatalog.UpdateContent(command.Parameters[0], command.Parameters[1]);
            string updateCommandResutl = String.Format("{0} items updated", itemsUpdated);
            output.AppendLine(updateCommandResutl);
        }

        private static void ProcessFindCommand(ICatalog contentCatalog,
            ICommand command, StringBuilder output)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of parameters!");
            }

            int numberOfElementsToList = Int32.Parse(command.Parameters[1]);

            IEnumerable<IContent> foundContent =
                contentCatalog.GetListContent(command.Parameters[0], numberOfElementsToList);

            if (foundContent.Count() == 0)
            {
                output.AppendLine("No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    output.AppendLine(content.TextRepresentation);
                }
            }
        }
    }
}
