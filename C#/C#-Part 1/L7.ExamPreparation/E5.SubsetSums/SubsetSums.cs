using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E5.SubsetSums
{
    class SubsetSums
    {
        static void Main()
        {
            long S = long.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            long[] numbers = new long[N];
            int totalSubsets = 0;

            for (int i = 0; i < N; i++)
            {
                numbers[i] = long.Parse(Console.ReadLine());
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                long currentNumber = numbers[i];
                if (currentNumber == S)
                {
                    totalSubsets++;
                }
                for (int n = 0; n < numbers.Length; n++)
                {
                    if (n == i)
                    {
                        break; 
                    }
                    if (currentNumber + numbers[n] == S)
                    {
                        totalSubsets++; 
                    }
                }
            }
            Console.WriteLine(totalSubsets);
        }
    }
}
