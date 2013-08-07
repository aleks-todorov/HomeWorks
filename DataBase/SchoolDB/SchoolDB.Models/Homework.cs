using System;

namespace SchoolDB.Models
{
    public class Homework
    {
        private string content;
        private DateTime? timesent;
        public Course Course { get; set; }
        public Student Student { get; set; }
        public int Id { get; set; }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public DateTime? TimeSent
        {
            get { return timesent; }
            set { timesent = value; }
        }
    }
}
