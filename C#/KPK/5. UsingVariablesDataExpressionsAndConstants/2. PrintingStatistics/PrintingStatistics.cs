using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.PrintingStatistics
{
    class PrintingStatistics
    {
        static void Main(string[] args)
        {
            int[] numberArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var numberArrayLenght = numberArray.Length;
            PrintingStatistics(numberArray, numberArrayLenght);
        }

        private static void PrintingStatistics(int[] numberArray, int numberArrayLenght)
        {
            PrintMaxValue(numberArray, numberArrayLenght);
            PrintMinValue(numberArray, numberArrayLenght);
            PrintAverageValue(numberArray, numberArrayLenght);
        }

        private static void PrintAverageValue(int[] numberArray, int numberArrayLenght)
        {
            var sum = 0;
            for (int i = 0; i < numberArrayLenght; i++)
            {
                sum += numberArray[i];
            }

            var averageValue = sum / numberArrayLenght;
            Console.WriteLine("Average value is: {0}", averageValue);

        }

        private static void PrintMinValue(int[] numberArray, int numberArrayLenght)
        {
            var minValue = numberArray[0];

            for (int i = 0; i < numberArrayLenght; i++)
            {
                if (numberArray[i] < minValue)
                {
                    minValue = numberArray[i];
                }
            }

            Console.WriteLine("Min value is: {0}", minValue);
        }

        private static void PrintMaxValue(int[] numberArray, int numberArrayLenght)
        {
            var maxValue = numberArray[0];

            for (int i = 0; i < numberArrayLenght; i++)
            {
                if (numberArray[i] > maxValue)
                {
                    maxValue = numberArray[i];
                }
            }

            Console.WriteLine("Max value is: {0}", maxValue);
        }
    }
}
