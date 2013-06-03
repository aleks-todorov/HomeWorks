using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E7.OddNumber
{
    class OddNumber
    {
        static void Main(string[] args)
        {
            //TO DO: check further why,brings only 80 points.
            int N = int.Parse(Console.ReadLine());
            long[] numberArray = new long[N];
            for (int i = 0; i < N; i++)
            {
                numberArray[i] = long.Parse(Console.ReadLine());
            }
            Array.Sort(numberArray);
            if (N == 1)
            {
                Console.WriteLine(numberArray[0]);
            }
            for (int i = 0; i < N && N > 1; i++)
            {
                if (i == 0 && numberArray[i] != numberArray[i + 1])
                {
                    Console.WriteLine(numberArray[i]);
                    break;
                }
                if (i == N - 1 && numberArray[i] != numberArray[i - 1])
                {
                    Console.WriteLine(numberArray[i]);
                    break;
                }
                if (i > 0 && numberArray[i] != numberArray[i - 1] && numberArray[i] != numberArray[i + 1])
                {
                    Console.WriteLine(numberArray[i]);
                    break;
                }
            }
        }
    }
}