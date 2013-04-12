using System;
using System.Collections.Generic;
using System.IO;

//100/100
namespace MaxWalk
{
    class MaxWalk
    {
        static bool[, ,] visited;

        static void Main(string[] args)
        {
            int[, ,] cube;
            int w;
            int h;
            int d;

            string line = Console.ReadLine();
            string[] splitLine = line.Split();
            w = Int32.Parse(splitLine[0]);
            h = Int32.Parse(splitLine[1]);
            d = Int32.Parse(splitLine[2]);
            cube = new int[w, h, d];
            visited = new bool[w, h, d];

            for (int y = 0; y < h; y++)
            {
                line = Console.ReadLine();
                splitLine = line.Split(new char[] { '|' });
                for (int z = 0; z < d; z++)
                {
                    string[] splitSegment = splitLine[z].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int x = 0; x < w; x++)
                    {
                        cube[x, y, z] = Int32.Parse(splitSegment[x]);
                    }
                }
            }
            // }

            int sum = cube[w / 2, h / 2, d / 2];
            int[] nextPosition = GetNextPosition(ref cube, w / 2, h / 2, d / 2);
            visited[w / 2, h / 2, d / 2] = true;
            while (nextPosition[0] != -1)
            {
                sum += cube[nextPosition[0], nextPosition[1], nextPosition[2]];
                visited[nextPosition[0], nextPosition[1], nextPosition[2]] = true;
                nextPosition = GetNextPosition(ref cube, nextPosition[0], nextPosition[1], nextPosition[2]);
            }
            Console.WriteLine(sum);
        }

        /// <summary>
        /// Finds the next position in the MaxWalk
        /// </summary>
        /// <param name="cube"></param>
        /// <param name="currentW">The width position on which the walk is now</param>
        /// <param name="currentH">The height position on which the walk is now</param>
        /// <param name="currentD">The depth position on which the walk is now</param>
        /// <returns>Returns the next position in the walk (w,h,d). If the walk needs to stop (the stop conditions are satisfied, will return -1, -1, -1)</returns>
        static int[] GetNextPosition(ref int[, ,] cube, int currentW, int currentH, int currentD)
        {
            int largestNumber = Int32.MinValue;
            int numbersIndexW = -1;
            int numbersIndexH = -1;
            int numbersIndexD = -1; ;

            //look horizontally
            for (int x = 0; x < cube.GetLength(0); x++)
            {
                if (x == currentW)
                {
                    continue;
                }
                if (largestNumber < cube[x, currentH, currentD])
                {
                    largestNumber = cube[x, currentH, currentD];
                    if (visited[x, currentH, currentD])
                    {
                        numbersIndexW = -1;
                        numbersIndexH = -1;
                        numbersIndexD = -1;
                    }
                    else
                    {
                        numbersIndexW = x;
                        numbersIndexH = currentH;
                        numbersIndexD = currentD;
                    }
                }
                else if (largestNumber == cube[x, currentH, currentD])
                {
                    numbersIndexW = -1;
                    numbersIndexH = -1;
                    numbersIndexD = -1;
                }
            }

            //look vertically
            for (int y = 0; y < cube.GetLength(1); y++)
            {
                if (y == currentH)
                {
                    continue;
                }
                if (largestNumber < cube[currentW, y, currentD])
                {
                    largestNumber = cube[currentW, y, currentD];
                    if (visited[currentW, y, currentD])
                    {
                        numbersIndexW = -1;
                        numbersIndexH = -1;
                        numbersIndexD = -1;
                    }
                    else
                    {
                        numbersIndexW = currentW;
                        numbersIndexH = y;
                        numbersIndexD = currentD;
                    }
                }
                else if (largestNumber == cube[currentW, y, currentD])
                {
                    numbersIndexW = -1;
                    numbersIndexH = -1;
                    numbersIndexD = -1;
                }
            }

            //look in depth
            for (int z = 0; z < cube.GetLength(2); z++)
            {
                if (z == currentD)
                {
                    continue;
                }
                if (largestNumber < cube[currentW, currentH, z])
                {
                    largestNumber = cube[currentW, currentH, z];
                    if (visited[currentW, currentH, z])
                    {
                        numbersIndexW = -1;
                        numbersIndexH = -1;
                        numbersIndexD = -1;
                    }
                    else
                    {
                        numbersIndexW = currentW;
                        numbersIndexH = currentH;
                        numbersIndexD = z;
                    }
                }
                else if (largestNumber == cube[currentW, currentH, z])
                {
                    numbersIndexW = -1;
                    numbersIndexH = -1;
                    numbersIndexD = -1;
                }
            }

            int[] result = new int[] { numbersIndexW, numbersIndexH, numbersIndexD };
            return result;
        }
    }
}


