using System;
using System.Collections.Generic;
using System.Numerics;

class ColorBallsVersion2
{
    //BgCodder: 100/100

    //No need to derive all possibilities. Just need to callculate using the formula for this kind of opperations n!/(s1!,s2!,s3!...sk!)

    static void Main(string[] args)
    {
        //var orderedBalls = "BYYBB"; //10
        //var orderedBalls = "RYYRYBY"; // 105
        var orderedBalls = Console.ReadLine();
        var balls = new Dictionary<char, uint>();

        for (int i = 0; i < orderedBalls.Length; i++)
        {
            if (balls.ContainsKey(orderedBalls[i]))
            {
                balls[orderedBalls[i]]++;
            }
            else
            {
                balls.Add(orderedBalls[i], 1);
            }
        }

        BigInteger divisor = 1;
        foreach (var item in balls)
        {
            divisor *= Factorial(item.Value);
        }

        BigInteger divident = Factorial((BigInteger)orderedBalls.Length);
        Console.WriteLine(divident / divisor);
    }

    static BigInteger Factorial(BigInteger number)
    {
        BigInteger fact = 1;
        for (uint i = 1; i <= number; i++)
        {
            fact *= i;
        }

        return fact;
    }
}

