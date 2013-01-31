using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.FindingTheSignOfProductOfNumbers
{
    class FindingTheSignOfProductOfNumbers
    {
        //Write a program that shows the sign (+ or -) of the product of 
        //three real numbers without calculating it. Use a sequence of if statements.

        static void Main()
        {
            Console.WriteLine("Please enter first integer number");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter first integer number");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter first integer number");
            int thirdNumber = int.Parse(Console.ReadLine());

            if ((firstNumber < 0 && secondNumber < 0 && thirdNumber < 0) ||
                (firstNumber < 0 ^ secondNumber < 0 ^ thirdNumber < 0))
            {
                Console.WriteLine("The answer is negative");
            }
            else if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
            {
                Console.WriteLine("The answer is Zero");
            }
            else
            {
                Console.WriteLine("The answer is Possitive");
            }
        }
    }
}


