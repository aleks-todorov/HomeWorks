using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Task: 
 
Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. Sample input:
 * Hi!
Expected output:
 * \u0048\u0069\u0021
*/
namespace _10.ConvertingStringToUniCode
{
    class ConvertingStringToUniCode
    {
        static void Main(string[] args)
        {
            string text = "Hi!";
            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];
                Console.Write("\\u{0:x4}", (int)symbol);
            }
            Console.WriteLine();
        }
    }
}
