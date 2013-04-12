namespace _2.FormattingCode
{
    using Events;
    using System;
    using System.Text;

    /// <summary>
    /// Class for storing information about the Events state. It allows keeping and displaying information when adding, deleting events.
    /// </summary>
    public static class Messages
    {
        static StringBuilder output = new StringBuilder();

        public static void EventAdded()
        {
            output.Append("Event added\n");
        }

        public static void EventDeleted(int numberOfEvents)
        {
            if (numberOfEvents == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendFormat("{0} events deleted\n", numberOfEvents);
            }
        }

        public static void NoEventsFound()
        {
            output.Append("No events found\n");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + "\n");
            }
        }

        public static void PrintOutput()
        {
            Console.WriteLine(output);
        }
    }
}
