using System;
using System.Collections.Generic;

class Applciation
{
    /* Task 9: 
     * We are given the following sequence:
     * S1 = N;
     * S2 = S1 + 1;
     * S3 = 2*S1 + 1;
     * S4 = S1 + 2;
     * S5 = S2 + 1;
     * S6 = 2*S2 + 1;
     * S7 = S2 + 2;
     * ...
     * Using the Queue<T> class write a program to print its first 50 members for given N.
     * Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
     */

    static void Main(string[] args)
    {
        Console.Write("Enter a value for N: ");
        int n = int.Parse(Console.ReadLine());
        var sequence = new Queue<int>();
        int counter = 0;
        int lastNumber = n;
        sequence.Enqueue(n);

        Console.WriteLine("First 50 elements of this sequence are: ");

        for (int i = 1; i <= 50; i++)
        {
            lastNumber = sequence.Dequeue();
            Console.WriteLine("{0,2} -> {1,2} ", i, lastNumber);

            if (counter < 50)
            {
                sequence.Enqueue(lastNumber + 1);
                sequence.Enqueue((2 * lastNumber) + 1);
                sequence.Enqueue(lastNumber + 2);
            }
            counter += 3;
        }
    }
}


