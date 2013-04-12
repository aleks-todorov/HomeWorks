using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FindingBiggestNumber
{
    class FindingBiggestNumber
    {
        static void Main()
        {
            //Write a program that finds the biggest of three integers using nested if statements.

            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirNumber = int.Parse(Console.ReadLine());

            if (firstNumber > secondNumber && firstNumber > thirNumber)
            {
                Console.WriteLine("First number is the biggest");
            }
            else if (secondNumber > firstNumber && secondNumber > thirNumber)
            {
                Console.WriteLine("The second number is the biggest");
            }
            else
            {
                Console.WriteLine("Third number is the biggest");
            }
        }
    }
}
