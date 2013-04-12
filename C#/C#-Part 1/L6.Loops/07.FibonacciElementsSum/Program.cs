using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _07.FibonacciElementsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfElements = int.Parse(Console.ReadLine());
            BigInteger sum = 0;
            BigInteger fibonacciNumber = 0;
            BigInteger previousNumber = 1;
            for (int i = 0; i < numberOfElements; i++)
            {
                sum = sum + fibonacciNumber;
                Console.Write(fibonacciNumber + "+");
                fibonacciNumber = fibonacciNumber + previousNumber;
                previousNumber = fibonacciNumber - previousNumber;

            }
            Console.WriteLine("={0}",sum);
        }
    }
}
