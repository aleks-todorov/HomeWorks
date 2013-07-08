using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        n = n / 2;

        BigInteger result = CalculateFactorial(2 * n) / (CalculateFactorial(n + 1) * CalculateFactorial(n));
        Console.WriteLine(result);
    }

    static BigInteger CalculateFactorial(BigInteger number)
    {
        BigInteger factorial = 1;

        for (BigInteger i = 1; i <= number; i++)
        {
            factorial *= i;
        }

        return factorial;
    }
}

