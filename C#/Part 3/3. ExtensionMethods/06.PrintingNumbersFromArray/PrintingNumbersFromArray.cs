using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Task: 6
//Write a program that prints from given array of integers all numbers that are divisible by 7 and 3.
//Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

namespace _06.PrintingNumbersFromArray
{
    class PrintingNumbersFromArray
    {
        static void Main(string[] args)
        {
            var list = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            FindNumbersWithLambdaExpression(list);
            FindNumbersWithLINQ(list);
        }

        private static void FindNumbersWithLINQ(List<int> list)
        {
            var numbers = from number in list
                          where (number % 21 == 0)
                          select number;
            PrintResult(numbers);
        }

        private static void FindNumbersWithLambdaExpression(List<int> list)
        {
            List<int> numbers = list.FindAll(x => (x % (3 * 7)) == 0);
            PrintResult(numbers);
        }

        private static void PrintResult(IEnumerable<int> numbers)
        {
            foreach (var num in numbers)
            {
                Console.Write("{0} ", num);
            }
            Console.WriteLine();
        }
    }
}
