using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints the date and
time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.*/
namespace _17.CalculatungDateAfterGivenInterval
{
    class CalculatungDateAfterGivenInterval
    {
        static void Main(string[] args)
        {
            string currentTime = "02.02.2013 19:40:00";

            DateTime date = DateTime.ParseExact(currentTime, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            date = date.AddHours(6.5);

            Console.WriteLine("{0} {1}", date.ToString("dddd", new CultureInfo("bg-BG")), date);
        }
    }
}
