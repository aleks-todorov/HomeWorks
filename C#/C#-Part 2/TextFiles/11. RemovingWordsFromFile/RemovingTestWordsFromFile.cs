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
            StreamReader reader = new StreamReader("../../input.txt");
            string content = string.Empty;
            using (reader)
            {
                content = reader.ReadToEnd();
            }
            string pattern = @"\stest[a-zA-Z0-9]+";
            string replaceValue = "";
            string newContent = Regex.Replace(content, pattern, replaceValue);
            StreamWriter writer = new StreamWriter("../../input.txt");
            using (writer)
            {
                writer.WriteLine(newContent);
            }
        }
    }
}
