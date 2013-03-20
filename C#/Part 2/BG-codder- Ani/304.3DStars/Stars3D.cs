using System;
using System.Collections.Generic;

//100/100
class Stars3D
{
    static void Main(string[] args)
    {
        int w;
        int h;
        int d;
        char[, ,] cube;

        string line = Console.ReadLine();
        string[] splitLine = line.Split();
        w = Int32.Parse(splitLine[0]);
        h = Int32.Parse(splitLine[1]);
        d = Int32.Parse(splitLine[2]);

        cube = new char[w, h, d];

        for (int i = 0; i < h; i++)
        {
            line = Console.ReadLine();
            splitLine = line.Split();
            for (int o = 0; o < d; o++)
            {
                for (int u = 0; u < w; u++)
                {
                    cube[u, i, o] = splitLine[o][u];
                }
            }
        }

        SortedDictionary<char, int> result = new SortedDictionary<char, int>();
        int totalNumberOfStars = 0;

        for (int u = 1; u < w - 1; u++)
        {
            for (int i = 1; i < h - 1; i++)
            {
                for (int o = 1; o < d - 1; o++)
                {
                    if (IsCenterOfStar(u, i, o, ref cube))
                    {
                        if (!result.ContainsKey(cube[u, i, o]))
                        {
                            result.Add(cube[u, i, o], 1);
                            totalNumberOfStars++;
                        }
                        else
                        {
                            result[cube[u, i, o]]++;
                            totalNumberOfStars++;
                        }
                    }
                }
            }
        }

        Console.WriteLine(totalNumberOfStars);

        foreach (KeyValuePair<char, int> pair in result)
        {
            Console.WriteLine(pair.Key + " " + pair.Value);
        }
    }

    static bool IsCenterOfStar(int indexW, int indexH, int indexD, ref char[, ,] cube)
    {
        char color = cube[indexW, indexH, indexD];
        if (cube[indexW - 1, indexH, indexD] == color &&
            cube[indexW + 1, indexH, indexD] == color &&
            cube[indexW, indexH + 1, indexD] == color &&
            cube[indexW, indexH - 1, indexD] == color &&
            cube[indexW, indexH, indexD + 1] == color &&
            cube[indexW, indexH, indexD - 1] == color)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}