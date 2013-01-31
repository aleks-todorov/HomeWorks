using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ChangingValuesOfTwoNumbersWithIf
{
    class ChangingValuesOfTwoNumbersWithI
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            if (firstNumber > secondNumber)
            {
                int swapNumber = firstNumber;
                firstNumber = secondNumber;
                secondNumber = swapNumber;
            }
        }
    }
}
