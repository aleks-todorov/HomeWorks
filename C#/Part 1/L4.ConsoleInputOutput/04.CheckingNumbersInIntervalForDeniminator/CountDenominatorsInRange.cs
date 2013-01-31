using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CountDenominatorsInRange
{
    class CountDenominatorsInRange
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int numbersDividableByFive = 0;
            if (firstNumber < 0 || secondNumber < 0 || firstNumber > secondNumber)
            {
                Console.WriteLine("Please enter correct Numbers");
            }
            else
            {
                for (int i = firstNumber; i <= secondNumber; i++)
                {
                    if (i % 5 == 0)
                    {
                        numbersDividableByFive++;
                    }
                }
                Console.WriteLine("Numbers that can be divided by 5 in the interval {0} and {1} are: {2}", firstNumber, secondNumber, numbersDividableByFive);
                
            }
        }
    }
}
