using System;
using System.Text;
using System.Text.RegularExpressions;

//100/100
class BasicBasic
{
    static StringBuilder result;
    static int x = 0;
    static int y = 0;
    static int z = 0;
    static int v = 0;
    static int w = 0;

    static void Main(string[] args)
    {
        StringBuilder inputBuilder = new StringBuilder();
        string readLine = Console.ReadLine();
        while (readLine != "RUN")
        {
            inputBuilder.AppendLine(readLine);
            readLine = Console.ReadLine();
        }
        string input = inputBuilder.ToString();

        string[] splitInput = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        int biggestIndex = FindLineNumber(splitInput[splitInput.Length - 1]);
        string[] code = new string[biggestIndex + 1];

        Regex emptySpaceRemover = new Regex("\\s+");
        foreach (string line in splitInput)
        {
            string newLine = emptySpaceRemover.Replace(SeparateCodeFromNumber(line), string.Empty);
            code[FindLineNumber(line)] = newLine;
        }

        result = new StringBuilder();
        for (int i = 0; i < code.Length; i++)
        {
            if (code[i] != null)
            {
                string currentLine = code[i];
                if (code[i].Contains("THEN"))
                {
                    string[] ifThen = currentLine.Split(new string[] { "IF", "THEN" }, StringSplitOptions.RemoveEmptyEntries);
                    bool ifCondition = ProcessBoolExpression(ifThen[0]);
                    if (ifCondition)
                    {
                        currentLine = ifThen[1];
                    }
                    else
                    {
                        continue;
                    }
                }

                if (currentLine.Contains("GOTO"))
                {
                    i = ProcessGoTo(currentLine) - 1;
                }
                else if (currentLine == "STOP")
                {
                    break;
                }
                else if (currentLine == "CLS")
                {
                    result.Clear();
                }
                else if (currentLine.Contains("PRINT"))
                {
                    ProcessPrint(currentLine);
                }
                else
                {
                    ProcessOperation(currentLine);
                }
            }
        }

        Console.WriteLine(result.ToString().TrimEnd());
    }

    static void ProcessOperation(string line)
    {
        string[] splitOperation = line.Split('=');
        string leftSide = splitOperation[0];
        string rightSide = splitOperation[1];

        char operat;
        if (rightSide.Contains("-"))
        {
            operat = '-';
        }
        else //rightSide.Contains("+")
        {
            operat = '+';
        }

        string[] splitRightSide = rightSide.Split(new char[] { operat }, StringSplitOptions.RemoveEmptyEntries);
        int firstPart;
        if (Int32.TryParse(splitRightSide[0], out firstPart))
        {
        }
        else if (splitRightSide[0][0] == 'X')
        {
            firstPart = x;
        }
        else if (splitRightSide[0][0] == 'Y')
        {
            firstPart = y;
        }
        else if (splitRightSide[0][0] == 'Z')
        {
            firstPart = z;
        }
        else if (splitRightSide[0][0] == 'W')
        {
            firstPart = w;
        }
        else if (splitRightSide[0][0] == 'V')
        {
            firstPart = v;
        }

        int secondPart;
        if (splitRightSide.Length <= 1)
        {
            secondPart = firstPart;
            firstPart = 0;
        }
        else
        {
            if (Int32.TryParse(splitRightSide[1], out secondPart))
            {
            }
            else if (splitRightSide[1][0] == 'X')
            {
                secondPart = x;
            }
            else if (splitRightSide[1][0] == 'Y')
            {
                secondPart = y;
            }
            else if (splitRightSide[1][0] == 'Z')
            {
                secondPart = z;
            }
            else if (splitRightSide[1][0] == 'W')
            {
                secondPart = w;
            }
            else if (splitRightSide[1][0] == 'V')
            {
                secondPart = v;
            }
        }

        int rightSideNumber;
        if (operat == '+')
        {
            rightSideNumber = firstPart + secondPart;
        }
        else //operat == '-'
        {
            rightSideNumber = firstPart - secondPart;
        }

        if (leftSide[0] == 'X')
        {
            x = rightSideNumber;
        }
        else if (leftSide[0] == 'Y')
        {
            y = rightSideNumber;
        }
        else if (leftSide[0] == 'Z')
        {
            z = rightSideNumber;
        }
        else if (leftSide[0] == 'W')
        {
            w = rightSideNumber;
        }
        else if (leftSide[0] == 'V')
        {
            v = rightSideNumber;
        }
    }

    static void ProcessPrint(string line)
    {
        char variable = line[5];
        switch (variable)
        {
            case 'X':
                result.Append(x.ToString()); break;
            case 'Y':
                result.Append(y.ToString()); break;
            case 'Z':
                result.Append(z.ToString()); break;
            case 'V':
                result.Append(v.ToString()); break;
            case 'W':
                result.Append(w.ToString()); break;
        }
        result.Append(Environment.NewLine);
    }

    static int ProcessGoTo(string line)
    {
        string lineNumber = line.Substring(4);
        return Int32.Parse(lineNumber);
    }

    static string SeparateCodeFromNumber(string line)
    {
        StringBuilder newLine = new StringBuilder(line);
        while (Char.IsDigit(newLine[0]))
        {
            newLine.Remove(0, 1);
        }
        return newLine.ToString();
    }

    static int FindLineNumber(string line)
    {
        int index = 0;
        StringBuilder number = new StringBuilder();
        while (Char.IsDigit(line[index]))
        {
            number.Append(line[index]);
            index++;
        }
        return Int32.Parse(number.ToString());
    }

    static bool ProcessBoolExpression(string line)
    {
        char boolOperator;
        if (line.Contains("<"))
        {
            boolOperator = '<';
        }
        else if (line.Contains("="))
        {
            boolOperator = '=';
        }
        else //(line.Contains(">"))
        {
            boolOperator = '>';
        }

        string[] splitExpression = line.Split(boolOperator);
        int leftSide;
        if (Int32.TryParse(splitExpression[0], out leftSide))
        {
        }
        else if (splitExpression[0][0] == 'X')
        {
            leftSide = x;
        }
        else if (splitExpression[0][0] == 'Y')
        {
            leftSide = y;
        }
        else if (splitExpression[0][0] == 'Z')
        {
            leftSide = z;
        }
        else if (splitExpression[0][0] == 'W')
        {
            leftSide = w;
        }
        else if (splitExpression[0][0] == 'V')
        {
            leftSide = v;
        }

        int rightSide;
        if (Int32.TryParse(splitExpression[1], out rightSide))
        {
        }
        else if (splitExpression[1][0] == 'X')
        {
            rightSide = x;
        }
        else if (splitExpression[1][0] == 'Y')
        {
            rightSide = y;
        }
        else if (splitExpression[1][0] == 'Z')
        {
            rightSide = z;
        }
        else if (splitExpression[1][0] == 'W')
        {
            rightSide = w;
        }
        else if (splitExpression[1][0] == 'V')
        {
            rightSide = v;
        }

        switch (boolOperator)
        {
            case '>':
                if (leftSide > rightSide)
                    return true;
                else
                    return false;
            case '<':
                if (leftSide < rightSide)
                    return true;
                else
                    return false;
            case '=':
                if (leftSide == rightSide)
                    return true;
                else
                    return false;
            default:
                return false;
        }
    }
}