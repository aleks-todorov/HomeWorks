using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace E11.Tribonachi
{
    class Tribonachi
    {
        static void Main(string[] args)
        {
            BigInteger firstNumber = BigInteger.Parse(Console.ReadLine());
            BigInteger secondNumber = BigInteger.Parse(Console.ReadLine());
            BigInteger thirdNumber = BigInteger.Parse(Console.ReadLine());
            int counter = int.Parse(Console.ReadLine());
            BigInteger tribonachiNumber = 0;
            for (int i = 1; i <= counter - 3; i++)
            {
                tribonachiNumber = firstNumber + secondNumber + thirdNumber;
                firstNumber = secondNumber;
                secondNumber = thirdNumber;
                thirdNumber = tribonachiNumber;
            }
            if (counter > 3)
            {
                Console.WriteLine(tribonachiNumber);
            }
            else if (counter == 1)
            {
                Console.WriteLine(firstNumber);
            }
            else if (counter == 2)
            {
                Console.WriteLine(secondNumber);
            }
            else if (counter == 3)
            {
                Console.WriteLine(thirdNumber);
            }

        }
    }
}
