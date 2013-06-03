using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E5.SubsetSumVersion2
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            long[] nums = new long[n];
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                nums[i] = long.Parse(Console.ReadLine());
            }
            int maxI = 1;
            for (int i = 0; i < n; i++)
            {
                maxI *= 2;
            }
            maxI--;
            //maxI = (int)Math.Pow((double)2,n) -1; 
            for (int i = 1; i <= maxI; i++)
            {
                long currentSum = 0;
                for (int j = 0; j < n; j++)
                {
                    int mask = 1 << j;
                    int nAndMask = i & mask;
                    int bit = nAndMask >> j;
                    if (bit == 1)
                    {
                        currentSum += nums[j];
                    }
                }
                if (currentSum == s)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
