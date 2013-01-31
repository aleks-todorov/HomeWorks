using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.ProgramThatSwapsNBits
{
    class ProgramThatSwapsNBits
    {
        static void Main(string[] args)
        {

            //* Write a program that exchanges bits {p, p+1, …, p+k-1) with 
            //bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.

            Console.WriteLine("Please enter number");
            int initialNumber = int.Parse(Console.ReadLine());
            int newNumber = initialNumber;
            Console.WriteLine("Please enter first Possition for swaping");
            int firstPossition = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter second Possition for swaping");
            int secondPossition = int.Parse(Console.ReadLine());
            Console.WriteLine("Please specify how many bits we are goint to swap");
            int numberOfBits = int.Parse(Console.ReadLine());
            if (firstPossition < 0 || firstPossition > 32 || secondPossition < firstPossition || secondPossition > 32 || secondPossition > 32 - numberOfBits)
            {
                Console.WriteLine("Please enter proper inital values");
            }
            else
            {
                int[] firstBitArray = new int[numberOfBits];
                int[] secondBitArray = new int[numberOfBits];
                for (int i = 0; i < numberOfBits; i++)
                {
                    firstBitArray[i] = CheckingBitValue(initialNumber, firstPossition + i);
                    secondBitArray[i] = CheckingBitValue(initialNumber, secondPossition + i);
                }
                for (int i = 0; i < numberOfBits; i++)
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
                PrintResult(initialNumber, newNumber);
            }
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
