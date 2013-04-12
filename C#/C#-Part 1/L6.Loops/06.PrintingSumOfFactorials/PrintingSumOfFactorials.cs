using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.PrintingSumOfFactorials
{
    class PrintingSumOfFactorials
    {
        static void Main(string[] args)
        {
            //Write a program that, for a given two integer numbers N and X,
            //calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN
            //to be fixed...
            Console.Write("N= ");
            double N = int.Parse(Console.ReadLine());
            Console.Write("K= ");
            double X = int.Parse(Console.ReadLine());
            double factorialN = 1.0;

            double powerX = 1.0;
            double sum = 1.0;
            for (double i = 0; i < N; i++)
            {
                factorialN = factorialN * i;
                powerX = Math.Pow(X, i);
                sum = sum + (factorialN / powerX); 
            }
            Console.WriteLine("The result is: {0}",sum);
        }
    }
}
