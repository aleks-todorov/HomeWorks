using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static List<string> elements = new List<string>();
    static SortedSet<string> combinations = new SortedSet<string>();

    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var sb = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            sb.AppendFormat("({0}, {1})", input[0], input[1]);
            elements.Add(sb.ToString());
            sb.Clear();
            if (input[0] != input[1])
            {
                sb.AppendFormat("({0}, {1})", input[1], input[0]);
                elements.Add(sb.ToString());
                sb.Clear();
            }
        }

        string[] output = new string[n];
        elements.Sort();
        var arr = elements.ToArray();


        PermuteRep(arr, 0, elements.Count());

        Console.WriteLine(combinations.Count());

        foreach (var combination in combinations)
        {
            Console.WriteLine(combination);
        }
    }

    static void PermuteRep(string[] arr, int start, int n)
    {
        Print(arr);

        for (int left = n - 2; left >= start; left--)
        {
            for (int right = left + 1; right < n; right++)
            {
                if (arr[left] != arr[right])
                {
                    Swap(ref arr[left], ref arr[right]);
                    PermuteRep(arr, left + 1, n);
                }
            }

            // Undo all modifications done by the
            // previous recursive calls and swaps
            var firstElement = arr[left];
            for (int i = left; i < n - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[n - 1] = firstElement;
        }
    }

    static void Print<T>(T[] arr)
    {
        Console.WriteLine(string.Join(", ", arr));
    }

    static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }
}

