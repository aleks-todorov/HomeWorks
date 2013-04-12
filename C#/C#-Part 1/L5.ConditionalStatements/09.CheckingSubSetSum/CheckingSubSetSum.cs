using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.CheckingSubSetSum
{
    class CheckingSubSetSum
    {
        static int[] numberArray = new int[5];
        static int negativeNumber = 0;
        static int firstNumber;
        static int secondNumber;
        static bool isSolution = false;

        static void Main()
        {
            //We are given 5 integer numbers. Write a program that 
            //checks if the sum of some subset of them is 0. Example: 3, -2, 1, 1, 8  1+1-2=0.
            for (int i = 0; i < numberArray.Length; i++)
            {
                numberArray[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < numberArray.Length; i++)
            {
                if (numberArray[i] < 0)
                {
                    negativeNumber = numberArray[i];
                    CheckSequence(negativeNumber);
                }
            }
        }

        private static void CheckSequence(int negativeNumber)
        {
            for (int i = 0; i < numberArray.Length; i++)
            {
                firstNumber = numberArray[i];
                for (int n = 0; n < numberArray.Length; n++)
                {
                    if (i != n)
                    {
                        secondNumber = numberArray[n];
                        if (firstNumber + secondNumber + negativeNumber == 0)
                        {
                            Console.WriteLine("The sequence is {0}, {1} and {2}", firstNumber, secondNumber, negativeNumber);
                            isSolution = true;
                        }
                    }
                    if (isSolution == true)
                    {
                        isSolution = false;
                        break; 
                    }
                }
            }
        }

    }
}

