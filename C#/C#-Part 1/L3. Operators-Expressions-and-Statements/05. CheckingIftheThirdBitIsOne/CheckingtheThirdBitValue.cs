using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CheckingIftheThirdBitIsOne
{
    class CheckingtheThirdBitValue
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number to be checked: ");
            int number = int.Parse(Console.ReadLine());
            bool thirdBitIsOne;
            int bit;
            int mask = 1 << 3;
            int numberAndMask = number & mask;
            bit = numberAndMask >> 3;
            if (bit == 0)
            {
                thirdBitIsOne = false;
                Console.WriteLine("The third bit is 1 - " + thirdBitIsOne);
            }
            else if (bit == 1)
            {
                thirdBitIsOne = true;
                Console.WriteLine("The third bit is 1 - " + thirdBitIsOne);
            }
        }
    }
}

