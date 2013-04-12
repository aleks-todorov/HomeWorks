using System;
using System.Numerics;

//100/100
class Brackets
{
    static void Main()
    {
        string input = Console.ReadLine();
        int expressionLength = input.Length;

        BigInteger[,] dynamicMatrix = new BigInteger[expressionLength + 1, expressionLength + 1];
        dynamicMatrix[0, 0] = 1; //this is our base case; there is exactly 1 way in which a string with length 0 can be valid;

        char currentChar;
        for (int i = 0; i < expressionLength; i++)
        {
            currentChar = input[i];
            for (int u = 0; u <= expressionLength; u++)
            {
                if (dynamicMatrix[u, i] != 0)
                {
                    if (currentChar == '?')
                    {
                        if (u - 1 >= 0)
                        {
                            dynamicMatrix[u - 1, i + 1] += dynamicMatrix[u, i];
                        }
                        if (u + 1 <= expressionLength)
                        {
                            dynamicMatrix[u + 1, i + 1] += dynamicMatrix[u, i];
                        }
                    }
                    else if (currentChar == '(')
                    {
                        if (u + 1 <= expressionLength)
                        {
                            dynamicMatrix[u + 1, i + 1] += dynamicMatrix[u, i];
                        }
                    }
                    else if (currentChar == ')')
                    {
                        if (u - 1 >= 0)
                        {
                            dynamicMatrix[u - 1, i + 1] += dynamicMatrix[u, i];
                        }
                    }

                }
            }
        }
        Console.WriteLine(dynamicMatrix[0, expressionLength]);
    }
}