using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/* Taks: 
Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
		Example: The target substring is "in". The text is as follows:

        We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight.
        * So we are drinking all the day. We will move out of it in 5 days.

	The result is: 9.
*/

namespace _03.CountOccurenceOfSubstring
{
    class CountOccurenceOfSubstring
    {
        static void Main(string[] args)
        {
            string content = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days";
            string pattern = @"in";
            MatchCollection matches = Regex.Matches(content, pattern, RegexOptions.IgnoreCase);
            Console.WriteLine(matches.Count);

        }
    }
}
