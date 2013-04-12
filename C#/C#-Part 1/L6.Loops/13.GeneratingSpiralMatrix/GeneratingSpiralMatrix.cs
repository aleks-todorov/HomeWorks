using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.GeneratingSpiralMatrix
{
    class GeneratingSpiralMatrix
    {
        static void Main(string[] args)
        {
            int number;
            do
            {
                Console.WriteLine("Please enter possitive number <= 20");
                number = int.Parse(Console.ReadLine());
            }
            while (number < 0 || number > 20);

            int[,] numberArray = new int[number, number];
            int rows = 0;
            int cols = 0;
            int counter = 1;
            int steps = number;
            int cycles = 0;

            while (counter <= number * number)
            {
                for (int i = 0; i < steps; i++)
                {
                    cols = i + cycles;
                    numberArray[rows, cols] = counter;
                    counter++;
                }
                steps--;
                for (int i = 1; i <= steps; i++)
                {
                    rows = i + cycles;
                    numberArray[rows, cols] = counter;
                    counter++;
                }
                steps--;
                for (int i = steps; i >= 0; i--)
                {
                    cols = i + cycles;
                    numberArray[rows, cols] = counter;
                    counter++;
                }
                for (int i = steps; i > 0; i--)
                {
                    rows = i + cycles;
                    numberArray[rows, cols] = counter;
                    counter++;
                }

                cycles++;
            }

            for (int i = 0; i < number; i++)
            {
                for (int n = 0; n < number; n++)
                {
                    if (number * number <= 100)
                    {
                        Console.Write("{0:00}  ", numberArray[i, n]);
                    }
                    else
                    {
                        Console.Write("{0:000}  ", numberArray[i, n]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
