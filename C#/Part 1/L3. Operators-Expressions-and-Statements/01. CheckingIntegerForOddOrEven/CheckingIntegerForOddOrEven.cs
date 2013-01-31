using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CheckingIntegerForOddOrEven
{
    class CheckingIntegerForOddOrEven
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the integer to be checked: ");
            int numberToCheck = int.Parse(Console.ReadLine());
            if (numberToCheck % 2 == 0)
            {
                Console.WriteLine("This integer is even");
            }
            else
            {
                Console.WriteLine("This integer is odd");
            }
        }
    }
}
