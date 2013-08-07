using System;

namespace University.Models
{
    public class Homework
    {
        private string content;
        //private DateTime timeSent;
        public int HomeworkID { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        ///public DateTime TimeSent
        ///{
        ///    get { return timeSent; }
        ///    set { timeSent = value; }
        ///}
    }
}
