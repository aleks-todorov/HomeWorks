using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*Task: 
 
 Write a program that parses an URL address given in the format:
        [protocol]://[server]/[resource]
	and extracts from it the [protocol], [server] and [resource] elements. For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
		[protocol] = "http"
		[server] = "www.devbg.org"
		[resource] = "/forum/index.php"
*/
namespace _12.ParsingURL
{
    class ParsingURL
    {
        static void Main(string[] args)
        {
            string address = @"http://www.devbg.org/forum/index.php";
            string patternProtocol = @".+(?=:)";
            string patternServer = @"(?<=//).+?(?=/)";
            string patternResource = @"(?<=//).+";
            string protocol = string.Empty;
            string server = string.Empty;
            string resource = string.Empty;


            MatchCollection matches = Regex.Matches(address, patternProtocol);
            foreach (var match in matches)
            {
                protocol = match.ToString();
            }
            matches = Regex.Matches(address, patternServer);
            foreach (var match in matches)
            {
                server = match.ToString();
            }
            matches = Regex.Matches(address, patternResource);
            foreach (var match in matches)
            {
                resource = match.ToString();
                resource = resource.Replace(server, "");
            }
            Console.WriteLine("[protocol] = {0}", protocol);
            Console.WriteLine("[server] = {0}", server);
            Console.WriteLine("[resource] = {0}", resource);
        }
    }
}
