using System;

class PrintingCombinations
{
    /* Task 2: 
     * Write a recursive program for generating and printing all the combinations
     * with duplicates of k elements from n-element set. Example:
     * n=3, k=2  (1 1), (1 2), (1 3), (2 2), (2 3), (3 3) */

    static void Main(string[] args)
    {
        int n = 5;
        int k = 2;
        int[] numbers = new int[k];

        FindCombinations(n, 0, numbers);
    }
    public static void FindCombinations(int n, int possition, int[] numbers)
    {
        if (possition >= numbers.Length)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("{0} ", numbers[i]);
            }
            Console.WriteLine();
            return;
        }

        for (int i = 1; i <= n; i++)
        {
            numbers[possition] = i;
            FindCombinations(n, possition + 1, numbers);
        }

    }
}

