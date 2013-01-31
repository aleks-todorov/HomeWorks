using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _10.ExtractTextFromXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = string.Empty;
            content = ReadingFromFile(content);
            string pattern = @"(?<=^|>)[^><]+?(?=<|$)";
            MatchCollection matches = Regex.Matches(content, pattern);
            WriteMethod(matches);
        }

        private static string ReadingFromFile(string content)
        {
            StreamReader reader = new StreamReader("../../input.txt");
            using (reader)
            {
                content = reader.ReadToEnd();
            }
            return content;
        }

        private static void WriteMethod(MatchCollection matches)
        {
            StreamWriter writer = new StreamWriter("../../output.txt");
            using (writer)
            {
                foreach (var match in matches)
                    writer.WriteLine(match);
            }
        }
    }
}
