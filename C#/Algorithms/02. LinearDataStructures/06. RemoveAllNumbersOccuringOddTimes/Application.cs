using System;
using System.Collections.Generic;

class Application
{
    /* Task 6: 
     * Write a program that removes from given sequence all numbers that occur odd number of times. Example:
     * {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}
     */

    static void Main(string[] args)
    {
        var numbers = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
        var uniqueNumbers = new Dictionary<Int32, Int32>();

        for (int i = 0; i < numbers.Count; i++)
        {
            if (uniqueNumbers.ContainsKey(numbers[i]))
            {
                uniqueNumbers[numbers[i]]++;
            }
            else
            {
                uniqueNumbers.Add(numbers[i], 1);
            }
        }

        foreach (var uniqueNumber in uniqueNumbers)
        {
            if (uniqueNumber.Value % 2 != 0)
            {
                numbers.RemoveAll(x => x == uniqueNumber.Key);
            }
        }

        foreach (var number in numbers)
        {
            Console.Write("{0} ", number);
        }
    }
}

