using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DSlice
{
    class Program
    {
        static int[, ,] cube;
        static int width;
        static int height;
        static int depth;
        static int cubeSum = 0;
        static long currentSum = 0;
        static int slices = 0;
        static char[] separators = { ' ', '|' };

        static void Main(string[] args)
        {
            InputCube();
            //PrintCube();
            CheckForSlices();
            Console.WriteLine(slices);
        }

        private static void CheckForSlices()
        {
            CheckForHeightSlices();
            CheckForDeptSlices();
            CheckForWidthSlices();
        }

        private static void CheckForWidthSlices()
        {
            currentSum = 0;
            for (int currHeight = 0; currHeight < height - 1; currHeight++)
            {
                for (int currWidth = 0; currWidth < width; currWidth++)
                {
                    for (int currDepth = 0; currDepth < depth; currDepth++)
                    {
                        currentSum += cube[currWidth, currHeight, currDepth];
                    }
                }
                CompareParts();
            }
        }

        private static void CheckForDeptSlices()
        {
            currentSum = 0;
            for (int currDepth = 0; currDepth < depth - 1; currDepth++)
            {
                for (int currWidth = 0; currWidth < width; currWidth++)
                {
                    for (int currHeight = 0; currHeight < height; currHeight++)
                    {
                        currentSum += cube[currWidth, currHeight, currDepth];
                    }
                }
                CompareParts();
            }
        }

        private static void CheckForHeightSlices()
        {
            currentSum = 0;
            for (int currWidth = 0; currWidth < width - 1; currWidth++)
            {
                for (int currHeight = 0; currHeight < height; currHeight++)
                {
                    for (int currDepth = 0; currDepth < depth; currDepth++)
                    {
                        currentSum += cube[currWidth, currHeight, currDepth];
                    }
                }
                CompareParts();
            }
        }

        private static void PrintCube()
        {
            for (int currHeight = 0; currHeight < height; currHeight++)
            {
                for (int currDepth = 0; currDepth < depth; currDepth++)
                {
                    for (int currWidth = 0; currWidth < width; currWidth++)
                    {
                        Console.Write(cube[currWidth, currHeight, currDepth]);
                    }
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }

        private static void CompareParts()
        {
            if (currentSum * 2 == cubeSum)
            {
                slices++;
            }
        }

        private static void InputCube()
        {
            string[] line = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            width = int.Parse(line[0]);
            height = int.Parse(line[1]);
            depth = int.Parse(line[2]);
            cube = new int[width, height, depth];

            for (int currHeigh = 0; currHeigh < height; currHeigh++)
            {
                string[] plateRows = Console.ReadLine().Split('|');
                for (int currDepth = 0; currDepth < depth; currDepth++)
                {
                    string[] currentPlateRow = plateRows[currDepth].Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    for (int currWidht = 0; currWidht < width; currWidht++)
                    {
                        cube[currWidht, currHeigh, currDepth] = int.Parse(currentPlateRow[currWidht]);
                        cubeSum += cube[currWidht, currHeigh, currDepth];
                    }
                }
            }
        }
    }
}
