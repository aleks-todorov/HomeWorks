using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Taks: 
Write a program that reads a string, reverses it and prints the result at the console.
Example: "sample" => "elpmas". */

namespace String
{
    class ReversingStrings
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter word: ");
            string word = Console.ReadLine();
            char[] reversed = new char[word.Length];
            for (int i = 0; i <= word.Length - 1; i++)
            {
                reversed[i] = (char)word[word.Length - 1 - i];
            }
            foreach (var letter in reversed)
            {
                Console.Write(letter);
            }
            Console.WriteLine();
        }
    }
}
