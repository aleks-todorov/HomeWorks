using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        SortedSet<char> letters = new SortedSet<char>();
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine();

            for (int j = 0; j < input.Length; j++)
            {
                letters.Add(input[j]);
            }
        }

        var sb = new StringBuilder();
        foreach (var letter in letters)
        {
            sb.Append(letter);
        }

        Console.WriteLine(sb.ToString());
    }
}
