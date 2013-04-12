using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

//80/100
class CleanCode
{
    static void Main(string[] args)
    {
        int n = Int32.Parse(Console.ReadLine());
        string input;
        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            builder.Append(Console.ReadLine());
            builder.AppendLine();
        }

        input = builder.ToString();

        List<int> toRemove = new List<int>();
        int mode = 0;
        /*
        1. comment
        2. multiline comment
        3. string
        4. multiline string
         */

        for (int i = 0; i < input.Length; i++)
        {
            //opening characters
            if (input[i] == '/' && input[i + 1] == '/' && input[i + 2] != '/' && mode == 0)
            {
                mode = 1;
                toRemove.Add(i);
                i++; // we jump over the second /
            }
            else if (input[i] == '/' && input[i + 1] == '/' && input[i + 2] == '/')
            {
                i += 2;
            }
            else if (input[i] == '/' && input[i + 1] == '*' && mode == 0)
            {
                mode = 2;
                toRemove.Add(i);
                i++; // jump over the *
            }
            else if (input[i] == '"' && mode == 0)
            {
                mode = 3;
            }
            else if (input[i] == '@' && input[i + 1] == '"' && mode == 0)
            {
                mode = 4;
                i++; //jump over the "
            }
            //closing characters
            else if (mode == 1 && input[i] == '\r')
            {
                toRemove.Add(i - 1);
                mode = 0;
            }
            else if (mode == 2 && input[i] == '*' && input[i + 1] == '/')
            {
                toRemove.Add(i + 1);
                mode = 0;
            }
            else if (mode == 3 && input[i] == '"' && !CheckIfQuoteIsEscaped(ref input, i))
            {
                mode = 0;
            }
            else if (mode == 4 && input[i] == '"')
            {
                if (CheckNumberFollowingQuotesIsUneven(ref input, i))
                {
                    mode = 0;
                }
                do
                {
                    i++;
                }
                while (input[i] == '"'); //we need to jump over the other quotes
                i--;
            }
        }

        builder = new StringBuilder(input);
        int startIndex;
        int endIndex;
        int length;
        int totalLengthRemoved = 0;
        for (int i = 0; i < toRemove.Count; i += 2)
        {
            startIndex = toRemove[i];
            endIndex = toRemove[i + 1];
            length = endIndex - startIndex + 1;
            builder.Remove(startIndex - totalLengthRemoved, length);
            totalLengthRemoved += length;
        }

        string output = builder.ToString();
        string[] splitOutput = output.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        builder = new StringBuilder();
        foreach (string line in splitOutput)
        {
            if (!CheckIfLineIsBlank(line))
            {
                builder.AppendLine(line);
            }
        }

        Console.Write(builder.ToString());
    }

    static bool CheckIfLineIsBlank(string line)
    {
        foreach (char ch in line)
        {
            if (Char.IsLetterOrDigit(ch) || Char.IsPunctuation(ch))
            {
                return false;
            }
        }
        return true;
    }

    static bool CheckIfQuoteIsEscaped(ref string input, int index)
    {
        int numberSlashes = 0;
        index--;
        while (input[index] == '\\')
        {
            numberSlashes++;
            index--;
        }
        if (numberSlashes % 2 == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static bool CheckNumberFollowingQuotesIsUneven(ref string input, int index)
    {
        int numberQuotes = 1;
        index++;
        while (input[index] == '"')
        {
            numberQuotes++;
            index++;
        }
        if (numberQuotes % 2 == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

