using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApplication.CommonClasses
{
    public class Call
    {
        private string date;
        private string time;
        private long dialedNumber;
        private int duration;

        public string Date
        {
            get { return date; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Invalid input data !");
                }
                else
                {
                    date = value;
                }

            }
        }
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        public long DialedNumber
        {
            get { return dialedNumber; }
            set
            {
                if (value.ToString().Count() < 10)
                {
                    throw new ArgumentException("Invalid input data !");
                }
                else
                {
                    dialedNumber = value;
                }
            }
        }
        public int Duration
        {
            get { return duration; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input data !");
                }
                else
                {
                    duration = value;
                }
            }
        }

        public Call(string date, string time, long dialedNumber, int duration)
        {
            this.Date = date;
            this.Time = time;
            this.DialedNumber = dialedNumber;
            this.Duration = duration;
        }

        public void ToString()
        {
            Console.WriteLine("Call Date: {0}", this.Date);
            Console.WriteLine("Call Time: {0}", this.Time);
            Console.WriteLine("Call Duration: {0} sec", this.Duration);
            Console.WriteLine("Dialed Phone: {0}", this.DialedNumber);
            Console.WriteLine();
        }
    }
}
