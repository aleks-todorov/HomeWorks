using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DStars
{
    class Program
    {
        static int width;
        static int height;
        static int depth;
        static char[, ,] cube;
        static int totalStars = 0;
        static int[] letterStarCount = new int[(int)('Z' + 1)];

        static void Main(string[] args)
        {
            ReadingTheInput();
            CountStars();
            //PrintingCube();
            Console.WriteLine(totalStars);
            for (int i = 0; i < letterStarCount.Length; i++)
            {
                if (letterStarCount[i] != 0)
                {
                    Console.WriteLine("{0} {1}", (char)i, letterStarCount[i]);
                }
            }
        }

        private static void PrintingCube()
        {
            for (int currentHeight = 0; currentHeight < height; currentHeight++)
            {
                for (int currentDepth = 0; currentDepth < depth; currentDepth++)
                {
                    for (int currentWidth = 0; currentWidth < width; currentWidth++)
                    {
                        Console.Write(cube[currentWidth, currentHeight, currentDepth]);
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private static void CountStars()
        {
            for (int currentHeight = 1; currentHeight < height - 1; currentHeight++)
            {
                for (int currentDepth = 1; currentDepth < depth - 1; currentDepth++)
                {
                    for (int currentWidth = 1; currentWidth < width - 1; currentWidth++)
                    {
                        if (CheckIsStar(cube, currentWidth, currentHeight, currentDepth) == true)
                        {
                            totalStars++;
                            char symbol = cube[currentWidth, currentHeight, currentDepth];
                            letterStarCount[(int)(symbol)]++;
                        }
                    }
                }
            }
        }

        private static bool CheckIsStar(char[, ,] cube, int currentWidth, int currentHeight, int currentDepth)
        {
            char center = cube[currentWidth, currentHeight, currentDepth];
            if (center != cube[currentWidth + 1, currentHeight, currentDepth])
            {
                return false;
            }
            if (center != cube[currentWidth - 1, currentHeight, currentDepth])
            {
                return false;
            }
            if (center != cube[currentWidth, currentHeight + 1, currentDepth])
            {
                return false;
            }
            if (center != cube[currentWidth, currentHeight - 1, currentDepth])
            {
                return false;
            }
            if (center != cube[currentWidth, currentHeight, currentDepth + 1])
            {
                return false;
            }
            if (center != cube[currentWidth, currentHeight, currentDepth - 1])
            {
                return false;
            }

            return true;
        }

        private static void ReadingTheInput()
        {
            char[] separator = { ' ' };
            string[] dimentisons = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            width = int.Parse(dimentisons[0]);
            height = int.Parse(dimentisons[1]);
            depth = int.Parse(dimentisons[2]);
            cube = new char[width, height, depth];

            for (int currentHeight = 0; currentHeight < height; currentHeight++)
            {
                string[] rows = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);

                for (int currentDepth = 0; currentDepth < depth; currentDepth++)
                {
                    string currRow = rows[currentDepth];
                    for (int currentWidth = 0; currentWidth < width; currentWidth++)
                    {
                        cube[currentWidth, currentHeight, currentDepth] = currRow[currentWidth];
                    }
                }
            }
        }
    }
}
