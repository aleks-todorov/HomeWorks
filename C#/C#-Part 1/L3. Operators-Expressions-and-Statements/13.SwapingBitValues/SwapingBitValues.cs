using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.SwapingBitValues
{
    class SwapingBitValues
    {
        static void Main()
        {
            //Write a program that exchanges bits 3, 4 and 5 with bits 
            //24, 25 and 26 of given 32-bit unsigned integer.

            int initalNumber = int.Parse(Console.ReadLine());
            int newNumber = initalNumber;
            int firstPossition = 3;
            int secondPossition = 24;
            int[] firstBitArray = new int[3];
            int[] secondBitArray = new int[3];
            for (int i = 0; i < 3; i++)
            {
                firstBitArray[i] = CheckingBitValue(initalNumber, firstPossition + i);
                secondBitArray[i] = CheckingBitValue(initalNumber, secondPossition + i);
            }
            for (int i = 0; i < 3; i++)
            {
                if (firstBitArray[i] != secondBitArray[i] && firstBitArray[i] == 0)
                {
                    newNumber = SwitchingBitValueToOne(newNumber, firstPossition + i);
                    newNumber = SwitchingBitValueToZero(newNumber, secondPossition + i);
                }
                else if (firstBitArray[i] != secondBitArray[i] && firstBitArray[i] == 1)
                {
                    newNumber = SwitchingBitValueToZero(newNumber, firstPossition + i);
                    newNumber = SwitchingBitValueToOne(newNumber, secondPossition + i);
                }
            }
            PrintResult(initalNumber, newNumber);
        }

        static int CheckingBitValue(int n, int possition)
        {
            int bit;
            int mask = 1 << possition;
            int nAndMask = n & mask;
            bit = nAndMask >> possition;
            return bit;
        }

        private static int SwitchingBitValueToOne(int number, int possition)
        {
            int newNumber;
            int mask = 1 << possition;
            newNumber = number | mask;
            return newNumber;
        }

        private static int SwitchingBitValueToZero(int number, int possition)
        {
            int newNumber;
            int mask = ~(1 << possition);
            newNumber = number & mask;
            return newNumber;
        }

        private static void PrintResult(int initialNumber, int newNumber)
        {
            string borderSigns = new string('*', 32);
            Console.WriteLine(borderSigns);
            Console.WriteLine(Convert.ToString(initialNumber, 2).PadLeft(32, '0') + "\t initialNumber");
            Console.WriteLine(borderSigns);
            Console.WriteLine(Convert.ToString(newNumber, 2).PadLeft(32, '0') + "\t newNumber");
            Console.WriteLine(borderSigns + "\n\n");
        }
    }
}
