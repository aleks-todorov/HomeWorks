using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    //It works correctly, but obviously too slow: 30/100 in BGCodder. I have an idea how to do it faster in the next project
    // without calculating all possibilities;

    static SortedSet<string> result = new SortedSet<string>();
    static StringBuilder word = new StringBuilder();

    static void Main(string[] args)
    {
        //var orderedBalls = "BYYBB"; //10
        //var orderedBalls = "RYYRYBY"; // 105
        var orderedBalls = Console.ReadLine();
        char[] input = new char[orderedBalls.Length];

        for (int i = 0; i < orderedBalls.Length; i++)
        {
            input[i] = orderedBalls[i];
        }

        GenerateCombinations(0, input);
        Console.WriteLine(result.Count());
    }

    private static void GenerateCombinations(int possition, char[] input)
    {
        if (possition >= input.Length)
        {
            for (int i = 0; i < input.Length; i++)
            {
                word.Append(input[i]);
            }

            result.Add(word.ToString());
            word.Clear();
            return;
        }

        GenerateCombinations(possition + 1, input);
        for (int i = possition + 1; i < input.Length; i++)
        {
            Swap(ref input[possition], ref input[i]);
            GenerateCombinations(possition + 1, input);
            Swap(ref input[possition], ref input[i]);
        }
    }

    static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }
}

