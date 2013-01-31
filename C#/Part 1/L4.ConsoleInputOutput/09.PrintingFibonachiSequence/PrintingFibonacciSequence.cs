using System;
using System.Numerics;

namespace _09.PrintingFibonachiSequence
{
    class PrintingFibonacciSequence
    {
        static void Main(string[] args)
        {
            BigInteger fibonacciNumber = 0;
            BigInteger previousNumber = 1;
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(fibonacciNumber);
                fibonacciNumber = fibonacciNumber + previousNumber;
                previousNumber = fibonacciNumber - previousNumber;

            }
        }
    }
}
