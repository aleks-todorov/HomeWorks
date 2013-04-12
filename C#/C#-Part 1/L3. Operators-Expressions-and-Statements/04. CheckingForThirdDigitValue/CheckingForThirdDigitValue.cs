using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CheckingForThirdDigitValue
{
    class CheckingForThirdDigitValue
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number to be checked: ");
            int originalNumber = int.Parse(Console.ReadLine());
            int numberToCheck = originalNumber / 100;
            if (originalNumber > 99)
            {
                if ((numberToCheck % 10) == 7)
                {
                    Console.WriteLine("The third digit(from right to left) is 7.");
                }
                else
                {
                    Console.WriteLine("The third digit(from right to left) is not 7.");
                }
            }
            else
            {
                Console.WriteLine("Please provide valid number.");
            }
        }
    }
}
