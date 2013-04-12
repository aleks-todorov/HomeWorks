using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Brackets
{
    class Brackets
    {
        static void Main(string[] args)
        {
            int numberOfTabulations = 0;
            int numberOfRows = int.Parse(Console.ReadLine());
            string tabulationSymbol = Console.ReadLine();
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < numberOfRows; i++)
            {
                string line = Console.ReadLine();
                for (int index = 0; index < line.Length; index++)
                {
                    char currentChar = line[index];
                    if (currentChar == '{')
                    {
                        text.Append("\n");
                        for (int j = 0; j < numberOfTabulations; j++)
                        {
                            text.Append(tabulationSymbol);
                        }
                        text.Append(currentChar);
                        numberOfTabulations++;
                        text.Append("\n");
                    }
                    else if (currentChar == '}')
                    {
                        numberOfTabulations--;
                        text.Append("\n");
                        for (int j = 0; j < numberOfTabulations; j++)
                        {
                            text.Append(tabulationSymbol);
                        }
                        text.Append(currentChar);
                        text.Append("\n");
                        numberOfTabulations--;
                    }
                    else if (line.Length > 0)
                    {
                        if (text[index - 1] == '\n')
                            for (int j = 0; j < numberOfTabulations; j++)
                            {
                                text.Append(tabulationSymbol);
                            }
                    }
                    text.Append(currentChar);
                    if (line[index] == line.Length - 1)
                    {
                        text.Append("\n");
                    }
                }
            }

            string final = text.ToString();
            Console.WriteLine(final);
        }
    }
}
