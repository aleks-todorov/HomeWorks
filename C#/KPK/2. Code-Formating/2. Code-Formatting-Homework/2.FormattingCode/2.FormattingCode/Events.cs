namespace Events
{
    using System;
    using System.Text;
    
    /// <summary>
    /// Public class For creating Events. Implements IComparable, which allows comparing events on several criterias: by Date, by Title, by Location
    /// </summary>
    public class Event : IComparable
    {
        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public int CompareTo(object obj)
        {
            Event newEvent = obj as Event;
            int eventsOrderdByDate = this.Date.CompareTo(newEvent.Date);
            int eventsOrderdByTitle = this.Title.CompareTo(newEvent.Title);
            int eventsOrderdByLocation = this.Location.CompareTo(newEvent.Location);

            if (eventsOrderdByDate == 0)
            {
                if (eventsOrderdByTitle == 0)
                {
                    return eventsOrderdByLocation;
                }
                else
                {
                    return eventsOrderdByTitle;
                }
            }
            else
            {
                return eventsOrderdByDate;
            }
        }

        public override string ToString()
        {
            StringBuilder stringResult = new StringBuilder();
            stringResult.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));
            stringResult.Append(" | " + this.Title);
            if (this.Location != null && this.Location != string.Empty)
            {
                stringResult.Append(" | " + this.Location);
            }

            return stringResult.ToString();
        }
    }
}
