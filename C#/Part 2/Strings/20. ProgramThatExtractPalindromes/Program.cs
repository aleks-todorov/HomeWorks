using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _20.ProgramThatExtractPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "ABBA something lamal somethingelse exe asdasd adddda and some other text for endne";
            string pattern = @"[a-zA-Z]+";
            MatchCollection words = Regex.Matches(text, pattern);
            foreach (var entry in words)
            {
                string word = entry.ToString();
                string leftPart = string.Empty;
                string rightPart = string.Empty;
                for (int i = 0; i < word.Length; i++)
                {
                    if (i < word.Length / 2)
                    {
                        leftPart += word[i];
                    }
                    if (i == word.Length / 2 && word.Length % 2 != 0)
                    {
                        continue;
                    }
                    if (i >= word.Length / 2)
                    {
                        rightPart += word[i];
                    }
                }
                bool areSame = true;
                for (int i = 0; i < leftPart.Length; i++)
                {
                    if (leftPart[leftPart.Length - i - 1] != rightPart[i])
                    {
                        areSame = false;
                        break;
                    }
                }
                if (areSame == true)
                {
                    Console.WriteLine(leftPart + " " + rightPart);
                }
            }
        }
    }
}

