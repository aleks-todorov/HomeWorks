using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

//90/100, I think I never made it to the last diagonals, too much code.
namespace Lines3D
{
    class Program
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

            cube = new char[h, w, d];

            for (int u = 0; u < h; u++)
            {
                line = Console.ReadLine();
                splitLine = line.Split();
                for (int o = 0; o < d; o++)
                {
                    for (int i = 0; i < w; i++)
                    {
                        cube[u, i, o] = splitLine[o][i];
                    }
                }
            }

            int longestLineLength = Int32.MinValue;
            int currentLineLength = 1;
            int numberOfLongestLines = 0;

            #region lines with common wall
            //first we check all lines with common wall
            for (int u = 0; u < h; u++)
            {
                for (int i = 0; i < w; i++)
                {
                    for (int o = 0; o < d; o++)
                    {
                        if (o != d - 1 && cube[u, i, o] == cube[u, i, o + 1])
                        {
                            currentLineLength++;
                        }
                        else
                        {
                            if (longestLineLength < currentLineLength)
                            {
                                longestLineLength = currentLineLength;
                                numberOfLongestLines = 1;
                            }
                            else if (longestLineLength == currentLineLength)
                            {
                                numberOfLongestLines++;
                            }
                            currentLineLength = 1;
                        }
                    }
                }
            }

            for (int u = 0; u < h; u++)
            {
                for (int o = 0; o < d; o++)
                {
                    for (int i = 0; i < w; i++)
                    {
                        if (i != w - 1 && cube[u, i, o] == cube[u, i + 1, o])
                        {
                            currentLineLength++;
                        }
                        else
                        {
                            if (longestLineLength < currentLineLength)
                            {
                                longestLineLength = currentLineLength;
                                numberOfLongestLines = 1;
                            }
                            else if (longestLineLength == currentLineLength)
                            {
                                numberOfLongestLines++;
                            }
                            currentLineLength = 1;
                        }
                    }
                }
            }

            for (int i = 0; i < w; i++)
            {
                for (int o = 0; o < d; o++)
                {
                    for (int u = 0; u < h; u++)
                    {
                        if (u != h - 1 && cube[u, i, o] == cube[u + 1, i, o])
                        {
                            currentLineLength++;
                        }
                        else
                        {
                            if (longestLineLength < currentLineLength)
                            {
                                longestLineLength = currentLineLength;
                                numberOfLongestLines = 1;
                            }
                            else if (longestLineLength == currentLineLength)
                            {
                                numberOfLongestLines++;
                            }
                            currentLineLength = 1;
                        }
                    }
                }
            }
            #endregion

