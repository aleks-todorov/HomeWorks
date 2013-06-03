using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace E4.BinaryDigitsCount
{
    class BinaryDigitsCount
    {
        static void Main()
        {
            int B = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                uint number = uint.Parse(Console.ReadLine());
                int totalCount = 0;
                while (number != 0)
                {
                    if ((number & 1) == B)
                    {
                        totalCount++;
                    }
                    number = number >> 1; 
                }
                Console.WriteLine(totalCount);
            }
        }

    }
}