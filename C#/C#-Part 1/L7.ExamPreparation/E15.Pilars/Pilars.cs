using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E9.FallDown
{
    class FallDown
    {   
        //Solution Gives 90 points
        static void Main(string[] args)
        {
            int[] originalNumbers = new int[8];
            int[] columSum = new int[8];
            for (int i = 0; i < 8; i++)
            {
                originalNumbers[i] = int.Parse(Console.ReadLine());
            }
            int[,] bitsArray = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 7; j >= 0; j--)
                {
                    bitsArray[i, j] = CheckingBitValue(originalNumbers[i], 7 - j);
                }
            }
            int counter = 0;
            for (int i = 0; i < 8; i++)
            {
                counter = 0;
                for (int j = 0; j < 8; j++)
                {

                    if (bitsArray[j, i] == 1)
                    {
                        counter++;
                    }
                }
                columSum[i] = counter;
            }
            for (int i = 1; i <= 7; i++)
            {
                int firstSum = 0;
                int secondSum = 0;
                for (int j = 0; j < i; j++)
                {
                    firstSum += columSum[j];
                }

                for (int p = i + 1; p < columSum.Length; p++)
                {
                    secondSum += columSum[p];
                }

                if (firstSum == secondSum)
                {
                    Console.WriteLine(7 - i);
                    Console.WriteLine(firstSum);
                    break;
                }

                if (i == 7)
                {
                    Console.WriteLine("No");
                }
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
    }
}
