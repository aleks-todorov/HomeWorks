using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Task: 
 Write a program that reads a string from the console and replaces all series
 of consecutive identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa" => "abcdedsa".
 */
namespace _23.ReplacingIdenticalSymbols
{
    class ReplacingIdenticalSymbols
    {
        static void Main(string[] args)
        {
            string word = "aaaaabbbbbcdddeeeedssaa";
            string newWord = string.Empty;

            for (int i = 0; i < word.Length - 1; i++)
            {
                char currentLetter = word[i];
                if (currentLetter == word[i + 1])
                {
                    if (i == word.Length - 2)
                    {
                        newWord += currentLetter.ToString();
                    }
                    continue;
                }
                newWord += currentLetter.ToString();
            }
            Console.WriteLine(newWord);
        }
    }
}
