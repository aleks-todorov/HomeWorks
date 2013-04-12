namespace _2.FormattingCode
{
    using System;
    using Events;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Simple class for event handling. It allows functionality for Adding, Deleting and Listing Events
    /// </summary>
    public class EventHolder
    {
        private MultiDictionary<string, Event> eventsOrderdByTitle = new MultiDictionary<string, Event>(true);
        private OrderedBag<Event> eventsOrderbyDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            this.eventsOrderdByTitle.Add(title.ToLower(), newEvent);
            this.eventsOrderbyDate.Add(newEvent);
            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removedEvents = 0;
            foreach (var eventToRemove in this.eventsOrderdByTitle[title])
            {
                removedEvents++;
                this.eventsOrderbyDate.Remove(eventToRemove);
            }

            this.eventsOrderdByTitle.Remove(title);
            Messages.EventDeleted(removedEvents);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.eventsOrderbyDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showed = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}
