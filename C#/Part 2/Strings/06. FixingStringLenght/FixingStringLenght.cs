using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Task
 Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less 
 than 20, the rest of the characters should be filled with '*'. Print the result string into the console.
 */
namespace _06.FixingStringLenght
{
    class FixingStringLenght
    {
        static void Main(string[] args)
        {
            string content = string.Empty;

            do
            {
                content = Console.ReadLine();
            }
            while ((content.Length <= 1 || content.Length > 20) || content == null);

            String start = new String('*', 20 - content.Length);
            content = content + start;
            Console.WriteLine(content);
        }
    }
}
