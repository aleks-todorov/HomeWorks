using System;
using System.Diagnostics;
using System.Linq;
using Wintellect.PowerCollections;

class FindProduct
{
    /* Task 2:
     * Write a program to read a large collection of products (name + price) I love 
     * and efficiently find the first 20 products in the price range [a…b]. Test for 
     * 500 000 products and 10 000 price searches.
     * Hint: you may use OrderedBag<T> and sub-ranges.
     */

    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        Stopwatch stopWatch = new Stopwatch();

        string[] product = { "bread", "butter", "meat", "eggs", "flower", "oil", "soda", "candy" };
        var productLenght = product.Length;
        var orderedDictionary = new OrderedDictionary<int, string>();

        stopWatch.Start();
        while (orderedDictionary.Count < 500000)
        {
            var key = randomGenerator.Next(1, 1000000);
            var value = product[randomGenerator.Next(0, productLenght)];
            if (!orderedDictionary.ContainsKey(key))
            {
                orderedDictionary.Add(key, value);
            }
        }

        stopWatch.Stop();

        Console.WriteLine("Time for creating the elements is: {0}", stopWatch.Elapsed);

        stopWatch.Reset();

        stopWatch.Start();
        for (int i = 0; i < 10000; i++)
        {
            var min = randomGenerator.Next(0, 500000);
            var max = randomGenerator.Next(500000, 1000000);
            var products = orderedDictionary.Range(min, true, max, true);
        }
        stopWatch.Stop();

        Console.WriteLine("Time for performing 10k range searches: {0}", stopWatch.Elapsed);

        var range = orderedDictionary.Range(1000, true, 100000, true);

        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine(range.ElementAt(i));
        }
    }
}

