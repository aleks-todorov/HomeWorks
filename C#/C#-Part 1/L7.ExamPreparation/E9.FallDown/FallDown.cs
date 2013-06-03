using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E9.FallDown
{
    class FallDown
    {
        static void Main(string[] args)
        {
            int[] originalNumbers = new int[8];
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
                        bitsArray[j, i] = 0;
                    }
                }
                for (int p = 7; p > 7 - counter; p--)
                {
                    bitsArray[p, i] = 1;
                }
            }
            for (int i = 0; i < 8; i++)
            {
                int number = 0;
                for (int j = 0; j < 8; j++)
                {
                    if (bitsArray[i, j] == 1)
                    {
                        number += (int)Math.Pow(2, 7-j);
                    }
                }
                Console.WriteLine(number);
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
