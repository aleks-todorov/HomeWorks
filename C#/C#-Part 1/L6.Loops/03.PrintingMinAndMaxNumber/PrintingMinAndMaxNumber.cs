using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PrintingMinAndMaxNumber
{
    class PrintingMinAndMaxNumber
    {
        static void Main(string[] args)
        {
           //Write a program that reads from the console a 
           //sequence of N integer numbers and returns the minimal and maximal of them.
            Console.WriteLine("How many integers do you want to input?");
            int sequenceN = int.Parse(Console.ReadLine());
            int[] numberArray = new int[sequenceN]; 
            for (int i = 0; i < sequenceN; i++)
            {
                numberArray[i] = int.Parse(Console.ReadLine()); 
            }
            Console.WriteLine("The smalles number is: {0}",numberArray.Min());
            Console.WriteLine("The bigest number is: {0}",numberArray.Max());
        }
    }
}
