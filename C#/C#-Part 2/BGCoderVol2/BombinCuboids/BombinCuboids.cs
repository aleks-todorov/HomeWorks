using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Gives Only 40 points... TO Fix
namespace BombinCuboids
{
    class BombinCuboids
    {
        static char[, ,] cube;
        static char[] separators = { ' ' };
        static int[] lettersHit = new int[91];
        static int totalHit = 0;
        const char Empty = ' ';

        static void Main(string[] args)
        {
            InputCube();
            // PrintCube();
            int bombsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < bombsCount; i++)
            {
                string[] bombValues = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                int bombWidth = int.Parse(bombValues[0]);
                int bombHeight = int.Parse(bombValues[1]);
                int bombDepth = int.Parse(bombValues[2]);
                int power = int.Parse(bombValues[3]);

                DetonateBomb(cube, bombWidth, bombHeight, bombDepth, power);
                FallDown(cube);
            }
            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine(totalHit);
            for (int i = 0; i < lettersHit.Length; i++)
            {
                if (lettersHit[i] != 0)
                {
                    Console.WriteLine("{0} {1}", (char)i, lettersHit[i]);
                }
            }
        }

        private static void FallDown(char[, ,] cube)
        {
            int cubeWidth = cube.GetLength(0);
            int cubeHeight = cube.GetLength(1);
            int cubeDepth = cube.GetLength(2);

            for (int pillarWidth = 0; pillarWidth < cubeWidth; pillarWidth++)
            {
                for (int pillarDepth = 0; pillarDepth < cubeDepth; pillarDepth++)
                {
                    FallDownPillar(cube, pillarWidth, pillarDepth);
                }
            }
        }

        private static void FallDownPillar(char[, ,] cube, int pillarWidth, int pillarDepth)
        {
            int pillarHeight = cube.GetLength(1);
            int bottom = 0;

            for (int currentHeight = 0; currentHeight < pillarHeight; currentHeight++)
            {
                if (cube[pillarWidth, currentHeight, pillarDepth] != Empty)
                {
                    if (currentHeight != bottom)
                    {
                        cube[pillarWidth, bottom, pillarDepth] = cube[pillarWidth, currentHeight, pillarDepth];
                        cube[pillarWidth, currentHeight, pillarDepth] = Empty;
                        bottom++;
                    }
                    bottom++;
                }
            }
        }

        private static void DetonateBomb(char[, ,] cube, int bombWidth, int bombHeight, int bombDepth, int power)
        {
            int cubeWidth = cube.GetLength(0);
            int cubeHeight = cube.GetLength(1);
            int cubeDepth = cube.GetLength(2);
            for (int currentWidth = 0; currentWidth < cubeWidth; currentWidth++)
            {
                for (int currentHeight = 0; currentHeight < cubeHeight; currentHeight++)
                {
                    for (int currentDepth = 0; currentDepth < cubeDepth; currentDepth++)
                    {
                        if (cube[currentWidth, currentHeight, currentDepth] != Empty)
                        {
                            int distanceSquarred = GetDistanceSquarred(currentWidth, currentHeight, currentDepth, bombWidth, bombHeight, bombDepth);
                            int pSquarred = power * power;

                            if (distanceSquarred <= pSquarred)
                            {
                                char currentLetter = cube[currentWidth, currentHeight, currentDepth];
                                lettersHit[(int)currentLetter]++;
                                totalHit++;
                                cube[currentWidth, currentHeight, currentDepth] = Empty;
                            }
                        }
                    }
                }
            }
        }

        private static int GetDistanceSquarred(int currentWidth, int currentHeight, int currentDepth, int bombWidth, int bombHeight, int bombDepth)
        {
            int deltaWidth = currentWidth - bombWidth;
            int deltaHeight = currentHeight - bombHeight;
            int deltaDepth = currentDepth - bombDepth;
            return deltaWidth * deltaWidth + deltaHeight * deltaHeight + deltaDepth * deltaDepth;
        }

        private static void PrintCube(char[, ,] cube)
        {
            int width = cube.GetLength(0);
            int height = cube.GetLength(1);
            int depth = cube.GetLength(2);

            for (int currHeigh = 0; currHeigh < height; currHeigh++)
            {
                for (int currDepth = 0; currDepth < depth; currDepth++)
                {
                    for (int currWidht = 0; currWidht < width; currWidht++)
                    {
                        Console.Write(cube[currWidht, currHeigh, currDepth]);
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private static void InputCube()
        {
            string[] dimentsion = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int width = int.Parse(dimentsion[0]);
            int height = int.Parse(dimentsion[1]);
            int depth = int.Parse(dimentsion[2]);
            cube = new char[width, height, depth];

            for (int currHeigh = 0; currHeigh < height; currHeigh++)
            {
                string[] plateRows = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                for (int currDepth = 0; currDepth < depth; currDepth++)
                {
                    string currentPlateRow = plateRows[currDepth];
                    for (int currWidht = 0; currWidht < width; currWidht++)
                    {
                        cube[currWidht, currHeigh, currDepth] = currentPlateRow[currWidht];
                    }
                }
            }
        }
    }
}
