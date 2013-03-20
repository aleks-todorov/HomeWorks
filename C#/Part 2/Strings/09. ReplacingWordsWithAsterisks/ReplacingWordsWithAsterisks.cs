using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Task: 
We are given a string containing a list of forbidden words and a text containing some of these words. 
Write a program that replaces the forbidden words with asterisks. Example:
 * 
 * Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and 
 * is implemented as a dynamic language in CLR.

Words: "PHP, CLR, Microsoft"
The expected result:
    ********* announced its next generation *** compiler today. It is based on 
    *.NET Framework 4.0 and is implemented as a dynamic language in ***.
 */
namespace _09.ReplacingWordsWithAsterisks
{
    class ReplacingWordsWithAsterisks
    {
        static void Main(string[] args)
        {
            string[] forbiddenWords = { "PHP", "CLR", "Microsoft" };
            string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
            for (int i = 0; i < forbiddenWords.Length; i++)
            {
                String stars = new String('*', forbiddenWords[i].Length);
                text = text.Replace(forbiddenWords[i], stars);
            }
            Console.WriteLine(text);
        
        }
    }
}
