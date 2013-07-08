using System;
using System.Collections.Generic;
using System.Linq;

class CountingOfOccurenceOfNumbers
{
    /* Task 1: 
     * Write a program that counts in a given array of double values 
     * the number of occurrences of each value. Use Dictionary<TKey,TValue>.
     * Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
        -2.5  2 times
        3  4 times
        4  3 times
     */

    static void Main(string[] args)
    {
        double[] array = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
        var occurenceHolder = new Dictionary<double, int>();

        foreach (var num in array)
        {
            if (occurenceHolder.ContainsKey(num))
            {
                occurenceHolder[num]++;
            }
            else
            {
                occurenceHolder[num] = 1;
            }
        }

        foreach (var item in occurenceHolder)
        {
            Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
        }
    }
}

