using System;

class PrintingAllSubsetStrings
{
    /* Task 6: 
     * Write a program for generating and printing all subsets of k strings from given set of strings.
     * Example: s = {test, rock, fun}, k=2
     * (test rock),  (test fun),  (rock fun)*/

    static void Main(string[] args)
    {
        string[] arr = { "test", "rock", "fun" };
        var k = 2;
        string[] subsetStrings = new string[k];

        PrintAllSubsetStrings(0, 0, subsetStrings, arr);
    }

    static void PrintAllSubsetStrings(int startIndex, int index, string[] result, string[] setOfStrings)
    {
        if (index > result.Length - 1)
        {
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write("{0} ", result[i]);
            }
            Console.WriteLine();
            return;
        }
        else
        {
            for (int i = startIndex; i < setOfStrings.Length; i++)
            {
                if (index < result.Length)
                {
                    result[index] = setOfStrings[i];
                }
                PrintAllSubsetStrings(i + 1, index + 1, result, setOfStrings);
            }
        }
    }
}

