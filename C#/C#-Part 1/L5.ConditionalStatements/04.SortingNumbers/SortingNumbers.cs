using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SortingNumbers
{
    class SortingNumbers
    {
        static void Main(string[] args)
        {
           // Sort 3 real values in descending order using nested if statements.

            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirNumber = int.Parse(Console.ReadLine());

            if (firstNumber > secondNumber && firstNumber > thirNumber)
            {
                if (secondNumber > thirNumber)
                {
                    Console.WriteLine(firstNumber + " " + secondNumber + " " + thirNumber);
                }
                else
                {
                    Console.WriteLine(firstNumber + " " + thirNumber + " " + secondNumber);
                }
            }
            else if (secondNumber > firstNumber && secondNumber > thirNumber)
            {
                if (firstNumber > thirNumber)
                {
                    Console.WriteLine(secondNumber + " " + firstNumber + " " + thirNumber);
                }
                else
                {
                    Console.WriteLine(secondNumber + " " + thirNumber + " " + firstNumber);
                }
            }
            else
            {
                if (secondNumber > firstNumber)
                {
                    Console.WriteLine(thirNumber + " " + secondNumber + " " + firstNumber);
                }
                else
                {
                    Console.WriteLine(thirNumber + " " + firstNumber + " " + secondNumber);
                }
            }
        }
    }
}
