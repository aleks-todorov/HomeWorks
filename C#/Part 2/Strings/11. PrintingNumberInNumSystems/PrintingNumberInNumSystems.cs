using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Task: 
 Write a program that reads a number and prints it as a decimal number, hexadecimal number,
 * percentage and in scientific notation. Format the output aligned right in 15 symbols.
 */
namespace _11.PrintingNumberInNumSystems
{
    class PrintingNumberInNumSystems
    {
        static void Main(string[] args)
        {
            int number = 1;
            Console.WriteLine("{0,15:f1}", number);
            Console.WriteLine("{0,15:x4}", number);
            Console.WriteLine("{0,15:p}", number);
            Console.WriteLine("{0,15:e}", number);
        }
    }
}
