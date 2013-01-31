using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ComparingTwoIntegerValues
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter first integer number");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter second integer number");
            int secondNumber = int.Parse(Console.ReadLine());
            if (firstNumber > secondNumber)
            {
                int thirdNumber = firstNumber;
                firstNumber = secondNumber;
                secondNumber = thirdNumber;
                Console.WriteLine("First number is: {0}, and second number is {1}", firstNumber, secondNumber);
            }
        }
    }
}
