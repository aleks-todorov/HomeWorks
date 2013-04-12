using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


/*Task
    You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. Example:
    We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
    The expected result
    We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.
    */
namespace _05.ChangingTextInTags
{
    class ChangingTextInTags
    {
        static void Main(string[] args)
        {
            string content = @"We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
            string pattern = @"(?<=^|<upcase>)[^><]+?(?=</upcase>|$)";
            MatchCollection matches = Regex.Matches(content, pattern);
            foreach (var match in matches)
            {
                string expression = match.ToString();
                content = content.Replace(expression, expression.ToUpper());
            }
            content = Regex.Replace(content, @"<.+?>","");
            Console.WriteLine(content);
        }
    }
}
