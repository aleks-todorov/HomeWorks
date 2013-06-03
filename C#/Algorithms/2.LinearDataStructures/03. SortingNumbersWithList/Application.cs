using System;
using System.Collections.Generic;

class Application
{
    /* Task 3: 
     * Write a program that reads a sequence of integers 
     * (List<int>) ending with an empty line and sorts them in an increasing order.
     */

    static void Main(string[] args)
    {
        var input = string.Empty;
        var numbersList = new List<int>();
        var currentNumber = 0;

        while (true)
        {
            input = Console.ReadLine();
            if (input == string.Empty)
            {
                break;
            }

            currentNumber = int.Parse(input);
            numbersList.Add(currentNumber);
        }

        numbersList.Sort();

        foreach (var number in numbersList)
        {
            Console.Write("{0} ", number);
        }

        Console.WriteLine();
    }
}