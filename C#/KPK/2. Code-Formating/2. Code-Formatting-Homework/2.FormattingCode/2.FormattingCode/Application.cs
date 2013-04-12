using System;
using _2.FormattingCode;

/// <summary>
/// The functionality class. It contains the Main Method for running the application. 
/// Example input: 
/// AddEvent 08/01/2013 06:34:23 | FirstEvent | IE
/// AddEvent 09/02/2014 23:21:12 | SecondEvent | Opera
/// AddEvent 10/03/2015 12:23:10 | ThirdEvent | Chrome
/// DeleteEvents ThirdEvent
/// ListEvents 08/01/2013 06:34:23 | 3
/// Exit
/// </summary>
public class Application
{
    static EventHolder events = new EventHolder();

    static void Main(string[] args)
    {
        while (true)
        {
            if (ExecuteNextCommand() == false)
            {
                break;
            }
        }

        Messages.PrintOutput();
    }

    private static bool ExecuteNextCommand()
    {
        string command = Console.ReadLine();

        if (command.StartsWith("AddEvent"))
        {
            AddEvent(command);
            return true;
        }
        else if (command.StartsWith("DeleteEvents"))
        {
            DeleteEvents(command);
            return true;
        }
        else if (command.StartsWith("ListEvents"))
        {
            ListEvents(command);
            return true;
        }
        else
        {
            return false;
        }
    }

    private static DateTime GetDate(string command, string commandType)
    {
        DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
        return date;
    }

    private static void ListEvents(string command)
    {
        int pipeIndex = command.IndexOf('|');
        DateTime date = GetDate(command, "ListEvents");
        string countString = command.Substring(pipeIndex + 1);
        int count = int.Parse(countString);
        events.ListEvents(date, count);
    }

    private static void DeleteEvents(string command)
    {
        string title = command.Substring("DeleteEvents".Length + 1);
        events.DeleteEvents(title);
    }

    private static void AddEvent(string command)
    {
        DateTime date;
        string title;
        string location;
        GetParameters(command, "AddEvent", out date, out title, out location);
        events.AddEvent(date, title, location);
    }

    private static void GetParameters(string commandForExecution, string commandType, out DateTime dateAndTime, out string eventTitle, out string eventLocation)
    {
        dateAndTime = GetDate(commandForExecution, commandType);
        int firstPipeIndex = commandForExecution.IndexOf('|');
        int lastPipeIndex = commandForExecution.LastIndexOf('|');

        if (firstPipeIndex == lastPipeIndex)
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
            eventLocation = string.Empty;
        }
        else
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
            eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
        }
    }
}