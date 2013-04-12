using System;
using System.Collections.Generic;
using System.Text;

//80/100 Can't beat the time limit
class BombingCuboids
{
    static SortedDictionary<char, int> destroyed = new SortedDictionary<char, int>();
    static int totalDestroyed = 0;

    static void Main(string[] args)
    {
        string line = Console.ReadLine();
        string[] splitLine = line.Split();
        int w = Int32.Parse(splitLine[0]);
        int h = Int32.Parse(splitLine[1]);
        int d = Int32.Parse(splitLine[2]);
        char[, ,] cube = new char[h, w, d];

        for (int i = 0; i < h; i++)
        {
            line = Console.ReadLine();
            splitLine = line.Split();
            for (int o = 0; o < d; o++)
            {
                for (int u = 0; u < w; u++)
                {
                    cube[i, u, o] = splitLine[o][u];
                }
            }
        }

        int bombsNumber = Int32.Parse(Console.ReadLine());
        for (int bomb = 0; bomb < bombsNumber; bomb++)
        {
            string[] splitBombInput = Console.ReadLine().Split(); //splitInput[bomb + 1].Split();
            int bombW = Int32.Parse(splitBombInput[0]);
            int bombH = Int32.Parse(splitBombInput[1]);
            int bombD = Int32.Parse(splitBombInput[2]);
            int bombP = Int32.Parse(splitBombInput[3]);

            DestroyCubes(ref cube, bombW, bombH, bombD, bombP);
            FallDown(ref cube);
        }

        StringBuilder output = new StringBuilder();
        output.AppendLine(totalDestroyed.ToString());
        foreach (var color in destroyed)
        {
            output.Append(color.Key);
            output.Append(" ");
            output.AppendLine(color.Value.ToString());
        }
        Console.WriteLine(output.ToString().TrimEnd());
    }

    static void FallDown(ref char[, ,] cube)
    {
        for (int u = 0; u < cube.GetLength(1); u++)
        {
            for (int o = 0; o < cube.GetLength(2); o++)
            {
                int zeroCount = 0;
                List<char> remainingCubes = new List<char>();
                for (int i = 0; i < cube.GetLength(0); i++)
                {
                    if (cube[i, u, o] == '0')
                    {
                        zeroCount++;
                    }
                    else
                    {
                        remainingCubes.Add(cube[i, u, o]);
                    }
                }

                if (zeroCount != 0)
                {
                    for (int i = 0; i < remainingCubes.Count; i++)
                    {
                        cube[i, u, o] = remainingCubes[i];
                    }
                    for (int i = remainingCubes.Count; i < cube.GetLength(0); i++)
                    {
                        cube[i, u, o] = '0';
                    }
                }
            }
        }
    }

    static void DestroyCubes(ref char[, ,] cube, int bombW, int bombH, int bombD, int bombP)
    {
        int rangeStartW = bombW - bombP;
        if (rangeStartW < 0)
        {
            rangeStartW = 0;
        }

        int rangeEndW = bombW + bombP;
        if (rangeEndW >= cube.GetLength(1))
        {
            rangeEndW = cube.GetLength(1) - 1;
        }

        int rangeStartH = bombH - bombP;
        if (rangeStartH < 0)
        {
            rangeStartH = 0;
        }

        int rangeEndH = bombH + bombP;
        if (rangeEndH >= cube.GetLength(0))
        {
            rangeEndH = cube.GetLength(0) - 1;
        }

        int rangeStartD = bombD - bombP;
        if (rangeStartD < 0)
        {
            rangeStartD = 0;
        }

        int rangeEndD = bombD + bombP;
        if (rangeEndD >= cube.GetLength(2))
        {
            rangeEndD = cube.GetLength(2) - 1;
        }

        for (int i = rangeStartH; i <= rangeEndH; i++)
        {
            for (int u = rangeStartW; u <= rangeEndW; u++)
            {
                for (int o = rangeStartD; o <= rangeEndD; o++)
                {
                    if (CheckIfBombReaches(bombW, bombH, bombD, bombP, i, u, o))
                    {
                        if (cube[i, u, o] != '0')
                        {
                            totalDestroyed++;
                            if (destroyed.ContainsKey(cube[i, u, o]))
                            {
                                destroyed[cube[i, u, o]]++;
                            }
                            else
                            {
                                destroyed.Add(cube[i, u, o], 1);
                            }
                        }
                        cube[i, u, o] = '0';
                    }
                }
            }
        }
    }

    static bool CheckIfBombReaches(int bombW, int bombH, int bombD, int bombP, int i, int u, int o)
    {
        int side1 = Math.Abs(bombW - u);
        int side2 = Math.Abs(bombH - i);
        int side3 = Math.Abs(bombD - o);

        double distance = Math.Sqrt(side1 * side1 + side2 * side2 + side3 * side3);
        if (distance <= bombP)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}