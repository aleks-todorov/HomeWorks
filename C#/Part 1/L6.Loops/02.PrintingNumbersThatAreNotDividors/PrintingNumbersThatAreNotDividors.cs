using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PrintingNumbersThatAreNotDividors
{
    class PrintingNumbersThatAreNotDividors
    {
        static void Main(string[] args)
        {
           // Write a program that prints all the numbers from 1 
           // to N, that are not divisible by 3 and 7 at the same time.

            int numberN = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberN; i++)
            {
                if (i % 3 != 0 && i % 7 != 0)
                {
                    Console.WriteLine("The number is: {0}",i);
                }
            }
        }
    }
}
