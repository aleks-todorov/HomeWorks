using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics; 

namespace _12.CalculatingTrailingZeroes
{
    class CalculatingTrailingZeroes
    {
        static void Main()
        {
            // * Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
            //N = 10  N! = 3628800  2
            //N = 20  N! = 2432902008176640000  4
            //Does your program work for N = 50 000?
            //Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!
            int numberN = int.Parse(Console.ReadLine());
            BigInteger nFactorial = 1;
            for (int i = 1; i <= numberN; i++)
            {
                nFactorial = i * nFactorial;
            }
            BigInteger countOfZeroes = 0;
            BigInteger multiplyer = 10;

            while (nFactorial % multiplyer == 0)
            {
                countOfZeroes++;
                multiplyer = multiplyer * 10;
            }
            Console.WriteLine("The number of trailing zeroes is {0}", countOfZeroes);

        }
    }
}
