using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*Task: 
Write a program that extracts from a given text all sentences containing given word.
Example: The word is "in". The text is:
    We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight.
    So we are drinking all the day. We will move out of it in 5 days.
The expected result is:
    We are living in a yellow submarine.
    We will move out of it in 5 days.
Consider that the sentences are separated by "." and the words – by non-letter symbols.
 */
namespace _08.ExtractingSentence
{
    class ExtractingSentence
    {
        static void Main(string[] args)
        {
            string pattern = @"(?i)((?=[^.\n]*\bin\b)[^.\n]+\.?)";
            string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            MatchCollection matches = Regex.Matches(text, pattern);
            foreach (var match in matches)
            {
                string sentence = match.ToString();
                if (sentence[0] == ' ')
                {
                    sentence = sentence.Remove(0, 1);
                }
                Console.WriteLine(sentence);
            }
        }
    }
}
