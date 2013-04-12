using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*Task:
  Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.
*/
namespace _24.SortingListOfWords
{
    class SortingListOfWords
    {
        static void Main(string[] args)
        {
            string text = "Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.";
            string pattern = @"\w+";
            MatchCollection words = Regex.Matches(text, pattern);
            var list = new List<string>();
            foreach (var word in words)
            {
                list.Add(word.ToString());
            }
            list.Sort();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
