using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PrintingSumOfNumbers
{
    class PrintingSumOfNumbers
    {
        static void Main()
        {
            Console.WriteLine("Please enter 3 numbers");
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());
            Console.WriteLine("The sum of {0}, {1} and {2} is: {3}", numberOne, numberTwo, numberThree, (numberOne + numberTwo + numberThree));
        }
    }
}
