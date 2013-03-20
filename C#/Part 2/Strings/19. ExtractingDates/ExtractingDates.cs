using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*Task: 
 Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. 
 Display them in the standard date format for Canada.
 */
namespace _19.ExtractingDates
{
    class ExtractingDates
    {
        static void Main(string[] args)
        {
            string text = "My name is John Smith and I am 25 was born 03.12.1987, I have 1 sister who is born 23.08.1990. Her phone number is: 23 43 3443";
            string pattern = @"[\d]{1,2}[.][\d]{1,2}[.][\d]{4}";
            MatchCollection dates = Regex.Matches(text, pattern);
            foreach (var entry in dates)
            {
                string dateNow = entry.ToString();
                DateTime date = DateTime.ParseExact(dateNow, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine("Current date in Canadian format is : {0}", Convert.ToString(date, CultureInfo.GetCultureInfo("en-CA")));
            }
        }
    }
}
