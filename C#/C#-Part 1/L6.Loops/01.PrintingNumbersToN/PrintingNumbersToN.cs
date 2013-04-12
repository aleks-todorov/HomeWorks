using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PrintingNumbersToN
{
    class PrintingNumbersToN
    {
        static void Main(string[] args)
        {
            /* Write a program that prints 
            all the numbers from 1 to N. */
            int numberN = int.Parse(Console.ReadLine());
            for (int i = 0; i <= numberN; i++)
            {
                Console.WriteLine("Number: {0}", i);
            }
        }
    }
}
