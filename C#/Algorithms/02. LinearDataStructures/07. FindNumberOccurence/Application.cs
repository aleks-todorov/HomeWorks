using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.FindNumberOccurence
{
    class Application
    { 
        /* Task 7: 
         * Write a program that finds in given array of integers (all belonging to the range [0..1000]) 
         * how many times each of them occurs.
         * Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
         * 2  2 times
         * 3  4 times
         * 4  3 times
         */

        static void Main(string[] args)
        {
            int[] numbers = new int[1000];
            var randomGenerator = new Random();
            var uniqueNumbers = new Dictionary<Int32, Int32>();

            for (int i = 0; i < numbers.Length; i++)
            {
                //Number range can vary[0, 1000], but in order ot have more hits, I am selecting range [0,10]
                numbers[i] = randomGenerator.Next(0, 11);
            }

            //If numbers in the array are not sorted, they just appear randomly on the console. 
            //If looking for performance this row can be removed or sorting algo can be changed. 
            //For the purpose of this demo, performance is neglected.
            Array.Sort(numbers);

            for (int i = 0; i < numbers.Length; i++)
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

            foreach (var number in uniqueNumbers)
            {
                Console.WriteLine("{0,2} -> {1,3} times", number.Key, number.Value);
            }
        }
    }
}

