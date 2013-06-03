using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E7.LeastMajorityMultiple
{
    class LeastMajorityMultiple
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());
            int multiplier = 0;

            for (int i = 1; true; i++)
            {
                if (i % a == 0)
                {
                    multiplier++;
                }
                if (i % b == 0)
                {
                    multiplier++;
                }
                if (i % c == 0)
                {
                    multiplier++;
                }
                if (i % d == 0)
                {
                    multiplier++;
                }
                if (i % e == 0)
                {
                    multiplier++;
                }
                if (multiplier >= 3)
                {
                    Console.WriteLine(i);
                    break;
                }
                multiplier = 0;
            }
        }
    }
}
