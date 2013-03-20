using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

//90/100
class PHPVariables
{
    static void Main(string[] args)
    {
        string input;
        string line;
        StringBuilder builder = new StringBuilder();
        do
        {
            line = Console.ReadLine();
            builder.Append(line);
            builder.AppendLine();
        }
        while (line != "?>");

        input = builder.ToString();


        int mode = 0;
        /* 1. comment
         * 2. multiline comment
         * 3. string '
         * 4. string "
         */

        StringBuilder currentVarBuilder = new StringBuilder();
        string variable;
        SortedSet<string> allVariables = new SortedSet<string>(StringComparer.Ordinal);
        for (int i = 0; i < input.Length; i++)
        {
            //opening
            if (mode == 0 && input[i] == '/' && input[i + 1] == '/')
            {
                mode = 1;
                i++;
            }
            else if (mode == 0 && input[i] == '#')
            {
                mode = 1;
            }
            else if (mode == 0 && input[i] == '/' && input[i + 1] == '*')
            {
                mode = 2;
                i++;
            }
            else if (mode == 0 && input[i] == '\'')
            {
                mode = 3;
            }
            else if (mode == 0 && input[i] == '"')
            {
                mode = 4;
            }
            //closing
            else if (mode == 1 && input[i] == '\n')
            {
                mode = 0;
            }
            else if (mode == 2 && input[i] == '*' && input[i + 1] == '/')
            {
                mode = 0;
                i++;
            }
            else if (mode == 3 && input[i] == '\'' && !CheckIfCharIsEscaped(ref input, i))
            {
                mode = 0;
            }
            else if (mode == 4 && input[i] == '"' && !CheckIfCharIsEscaped(ref input, i))
            {
                mode = 0;
            }
            else if ((mode == 0 || mode == 3 || mode == 4) && input[i] == '$' && !CheckIfCharIsEscaped(ref input, i))
            {
                i++;
                currentVarBuilder.Clear();
                do
                {
                    currentVarBuilder.Append(input[i]);
                    i++;
                }
                while (Char.IsLetterOrDigit(input[i]) || input[i] == '_');
                i--;
                variable = currentVarBuilder.ToString();
                allVariables.Add(variable);
            }
        }

        StringBuilder output = new StringBuilder();
        output.AppendLine(allVariables.Count.ToString());
        foreach (string variableToPrint in allVariables)
        {
            output.AppendLine(variableToPrint);
        }
        Console.WriteLine(output.ToString().TrimEnd());

    }

    static bool CheckIfCharIsEscaped(ref string input, int index)
    {
        int numberOfSlashes = 0;
        index--;
        while (input[index] == '\\')
        {
            numberOfSlashes++;
            index--;
        }
        if (numberOfSlashes % 2 == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}