            #region lines with a common segment
            //we check all diagonals that are placed on a plane, lines with a common segment
            for (int o = 0; o < d; o++)
            {
                for (int dif = 0 - (h - 1); dif < 0 + w - 1; dif++)
                {
                    for (int u = 0; u < h; u++)
                    {
                        int i = u - dif;
                        if (u >= 0 && i >= 0 && u < h && i < w)
                        {
                            if (u != h - 1 && i != w - 1 && cube[u, i, o] == cube[u + 1, i + 1, o])
                            {
                                currentLineLength++;
                            }
                            else
                            {
                                if (longestLineLength < currentLineLength)
                                {
                                    longestLineLength = currentLineLength;
                                    numberOfLongestLines = 1;
                                }
                                else if (longestLineLength == currentLineLength)
                                {
                                    numberOfLongestLines++;
                                }
                                currentLineLength = 1;
                            }
                        }
                    }
                }

                for (int count = 0 - (h - 1); count < w; count++)
                {
                    for (int u = h - 1, i = count; u >= 0; u--, i++)
                    {
                        if (u >= 0 && i >= 0 && u < h && i < w)
                        {
                            if (u != 0 && i != w - 1 && cube[u, i, o] == cube[u - 1, i + 1, o])
                            {
                                currentLineLength++;
                            }
                            else
                            {
                                if (longestLineLength < currentLineLength)
                                {
                                    longestLineLength = currentLineLength;
                                    numberOfLongestLines = 1;
                                }
                                else if (longestLineLength == currentLineLength)
                                {
                                    numberOfLongestLines++;
                                }
                                currentLineLength = 1;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < w; i++)
            {
                for (int dif = 0 - (h - 1); dif < 0 + d - 1; dif++)
                {
                    for (int u = 0; u < h; u++)
                    {
                        int o = u - dif;
                        if (u >= 0 && o >= 0 && u < h && o < d)
                        {
                            if (u != h - 1 && o != d - 1 && cube[u, i, o] == cube[u + 1, i, o + 1])
                            {
                                currentLineLength++;
                            }
                            else
                            {
                                if (longestLineLength < currentLineLength)
                                {
                                    longestLineLength = currentLineLength;
                                    numberOfLongestLines = 1;
                                }
                                else if (longestLineLength == currentLineLength)
                                {
                                    numberOfLongestLines++;
                                }
                                currentLineLength = 1;
                            }
                        }
                    }
                }

                for (int count = 0 - (h - 1); count < d; count++)
                {
                    for (int u = h - 1, o = count; u >= 0; u--, o++)
                    {
                        if (u >= 0 && o >= 0 && u < h && o < d)
                        {
                            if (u != 0 && o != d - 1 && cube[u, i, o] == cube[u - 1, i, o + 1])
                            {
                                currentLineLength++;
                            }
                            else
                            {
                                if (longestLineLength < currentLineLength)
                                {
                                    longestLineLength = currentLineLength;
                                    numberOfLongestLines = 1;
                                }
                                else if (longestLineLength == currentLineLength)
                                {
                                    numberOfLongestLines++;
                                }
                                currentLineLength = 1;
                            }
                        }
                    }
                }
            }

            for (int u = 0; u < h; u++)
            {
                for (int dif = 0 - (d - 1); dif < 0 + w - 1; dif++)
                {
                    for (int o = 0; o < d; o++)
                    {
                        int i = o - dif;
                        if (o >= 0 && i >= 0 && o < d && i < w)
                        {
                            if (o != d - 1 && i != w - 1 && cube[u, i, o] == cube[u, i + 1, o + 1])
                            {
                                currentLineLength++;
                            }
                            else
                            {
                                if (longestLineLength < currentLineLength)
                                {
                                    longestLineLength = currentLineLength;
                                    numberOfLongestLines = 1;
                                }
                                else if (longestLineLength == currentLineLength)
                                {
                                    numberOfLongestLines++;
                                }
                                currentLineLength = 1;
                            }
                        }
                    }
                }

                for (int count = 0 - (d - 1); count < w; count++)
                {
                    for (int o = d - 1, i = count; o >= 0; o--, i++)
                    {
                        if (o >= 0 && i >= 0 && o < d && i < w)
                        {
                            if (o != 0 && i != w - 1 && cube[u, i, o] == cube[u, i + 1, o - 1])
                            {
                                currentLineLength++;
                            }
                            else
                            {
                                if (longestLineLength < currentLineLength)
                                {
                                    longestLineLength = currentLineLength;
                                    numberOfLongestLines = 1;
                                }
                                else if (longestLineLength == currentLineLength)
                                {
                                    numberOfLongestLines++;
                                }
                                currentLineLength = 1;
                            }
                        }
                    }
                }

            }
            #endregion

            #region lines with a common point
            for (int o = 0; o < d; o++)
            {
                for (int u = 0; u < h; u++)
                {
                    for (int i = 0; i < w; i++)
                    {
                        int currentU = u;
                        int currentO = o;
                        int currentI = i;
                        while (currentU < h && currentO < d && currentI < w)
                        {
                            if (currentU < h - 1 && currentO < d - 1 && currentI < w - 1 &&
                                cube[currentU, currentI, currentO] == cube[currentU + 1, currentI + 1, currentO + 1])
                            {
                                currentLineLength++;
                            }
                            else
                            {
                                if (longestLineLength < currentLineLength)
                                {
                                    longestLineLength = currentLineLength;
                                    numberOfLongestLines = 1;
                                }
                                else if (longestLineLength == currentLineLength)
                                {
                                    numberOfLongestLines++;
                                }
                                currentLineLength = 1;
                            }
                            currentU++;
                            currentO++;
                            currentI++;
                        }

                        currentU = u;
                        currentO = o;
                        currentI = i;
                        while (currentU < h && currentO < d && currentI >= 0)
                        {
                            if (currentU < h - 1 && currentO < d - 1 && currentI > 0 &&
                                cube[currentU, currentI, currentO] == cube[currentU + 1, currentI - 1, currentO + 1])
                            {
                                currentLineLength++;
                            }
                            else
                            {
                                if (longestLineLength < currentLineLength)
                                {
                                    longestLineLength = currentLineLength;
                                    numberOfLongestLines = 1;
                                }
                                else if (longestLineLength == currentLineLength)
                                {
                                    numberOfLongestLines++;
                                }
                                currentLineLength = 1;
                            }
                            currentU++;
                            currentO++;
                            currentI--;
                        }

                        currentU = u;
                        currentO = o;
                        currentI = i;
                        while (currentU >= 0 && currentO < d && currentI < w)
                        {
                            if (currentU > 0 && currentO < d - 1 && currentI < w - 1 &&
                                cube[currentU, currentI, currentO] == cube[currentU - 1, currentI + 1, currentO + 1])
                            {
                                currentLineLength++;
                            }
                            else
                            {
                                if (longestLineLength < currentLineLength)
                                {
                                    longestLineLength = currentLineLength;
                                    numberOfLongestLines = 1;
                                }
                                else if (longestLineLength == currentLineLength)
                                {
                                    numberOfLongestLines++;
                                }
                                currentLineLength = 1;
                            }
                            currentU--;
                            currentO++;
                            currentI++;
                        }

                        currentU = u;
                        currentO = o;
                        currentI = i;
                        while (currentU >= 0 && currentO < d && currentI >= 0)
                        {
                            if (currentU > 0 && currentO < d - 1 && currentI > 0 &&
                                cube[currentU, currentI, currentO] == cube[currentU - 1, currentI - 1, currentO + 1])
                            {
                                currentLineLength++;
                            }
                            else
                            {
                                if (longestLineLength < currentLineLength)
                                {
                                    longestLineLength = currentLineLength;
                                    numberOfLongestLines = 1;
                                }
                                else if (longestLineLength == currentLineLength)
                                {
                                    numberOfLongestLines++;
                                }
                                currentLineLength = 1;
                            }
                            currentU--;
                            currentO++;
                            currentI--;
                        }
                    }
                }
            }
            #endregion

            if (longestLineLength != 1)
            {
                Console.WriteLine(longestLineLength + " " + numberOfLongestLines);
            }
            else
            {
                Console.WriteLine("-1");
            }
        }
    }
}