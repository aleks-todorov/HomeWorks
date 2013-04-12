using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Brackets2
{
    class Brackets2
    {
        static void Main(string[] args)
        {
            bool onNewLine = false;
            int numberOfTabulations = 0;
            int numberOfOpenningBrackets = 0;
            int numberOfClosingBrackets = 0;
            int N = int.Parse(Console.ReadLine());
            string tabSymbol = Console.ReadLine();
            StringBuilder code = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                string text = Console.ReadLine();
                for (int index = 0; index < text.Length; index++)
                {
                    char currentChar = text[index];
                    if (index == 0 && currentChar != '{' && currentChar != '}')
                    {
                        code.Append("\n");
                        onNewLine = true;
                    }
                    if (currentChar == '{')
                    {
                        if (index != 0)
                        {
                            code.Append("\n");
                        }
                        for (int j = 0; j < numberOfOpenningBrackets - numberOfClosingBrackets; j++)
                        {
                            code.Append(tabSymbol);
                        }
                        numberOfOpenningBrackets++;
                        code.Append(currentChar);
                        code.Append("\n");
                        onNewLine = true;
                        numberOfTabulations++;
                    }
                    if (currentChar == '}')
                    {
                        if (onNewLine == false)
                        {
                            code.Append("\n");
                        }
                        numberOfClosingBrackets++;
                        for (int j = 0; j < numberOfOpenningBrackets - numberOfClosingBrackets; j++)
                        {
                            code.Append(tabSymbol);
                        }
                        code.Append(currentChar);
                        numberOfTabulations--;
                        onNewLine = false;
                    }
                    else if (currentChar != '{' && currentChar != '}' && currentChar != '\n')
                    {
                        if (onNewLine == true)
                        {
                            for (int j = 0; j < numberOfOpenningBrackets - numberOfClosingBrackets; j++)
                            {
                                code.Append(tabSymbol);
                            }
                        }
                        code.Append(currentChar);
                        onNewLine = false;
                    }
                    else if (currentChar == '\n')
                    {
                        code.Append("\n");
                        onNewLine = true;
                    }
                }
            }
            string end = code.ToString();
            end = end.Replace("  ", " ");
            end = end.Replace("  ", " ");
            Console.WriteLine(end);
        }
    }
}
