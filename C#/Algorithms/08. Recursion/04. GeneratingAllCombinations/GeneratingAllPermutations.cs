using System;

class Program
{
    /* Task 4: 
     * Write a recursive program for generating and printing 
     * all permutations of the numbers 1, 2, ..., 
     * n for given integer number n. Example:
     * n=3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3},
     * {2, 3, 1}, {3, 1, 2},{3, 2, 1} */

    static void Main(string[] args)
    {
        int n = 5;
        int[] numbers = new int[n];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i + 1;
        }

        GeneratePermutation(numbers, 0);
    }

    public static void GeneratePermutation(int[] numbers, int possition)
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

        GeneratePermutation(numbers, possition + 1);
        for (int i = possition + 1; i < numbers.Length; i++)
        {
            Swap(ref numbers[possition], ref numbers[i]);
            GeneratePermutation(numbers, possition + 1);
            Swap(ref numbers[possition], ref numbers[i]);
        }
    }

    static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }
}

