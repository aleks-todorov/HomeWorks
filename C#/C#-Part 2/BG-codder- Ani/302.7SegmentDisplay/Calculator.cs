using System;
using System.Collections.Generic;
using System.Text;

//100/100
class Calculator
{
    static int[,] numberInfo = {
                                                {1, 1, 1, 1, 1, 1, 0},
                                                {0, 1, 1, 0, 0, 0, 0},
                                                {1, 1, 0, 1, 1, 0, 1},
                                                {1, 1, 1, 1, 0, 0, 1},
                                                {0, 1, 1, 0, 0, 1, 1},
                                                {1, 0, 1, 1, 0, 1, 1},
                                                {1, 0, 1, 1, 1, 1, 1},
                                                {1, 1, 1, 0, 0, 0, 0},
                                                {1, 1, 1, 1, 1, 1, 1},
                                                {1, 1, 1, 1, 0, 1, 1}
                                                };
    static List<List<int>> combinations = new List<List<int>>();

    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        int numberOfCombinations = 1;
        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            List<int> currentList = GenerateListOfPossibleNumbers(line);
            numberOfCombinations *= currentList.Count;
            combinations.Add(currentList);

        }

        output = new StringBuilder();
        output.AppendLine(numberOfCombinations.ToString());
        int[] currentCombination = new int[n];
        MakeCombinationsRecursively(0, currentCombination);
        Console.Write(output.ToString());
    }

    static void MakeCombinationsRecursively(int numberOfPosition, int[] currentCombination)
    {
        for (int i = 0; i < combinations[numberOfPosition].Count; i++)
        {
            currentCombination[numberOfPosition] = combinations[numberOfPosition][i];
            if (numberOfPosition < combinations.Count - 1)
            {
                MakeCombinationsRecursively(numberOfPosition + 1, currentCombination);
            }
            else
            {
                PrintCurrentCombination(currentCombination);
            }
        }
    }

    static StringBuilder output;
    static void PrintCurrentCombination(int[] currentCombination)
    {
        for (int i = 0; i < currentCombination.Length; i++)
        {
            output.Append(currentCombination[i]);
        }
        output.AppendLine();
    }

    static List<int> GenerateListOfPossibleNumbers(string line)
    {
        bool[] isPossible = new bool[10];
        for (int i = 0; i < 10; i++)
        {
            isPossible[i] = true;
        }

        for (int u = 0; u < 10; u++)
        {
            for (int i = 0; i < 7; i++)
            {
                if (line[i] == '1' && numberInfo[u, i] != 1)
                {
                    isPossible[u] = false;
                    break;
                }
            }
        }

        List<int> result = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            if (isPossible[i] == true)
            {
                result.Add(i);
            }
        }

        return result;
    }

}