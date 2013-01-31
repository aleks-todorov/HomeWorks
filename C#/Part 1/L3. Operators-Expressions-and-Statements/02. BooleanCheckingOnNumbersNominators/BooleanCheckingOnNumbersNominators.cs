using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BooleanCheckingOnNumbersNominators
{
    class BooleanCheckingOnNumbersNominators
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter integer to be checked.");
            int numberToCheck = int.Parse(Console.ReadLine());
            bool isDividable;
            if (numberToCheck % (7 * 5) == 0)
            {
                isDividable = true;
                Console.WriteLine(numberToCheck + " can be divided on 5 and 7 at the same time - " + isDividable);
            }
            else
            {
                isDividable = false;
                Console.WriteLine(numberToCheck + " can be divided on 5 and 7 at the same time - " + isDividable);
            }
        }
    }
}
