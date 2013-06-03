using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace E6.MathExpression
{
    class MathExpression
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            decimal N = decimal.Parse(Console.ReadLine());
            decimal M = decimal.Parse(Console.ReadLine());
            decimal P = decimal.Parse(Console.ReadLine());
            decimal result = ((N * N + (1 / (M * P)) + 1337) / (N - 128.523123123m * P)) + (decimal)Math.Sin((int)M % 180);
            Console.WriteLine("{0:F6}", result);

        }
    }
}
