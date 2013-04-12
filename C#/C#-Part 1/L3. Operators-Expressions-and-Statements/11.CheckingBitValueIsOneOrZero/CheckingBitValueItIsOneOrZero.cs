using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.CheckingBitValueIsOneOrZero
{
    class CheckingBitValueItIsOneOrZero
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter number to be checked");
            int numberToCheck = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter position of the bit to be checked");
            int bitPossition = int.Parse(Console.ReadLine());
            bitPossition = bitPossition - 1;
            int mask = 1 << bitPossition;
            int bitPossitionAndMask = numberToCheck & mask;
            int bit = bitPossitionAndMask >> bitPossition;
            if (bit == 1)
            {
                Console.WriteLine("The {0} bit is 1", (bitPossition + 1));
            }
            else
            {
                Console.WriteLine("The {0} bit is 0", (bitPossition + 1));
            }
        }
    }
}
