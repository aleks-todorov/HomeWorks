using System;

class SimulationOfNestedForLoops
{
    /* Task 1: 
     * Write a recursive program that simulates the execution of n nested loops from 1 to n. */

    static void Main(string[] args)
    {
        var size = 3;
        int[] numbers = new int[size];

        SimulateCycles(0, numbers);
    }

    public static void SimulateCycles(int possition, int[] numbers)
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

        for (int i = 1; i <= numbers.Length; i++)
        {
            numbers[possition] = i;
            SimulateCycles(possition + 1, numbers);
        }
    }

}
