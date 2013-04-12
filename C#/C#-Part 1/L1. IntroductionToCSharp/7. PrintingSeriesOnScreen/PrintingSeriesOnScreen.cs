using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintingSeriesOnScreen
{
    class PrintingSeriesOnScreen
    {
        static void Main(string[] args)
        {
            int firstValue = 2;
            int secondValue = -3;

            Console.Write(firstValue + " " + secondValue + " ");
            for (int i = 0; i <= 100; i++)
            {
                if (i % 2 == 0)
                {
                    firstValue += 2;
                    Console.Write(firstValue + " ");
                }
                else
                {
                    secondValue -= 2;
                    Console.Write(secondValue + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
