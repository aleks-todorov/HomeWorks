using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*Task:
 Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. Example:
<html>
  <head><title>News</title></head>
  <body><p><a href="http://academy.telerik.com">Telerik
    Academy</a>aims to provide free real-world practical
    training for young people who want to turn into
    skillful .NET software engineers.</p></body>
</html>

 */
namespace _25.ExtractingTextFromHTML
{
    class ExtractingTextFromHTML
    {
        static void Main(string[] args)
        {
            string text = @"<html>
                            <head><title>News</title></head>
                             <body><p><a href=""http://academy.telerik.com"">Telerik Academy</a>aims to provide free real-world practical
                                 training for young people who want to turn into skillful .NET software engineers.</p></body>
                            </html>";
            string pattern = @"(?<=^|>)[^><]+?(?=<|$)";
            MatchCollection matches = Regex.Matches(text, pattern);
            var list = new List<string>();
            foreach (var match in matches)
            {
                string freeText = match.ToString();
                freeText = Regex.Replace(freeText, @"\s+", " ");
                list.Add(freeText);
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
