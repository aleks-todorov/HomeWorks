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
                    contentCatalog.Add(new ContentItem(ContentItemType.Book, command.Parameters));
                    output.AppendLine("Book added");
                    break;

                case CommandType.AddMovie:
                    contentCatalog.Add(new ContentItem(ContentItemType.Movie, command.Parameters));
                    output.AppendLine("Movie added");
                    break;

                case CommandType.AddSong:
                    contentCatalog.Add(new ContentItem(ContentItemType.Song, command.Parameters));
                    output.AppendLine("Song added");
                    break;

                case CommandType.AddApplication:
                    contentCatalog.Add(new ContentItem(ContentItemType.Application, command.Parameters));
                    output.AppendLine("Application added");
                    break;

                case CommandType.Update:
                    if (command.Parameters.Length != 2)
                    {
                        throw new FormatException("Invalid parameters!");
                    }

                    int itemsUpdated = contentCatalog.UpdateContent(command.Parameters[0], command.Parameters[1]);
                    string updateCommandResutl = String.Format("{0} items updated", itemsUpdated);
                    output.AppendLine(updateCommandResutl);
                    break;

                case CommandType.Find:
                    if (command.Parameters.Length != 2)
                    {
                        Console.WriteLine("Invalid params!");
                        throw new Exception("Invalid number of parameters!");
                    }

                    Int32 numberOfElementsToList = Int32.Parse(command.Parameters[1]);

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
                    break;

                default:
                    {
                        throw new InvalidCastException("Unknown command!");
                    }
            }
        }
    }
}
