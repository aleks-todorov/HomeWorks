using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.CheckIfNumberIsPrime
{
    class CheckIfNumberIsPrime
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number to be check if it is prime: ");
            int numberToCheck = int.Parse(Console.ReadLine());
            if (numberToCheck < 0 || numberToCheck > 100)
            {
                Console.WriteLine("Please enter valid number between 0 and 100");
            }
            else
            {
                if (numberToCheck % 2 != 0 && numberToCheck % 3 != 0 && numberToCheck % 5 != 0 && numberToCheck % 7 != 0)
                {
                    Console.WriteLine("Number {0} is prime.", numberToCheck);
                }
                else
                {
                    Console.WriteLine("Number {0} is NOT prime", numberToCheck);
                }
            }
        }
    }
}

