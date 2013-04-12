using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01.DurankolakNumbers
{
    class DurankolakNumbers
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            //string numbers = "CaB";
            BigInteger finalNumber = 0;
            int power = 0;
            int currentPossition = numbers.Length - 1;
            int currentNumber = 0;
            char previousSymbol;
            for (int i = currentPossition; i >= 0; i--)
            {
                char currentSymbol = numbers[i];
                if (i > 0)
                {
                    previousSymbol = numbers[i - 1];
                }
                else
                {
                    previousSymbol = currentSymbol;
                }
                int additor = 0;
                switch (currentSymbol)
                {
                    case 'A': additor = 0; break;
                    case 'B': additor = 1; break;
                    case 'C': additor = 2; break;
                    case 'D': additor = 3; break;
                    case 'E': additor = 4; break;
                    case 'F': additor = 5; break;
                    case 'G': additor = 6; break;
                    case 'H': additor = 7; break;
                    case 'I': additor = 8; break;
                    case 'J': additor = 9; break;
                    case 'K': additor = 10; break;
                    case 'L': additor = 11; break;
                    case 'M': additor = 12; break;
                    case 'N': additor = 13; break;
                    case 'O': additor = 14; break;
                    case 'P': additor = 15; break;
                    case 'Q': additor = 16; break;
                    case 'R': additor = 17; break;
                    case 'S': additor = 18; break;
                    case 'T': additor = 19; break;
                    case 'U': additor = 20; break;
                    case 'V': additor = 21; break;
                    case 'W': additor = 22; break;
                    case 'X': additor = 23; break;
                    case 'Y': additor = 24; break;
                    case 'Z': additor = 25; break;
                }

                switch (currentSymbol)
                {
                    case 'a': additor = 1; break;
                    case 'b': additor = 2; break;
                    case 'c': additor = 3; break;
                    case 'd': additor = 4; break;
                    case 'e': additor = 5; break;
                    case 'f': additor = 6; break;
                    case 'g': additor = 7; break;
                    case 'h': additor = 8; break;
                    case 'i': additor = 9; break;
                    case 'j': additor = 10; break;
                    case 'k': additor = 11; break;
                    case 'l': additor = 12; break;
                    case 'm': additor = 13; break;
                    case 'n': additor = 14; break;
                    case 'o': additor = 15; break;
                    case 'p': additor = 16; break;
                    case 'q': additor = 17; break;
                    case 'r': additor = 18; break;
                    case 's': additor = 19; break;
                    case 't': additor = 20; break;
                    case 'u': additor = 21; break;
                    case 'v': additor = 22; break;
                    case 'w': additor = 23; break;
                    case 'x': additor = 24; break;
                    case 'y': additor = 25; break;
                    case 'z': additor = 26; break;
                }

                if (char.IsUpper(currentSymbol) == true)
                {
                    currentNumber += additor;
                    if (char.IsLower(previousSymbol) && i > 0)
                    {
                        continue;
                    }
                    else
                    {
                        finalNumber += currentNumber * (BigInteger)Math.Pow((double)168, (double)power);
                        power++;
                        currentNumber = 0;
                    }
                }
                else
                {
                    currentNumber += additor * 26;
                    finalNumber += currentNumber * (BigInteger)Math.Pow((double)168, (double)power);
                    power++;
                    currentNumber = 0;
                }
            }
            Console.WriteLine(finalNumber);
        }
    }
}
