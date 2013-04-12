using System;
using System.Collections.Generic;
using System.Text;

//100/100
class Crossword
{
    static List<string> words = new List<string>();
    static char[,] crossword;
    static bool foundSolution = false;

    static void Main(string[] args)
    {
        int n = Int32.Parse(Console.ReadLine());
        words = new List<string>();

        for (int i = 1; i <= n * 2; i++)
        {
            words.Add(Console.ReadLine());
        }
        words.Sort();

        crossword = new char[n, n];
        FillMatrixRecursively(0);
        if (!foundSolution)
        {
            Console.WriteLine("NO SOLUTION!");
        }

    }

    static void FillMatrixRecursively(int heightReached)
    {
        foreach (string word in words)
        {
            PlaceWordInMatrix(heightReached, word);
            if (CheckIfFits(heightReached))
            {
                if (heightReached == crossword.GetLength(0) - 1)
                {
                    PrintCrossWord();
                    foundSolution = true;
                }
                else
                {
                    FillMatrixRecursively(heightReached + 1);
                }
            }
            if (foundSolution)
            {
                break;
            }
        }
    }

    static void PlaceWordInMatrix(int height, string word)
    {
        for (int i = 0; i < word.Length; i++)
        {
            crossword[height, i] = word[i];
        }
    }

    static bool CheckIfFits(int heightReached)
    {
        for (int u = 0; u < crossword.GetLength(1); u++)
        {
            StringBuilder wordStartBuilder = new StringBuilder();
            for (int i = 0; i <= heightReached; i++)
            {
                wordStartBuilder.Append(crossword[i, u]);
            }

            bool currentStartFits = false;
            foreach (string word in words)
            {
                if (word.StartsWith(wordStartBuilder.ToString()))
                {
                    currentStartFits = true;
                }
            }

            if (currentStartFits == false)
            {
                return false;
            }
        }

        return true;
    }

    static void PrintCrossWord()
    {
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < crossword.GetLength(0); i++)
        {
            for (int u = 0; u < crossword.GetLength(1); u++)
            {
                output.Append(crossword[i, u]);
            }
            output.AppendLine();
        }
        Console.WriteLine(output.ToString().TrimEnd());
    }
}