using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.PrintingGreatedNumber
{
    class PrintingGreatedNumber
    {
        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Between {0} and {1} greated is: {2}", firstNumber, secondNumber, Math.Max(firstNumber, secondNumber));

        }
    }
}
