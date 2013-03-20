using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*Task:
 Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> 
 with corresponding tags [URL=…]…/URL]. Sample HTML fragment:
    <p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. 
     Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
into: 
    <p>Please visit [URL=http://academy.telerik. com]our site[/URL]
    to choose a training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>
 */
namespace _15.ReplacingLinksWithURL
{
    class ReplacingLinksWithURL
    {
        static void Main(string[] args)
        {
            string text = @"<p>Please visit <a href=""http://academy.telerik.com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>;";
            string linkTagPattern = @"<a href=""";
            text = Regex.Replace(text, linkTagPattern, "[URL=");
            text = Regex.Replace(text, "\">", "]");
            text = Regex.Replace(text, "</a>", "[/URL]");
            Console.WriteLine(text);
        }
    }
}
