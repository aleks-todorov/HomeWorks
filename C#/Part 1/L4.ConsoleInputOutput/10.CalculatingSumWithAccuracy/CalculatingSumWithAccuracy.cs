using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.CalculatingSumWithAccuracy
{
    class CalculatingSumWithAccuracy
    {
        static void Main(string[] args)
        {
            decimal sum = 1.0m;
            int cicles = int.Parse(Console.ReadLine());
            for (decimal i = 2; i <= cicles + 1; i++)
            {
                if (i % 2 == 0)
                {
                    sum = sum + (1 / i);
                }
                else
                {
                    sum = sum - (1 / i);
                }
                Console.WriteLine("{0:0.000}",sum);
            }
        }
    }
}
