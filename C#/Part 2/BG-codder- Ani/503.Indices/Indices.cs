using System;
using System.Collections.Generic;
using System.Text;

//100/100
class Indices
{
    static void Main(string[] args)
    {
        int n = Int32.Parse(Console.ReadLine());
        long[] arr = new long[n];
        string line = Console.ReadLine();
        string[] splitLine = line.Split();
        for (int i = 0; i < n; i++)
        {
            arr[i] = Int64.Parse(splitLine[i]);
        }

        long currentIndex = 0;
        HashSet<long> usedIndices = new HashSet<long>();
        List<long> sequence = new List<long>();

        while (currentIndex >= 0 && currentIndex < n && !usedIndices.Contains(currentIndex))
        {
            sequence.Add(currentIndex);
            usedIndices.Add(currentIndex);
            currentIndex = arr[currentIndex];
        }

        bool cycleFound = false;
        if (usedIndices.Contains(currentIndex))
        {
            cycleFound = true;
        }

        StringBuilder output = new StringBuilder();

        if (cycleFound)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] == currentIndex)
                {
                    output.Append('(');
                }
                else
                {
                    output.Append(' ');
                }
                output.Append(sequence[i]);
            }
            output.Append(')');
        }
        else
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                output.Append(sequence[i]);
                output.Append(" ");
            }
        }

        Console.WriteLine(output.ToString().Trim());
    }
}