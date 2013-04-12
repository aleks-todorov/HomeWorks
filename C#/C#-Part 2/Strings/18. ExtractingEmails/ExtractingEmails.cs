using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*Write a program for extracting all email addresses from given text.
All substrings that match the format <identifier>@<host>…<domain> 
should be recognized as emails.
*/
namespace _18.ExtractingEmails
{

    class ExtractingEmails
    {
        static void Main(string[] args)
        {
            string text = "My name is John Smith and my email address is jsmith_23@something.com. Before that I was using smith_johny15@abv.bg but there was some problem with receiving emails...";
            string pattern = @"([\w-\.]+)@((?:[\w]+\.)+)([a-zA-Z]{2,4})";
            MatchCollection emails = Regex.Matches(text, pattern);
            foreach (var email in emails)
            {
                Console.WriteLine(email);
            }
        }
    }
}
