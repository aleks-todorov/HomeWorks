using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.CalculatingTheCatalanNumber
{
    class CalculatingTheCatalanNumber
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                n = int.Parse(Console.ReadLine());
            }
            while (n < 0);
            decimal catalanNumber;
            decimal nFactorial = 1;
            decimal twoNFactorial = 1;
            decimal nPlusOneFactorial = 1;
            for (int i = 1; i <= 2*n; i++)
            {
                if (i <= n + 1)
                {
                    nPlusOneFactorial = nPlusOneFactorial * i;
                }
                if (i <= n)
                {
                    nFactorial = nFactorial * i;
                }
                twoNFactorial = twoNFactorial * i;
            }
            catalanNumber = twoNFactorial / (nPlusOneFactorial * nFactorial);
            Console.WriteLine("The Catalan Number is: {0}", catalanNumber);
        }
    }
}
