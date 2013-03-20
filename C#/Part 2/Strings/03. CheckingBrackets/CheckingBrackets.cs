using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Task: 
 
 Write a program to check if in a given expression the brackets are put correctly.
Example of correct expression: ((a+b)/5-d).
Example of incorrect expression: )(a+b)).
*/
namespace _03.CheckingBrackets
{
    class CheckingBrackets
    {
        static void Main(string[] args)
        {
            // string expression = ")(a+b))";
            Console.WriteLine("Please enter expression: ");
            string expression = Console.ReadLine();
            int openingtBrackets = 0;
            int closingBrackets = 0;
            bool isOppeningFirst = false;
            bool isClosingLast = false;

            for (int i = 0; i < expression.Length; i++)
            {
                char currentChar = expression[i];

                if (currentChar == '(')
                {
                    openingtBrackets++;
                    if (openingtBrackets == 1 && closingBrackets == 0)
                    {
                        isOppeningFirst = true;
                    }
                    isClosingLast = false;
                }

                if (currentChar == ')')
                {
                    closingBrackets++;

                    if (closingBrackets == openingtBrackets)
                    {
                        isClosingLast = true;
                    }
                }
            }

            if (closingBrackets == openingtBrackets && isClosingLast == true && isOppeningFirst == true)
            {
                Console.WriteLine("Brackets are put correctly!");
            }
            else
            {
                Console.WriteLine("Brackets are NOT put correctly!");
            }
        }
    }
}
