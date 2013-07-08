using System;
using System.Collections.Generic;

class Application
{
    /* Task 2: 
     * Write a program that reads N integers from the console and reverses 
     * them using a stack. Use the Stack<int> class.
     */

    static void Main(string[] args)
    {
        Console.WriteLine("Please provide value for N: ");
        var N = int.Parse(Console.ReadLine());
        var numbersStack = new Stack<int>();
        var currentNumber = 0;

        for (int i = 0; i < N; i++)
        {
            currentNumber = int.Parse(Console.ReadLine());
            numbersStack.Push(currentNumber);
        }

        foreach (var number in numbersStack)
        {
            Console.Write("{0} ", number);
        }
    }
}

