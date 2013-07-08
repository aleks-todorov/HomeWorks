using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static List<string> elements = new List<string>();
    static SortedSet<string> combinations = new SortedSet<string>();
    static List<string[]> numbers = new List<string[]>();

    static bool[] used;

    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var sb = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            sb.AppendFormat("({0}, {1})", input[0], input[1]);
            elements.Add(sb.ToString());
            numbers.Add(input);
            sb.Clear();
        }

        string[] output = new string[n];

        elements.Sort();
        used = new bool[elements.Count];
        FindCombinations(0, 0, output, used);

        for (int i = 0; i < n; i++)
        {
            elements.Clear();

            for (int j = 0; j < n; j++)
            {
                var input = numbers[j];
                if (i == j)
                {
                    sb.AppendFormat("({0}, {1})", input[1], input[0]);
                    elements.Add(sb.ToString());
                    sb.Clear();
                }
                else
                {
                    sb.AppendFormat("({0}, {1})", input[0], input[1]);
                    elements.Add(sb.ToString());
                    sb.Clear();
                }
            }

            elements.Sort();
            used = new bool[elements.Count];
            FindCombinations(0, 0, output, used);
        }

        elements.Clear();

        for (int i = 0; i < numbers.Count; i++)
        {
            var input = numbers[i];
            sb.AppendFormat("({0}, {1})", input[0], input[1]);
            elements.Add(sb.ToString());
            sb.Clear();
        }

        elements.Sort();
        used = new bool[elements.Count];
        FindCombinations(0, 0, output, used);

        Console.WriteLine(combinations.Count());

        sb.Clear();
        foreach (var combination in combinations)
        {
            sb.AppendLine(combination);
        }

        Console.WriteLine(sb.ToString());
    }

    public static void FindCombinations(int startValue, int possition, string[] output, bool[] used)
    {
        if (possition >= output.Length)
        {
            var entry = string.Empty;

            for (int i = 0; i < output.Length; i++)
            {
                if (i < output.Length - 1)
                {
                    entry += output[i] + " | ";
                }
                else
                {
                    entry += output[i];
                }
            }

            combinations.Add(entry);
            return;
        }

        for (int i = 0; i < elements.Count(); i++)
        {
            if (!used[i])
            {
                used[i] = true;
                output[possition] = elements[i];
                FindCombinations(startValue + 1, possition + 1, output, used);
                used[i] = false;
            }
        }
    }
}