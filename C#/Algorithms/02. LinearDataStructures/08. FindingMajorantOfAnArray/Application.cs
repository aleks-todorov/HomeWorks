using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.FindingMajorantOfAnArray
{
    class Application
    {
        /* Task 8:
         * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. 
         * Write a program to find the majorant of given array (if exists). Example:
         * {2, 2, 3, 3, 2, 3, 4, 3, 3}  3
         */

        static void Main(string[] args)
        {
            int[] numbers = { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            var uniqueNumbers = new Dictionary<Int32, Int32>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (uniqueNumbers.ContainsKey(numbers[i]))
                {
                    uniqueNumbers[numbers[i]]++;
                }
                else
                {
                    uniqueNumbers.Add(numbers[i], 1);
                }
            }

            var isMajorantFound = false;
            foreach (var number in uniqueNumbers)
            {
                if (number.Value >= numbers.Length / 2 + 1)
                {
                    Console.WriteLine("The majorant is: {0}", number.Key);
                    isMajorantFound = true;
                    break;
                }
            }

            if (!isMajorantFound)
            {
                Console.WriteLine("There is no majorant for this array!");
            }
        }
    }
}
