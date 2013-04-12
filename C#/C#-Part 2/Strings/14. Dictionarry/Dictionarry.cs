using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*Task: 
A dictionary is stored as a sequence of text lines containing words and their explanations. 
Write a program that enters a word and translates it by using the dictionary. Sample dictionary:
    .NET – platform for applications from Microsoft
    CLR – managed execution environment for .NET
    namespace – hierarchical organization of classes
 */
namespace _14.Dictionarry
{
    struct CSharpDictionary
    {
        public string word;
        public string explanation;
    }
    class Dictionarry
    {
        static void Main(string[] args)
        {
            string patternForWords = @".+?\s(?=–)";
            string patternForExplanation = @"(?<=–).+";
            string text = @".NET – platform for applications from Microsoft
                            CLR – managed execution environment for .NET
                            namespace – hierarchical organization of classes";
            MatchCollection words = Regex.Matches(text, patternForWords);
            MatchCollection explanations = Regex.Matches(text, patternForExplanation);
            var list = new List<CSharpDictionary>();
            for (int i = 0; i < words.Count; i++)
            {
                CSharpDictionary element = new CSharpDictionary();
                string word = words[i].ToString();
                word = word.Trim(' ');
                element.word = word;
                element.explanation = explanations[i].ToString();
                list.Add(element);
            }

            string term = "namespace";
            foreach (var items in list)
            {
                if (term == items.word)
                {
                    Console.WriteLine("{0} - {1}", term, items.explanation);
                }
            }
        }
    }
}
