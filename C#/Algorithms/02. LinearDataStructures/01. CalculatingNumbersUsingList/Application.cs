using System;
using System.Collections.Generic;
using System.Linq;

class Application
{
    /* Task 1: 
     * Write a program that reads from the console a sequence of positive integer numbers.
     * The sequence ends when empty line is entered. Calculate and print the sum and average of 
     * the elements of the sequence. Keep the sequence in List<int>.
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

        Console.WriteLine("The sum of these numbers is: {0}, and their average is {1}", numbersList.Sum(), numbersList.Average());
    }
}

