using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes
{
    class Tubes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[] tube = new int[n];
            for (int i = 0; i < n; i++)
            {
                tube[i] = int.Parse(Console.ReadLine());
            }
            int left = 0;
            int right = tube.Max() + 2;
            int maxTube = -1;
            int middlePossition = (left + right) / 2;
            int currentNumberOfTubes = 0;
            while (left <= right)
            {
                currentNumberOfTubes = 0;
                for (int i = 0; i < tube.Length; i++)
                {
                    currentNumberOfTubes += tube[i] / middlePossition;
                }
                if (currentNumberOfTubes >= m)
                {
                    left = middlePossition + 1;
                    maxTube = middlePossition;
                }
                else
                {
                    right = middlePossition - 1;
                }
                middlePossition = (left + right) / 2;
            }
            Console.WriteLine(maxTube);
        }
    }
}
