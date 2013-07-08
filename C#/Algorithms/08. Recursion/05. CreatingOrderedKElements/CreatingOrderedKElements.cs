using System;
 
class CreatingOrderedKElements
{
    /*Task 5:
     * Write a recursive program for generating and printing all ordered k-element
     * subsets from n-element set (variations Vkn).
     * Example: n=3, k=2, set = {hi, a, b} =>
     * (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)*/

    static void Main(string[] args)
    {
        var n = 3;
        var k = 2;
        string[] words = { "hi", "a", "b" };
        string[] combinations = new string[2];

        GenerateCombinations(words, combinations, 0);
    }

    private static void GenerateCombinations(string[] words, string[] combinnation, int possition)
    {
        if (possition == combinnation.Length)
        {
            for (int i = 0; i < combinnation.Length; i++)
            {
                Console.Write("{0} ", combinnation[i]);
            }
            Console.WriteLine();
            return;
        }

        for (int i = 0; i < words.Length; i++)
        {
            combinnation[possition] = words[i];
            GenerateCombinations(words, combinnation, possition + 1);
        }
    }
}
