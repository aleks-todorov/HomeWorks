using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.CheckingBitValueOnGivenPossition
{
    class BoolCheckingBitValueOnGivenPossition
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter number to be checked");
            int numberToCheck = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter position of the bit to be checked");
            int bitPossition = int.Parse(Console.ReadLine());
            int mask = 1 << bitPossition;
            int bitPossitionAndMask = numberToCheck & mask;
            int bit = bitPossitionAndMask >> bitPossition;
            bool valueIsOne = false;
            if (bit == 1)
            {
                valueIsOne = true;
                Console.WriteLine("The {0} bit is 1 - {1}", (bitPossition), valueIsOne);
            }
            else
            {
                Console.WriteLine("The {0} bit is 1 - {1}", (bitPossition), valueIsOne);
            }

        }
    }
}

