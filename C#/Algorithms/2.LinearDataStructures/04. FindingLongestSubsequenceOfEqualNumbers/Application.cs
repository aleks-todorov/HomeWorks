using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindingLongestSubsequenceOfEqualNumbers
{
    public class LongestSequence
    {
        /* Task 4: 
         * Write a method that finds the longest subsequence of equal numbers 
         * in given List<int> and returns the result as new List<int>.
         * Write a program to test whether the method works correctly.
         */

        static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2, 5, 6, 4, 1, 2, 3, 5, 6, 6, 5, 4, 3, 5, 6, 7, 6, 7, 2 };
            var longestSequence = FindLongestSequence(numbers);

            Console.WriteLine("Longest sequence is {0} and number is: {1}", longestSequence.Count(), longestSequence[0]);
        }

        public static List<int> FindLongestSequence(List<int> numbers)
        {
            numbers.Sort();
            var longestSequence = new List<int>();
            var counter = 1;
            var currentNumber = numbers[0];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (currentNumber != numbers[i])
                {
                    counter = 1;
                    currentNumber = numbers[i];
                }

                if (counter > longestSequence.Count)
                {
                    longestSequence.Clear();
                    for (int j = 0; j < counter; j++)
                    {
                        longestSequence.Add(numbers[i]);
                    }
                }

                counter++;
            }

            return longestSequence;
        }
    }
}

