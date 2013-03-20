using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*Task:
 
 Write a program that reverses the words in given sentence.
	"Example: "C# is not C++, not PHP and not Delphi!" 
    "Delphi not and PHP, not C++ not is C#!".
*/
namespace _13.ReversingWords
{
    class ReversingWords
    {
        static void Main(string[] args)
        {
            string text = "C# is not C++, not PHP and not Delphi!";

            string pattern = @"\s+|,\s*|\.\s*|!\s*";
            List<string> words = new List<string>();
            List<string> separators = new List<string>();
            string[] splittedWords = Regex.Split(text, pattern);
            foreach (string word in splittedWords)
            {
                words.Add(word);
            }
            MatchCollection matches = Regex.Matches(text, pattern);
            foreach (Match separator in matches)
            {
                separators.Add(separator.Value);
            }

            for (int i = 0; i < separators.Count; i++)
            {
                Console.Write(words[words.Count - 2 - i] + separators[i]);
            }

            Console.WriteLine();
        }
    }
}