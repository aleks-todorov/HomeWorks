using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Task: 
 Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. Example:
    Enter the first date: 27.02.2006
    Enter the second date: 3.03.2004
    Distance: 4 days
 */
namespace _16.CalculatingDateDifference
{
    class CalculatingDateDifference
    {
        static void Main(string[] args)
        {
            string dayOne = "27.02.2006";
            string dayTwo = "3.03.2004";
            DateTime startDate = DateTime.ParseExact(dayOne, "d.MM.yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(dayTwo, "d.MM.yyyy", CultureInfo.InvariantCulture);
            TimeSpan span = startDate - endDate;
            Console.WriteLine("Difference betwee both dates is: {0}", span.TotalDays);
        }
    }
}
