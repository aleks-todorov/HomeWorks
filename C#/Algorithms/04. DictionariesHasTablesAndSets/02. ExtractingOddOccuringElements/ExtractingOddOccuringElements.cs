using System;
using System.Collections.Generic;
using System.Text;

class ExtractingOddOccuringElements
{ 
    /* Task 2: 
     * Write a program that extracts from a given sequence of strings 
     * all elements that present in it odd number of times. Example:
     * {C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}
     */

    static void Main(string[] args)
    {
        string[] words = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
        var occurenceHolder = new SortedDictionary<string, int>();

        foreach (var word in words)
        {
            if (occurenceHolder.ContainsKey(word))
            {
                occurenceHolder[word]++;
            }
            else
            {
                occurenceHolder[word] = 1;
            }
        }

        var sb = new StringBuilder();
        sb.Append("{");
        foreach (var item in occurenceHolder)
        {
            if (item.Value % 2 != 0)
            {
                sb.AppendFormat("{0} ,", item.Key);
            }
        }
        sb.Length -= 2;
        sb.Append("}");
        Console.WriteLine(sb.ToString());
    }
}

