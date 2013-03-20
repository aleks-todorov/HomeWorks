using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Task: 
 
 Write a program that reads from the console a string of maximum 20 characters. 
 If the length of the string is less than 20, the rest of the characters should be filled with '*'.
 Print the result string into the console.
*/
namespace _06.StringWithFIxedLength
{
    class StringWithFIxedLength
    {
        static void Main(string[] args)
        {
            string text = string.Empty;

            do
            {
                text = Console.ReadLine();
            }
            while (text.Length <= 0 || text.Length > 20);

            String stars = new String('*', 20 - text.Length);
            text = text + stars;
            Console.WriteLine(text);
        }
    }
}
