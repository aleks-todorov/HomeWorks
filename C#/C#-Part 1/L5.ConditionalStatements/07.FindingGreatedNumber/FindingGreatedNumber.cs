using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.FindingGreatedNumber
{
    class FindingGreatedNumber
    {
        static void Main()
        {
            //Write a program that finds the greatest of given 5 variables.
            Random randomNumber = new Random();
            int[] numberArray = new int[50];
            int biggestNumber = 0;
            int biggestnumberPossition = 0;
            for (int i = 0; i < numberArray.Length; i++)
            {
                int cellValue = randomNumber.Next(0, 101);
                numberArray[i] = cellValue;
                Console.WriteLine(numberArray[i]);
                if (numberArray[i] > biggestNumber)
                {
                    biggestNumber = numberArray[i];
                    biggestnumberPossition = i;
                }
            }
            Console.WriteLine("The biggest Number was: {0} and its possition was: {1}", biggestNumber, biggestnumberPossition); 
        }
    }
}
