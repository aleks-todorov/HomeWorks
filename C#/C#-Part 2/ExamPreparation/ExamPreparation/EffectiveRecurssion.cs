using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation
{
    class EffectiveRecurssion
    {
        static long[] numbers;

        static void Main(string[] args)
        {
            Console.WriteLine("n = ");
            int n = int.Parse(Console.ReadLine());
            numbers = new long[n + 2];
            numbers[1] = 1;
            numbers[2] = 1;
            long result = Fib(n);
            Console.WriteLine("fib{0} = {1}", n, result);
        }

        static long Fib(int n)
        {
            if (0 == numbers[n])
            {
                numbers[n] = Fib(n - 1) + Fib(n - 2);
            }
            return numbers[n];
        }
    }
}
