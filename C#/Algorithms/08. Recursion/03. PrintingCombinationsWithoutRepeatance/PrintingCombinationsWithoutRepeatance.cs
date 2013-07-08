using System;

class PrintingCombinationsWithoutRepeatance
{
    /* Task 3: 
     * Modify the previous program to skip duplicates:
     * n=4, k=2  (1 2), (1 3), (1 4), (2 3), (2 4), (3 4) */

    static void Main(string[] args)
    {
        int n = 5;
        int k = 2;
        int[] numbers = new int[k];

        FindCombinations(n, 0, 1, numbers);
    }
    public static void FindCombinations(int n, int possition, int startNum, int[] numbers)
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

        for (int i = startNum; i <= n; i++)
        {
            numbers[possition] = i;
            FindCombinations(n, possition + 1, i + 1, numbers);
        }

    }
}

