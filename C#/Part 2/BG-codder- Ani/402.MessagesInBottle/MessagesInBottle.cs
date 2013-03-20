using System;
using System.Collections.Generic;
using System.Text;

//90/100
class MessagesInBottle
{
    static Dictionary<string, char> parsedCipher;
    static string code;
    static List<string> allResults = new List<string>();
    static void Main(string[] args)
    {
        code = Console.ReadLine();
        string cipher = Console.ReadLine();

        //parse the cipher
        parsedCipher = new Dictionary<string, char>();
        char currentLetter = cipher[0];
        int index = 1;
        StringBuilder currentNumbers = new StringBuilder();
        while (char.IsDigit(cipher[index]))
        {
            currentNumbers.Append(cipher[index]);
            index++;
        }
        for (int i = index; i < cipher.Length; i++)
        {
            if (Char.IsLetter(cipher[i]))
            {
                parsedCipher.Add(currentNumbers.ToString(), currentLetter);
                currentNumbers = new StringBuilder();
                currentLetter = cipher[i];
            }
            if (Char.IsDigit(cipher[i]))
            {
                currentNumbers.Append(cipher[i]);
            }
        }
        parsedCipher.Add(currentNumbers.ToString(), currentLetter);

        StepRecursivelyIntoCode(0);

        allResults.Sort();
        StringBuilder resultPrint = new StringBuilder();
        resultPrint.AppendLine(allResults.Count.ToString());
        foreach (string result in allResults)
        {
            resultPrint.AppendLine(result);
        }
        Console.Write(resultPrint);
    }

    static StringBuilder currentResult;
    static void StepRecursivelyIntoCode(int indexReached)
    {
        if (indexReached >= code.Length)
        {
            allResults.Add(currentResult.ToString());
            return;
        }
        foreach (var entry in parsedCipher)
        {
            if (indexReached == 0)
            {
                currentResult = new StringBuilder();
            }
            if (CurrentCodeFitsLocation(indexReached, entry.Key))
            {
                currentResult.Append(entry.Value);
                StepRecursivelyIntoCode(indexReached + entry.Key.Length);
                currentResult.Remove(currentResult.Length - 1, 1);
            }
        }
    }

    static bool CurrentCodeFitsLocation(int indexReached, string pieceOfCode)
    {
        if (code.Length - indexReached < pieceOfCode.Length)
        {
            return false;
        }

        for (int i = 0; i < pieceOfCode.Length; i++)
        {
            if (code[indexReached] != pieceOfCode[i])
            {
                return false;
            }
            indexReached++;
        }
        return true;
    }
}