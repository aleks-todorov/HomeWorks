using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CalculatingTheGreatestCommonDivisor
{
    class CalculatingTheGreatestCommonDivisor
    {
        static void Main(string[] args)
        {
            //Write a program that calculates the greatest common divisor 
            //(GCD) of given two numbers. Use the Euclidean algorithm (find it in Internet).
            // The idea will be eucledeanNumber = smallesNumber % reminder 
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int reminder = firstNumber % secondNumber;
            int smallestNumber = secondNumber;
            int euclideanNumber = firstNumber % secondNumber;
            int greatestCommonDivisor = euclideanNumber;
            if (firstNumber < secondNumber)
            {
                reminder = secondNumber % firstNumber;
                smallestNumber = firstNumber;
                euclideanNumber = secondNumber % firstNumber;
                greatestCommonDivisor = euclideanNumber;
            }

            // Chech if the denominator is not the GCD

            if (euclideanNumber == 0)
            {
                greatestCommonDivisor = smallestNumber;
            }
            while (euclideanNumber > 0)
            {
                greatestCommonDivisor = euclideanNumber;
                euclideanNumber = smallestNumber % reminder;
                smallestNumber = reminder;
                if (euclideanNumber == 0)
                {
                    break;
                }
            }
            Console.WriteLine("The Biggest Common Divisor of {0} and {1} is {2}", firstNumber, secondNumber, greatestCommonDivisor);
        }
    }
}
