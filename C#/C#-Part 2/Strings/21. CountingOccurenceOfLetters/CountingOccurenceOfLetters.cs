using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*Task: 
 Write a program that reads a string from the console and prints all different
 letters in the string along with information how many times each letter is found. 
 */
namespace _21.CountingOccurenceOfLetters
{
    class CountingOccurenceOfLetters
    {
        static void Main(string[] args)
        {
            var text = " Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found.";
            var pattern = @"\w";
            MatchCollection letters = Regex.Matches(text, pattern);
            var list = new List<string>();
            foreach (var letter in letters)
            {
                list.Add(letter.ToString());
            }
            list.Sort();
            int counter = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                string currentSymbol = list[i];
                counter++;
                if (currentSymbol == list[i + 1])
                {
                    continue;
                }
                Console.WriteLine("Word: {0,-1} - Occurence {1,-1}", currentSymbol, counter);
                counter = 0;
            }
        }
    }
}
