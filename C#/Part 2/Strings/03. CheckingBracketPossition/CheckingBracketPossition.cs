using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* Taks: 
Write a program to check if in a given expression the brackets are put correctly.
Example of correct expression: ((a+b)/5-d).
Example of incorrect expression: )(a+b)).*/

namespace _03.CheckingBracketPossition
{
    class CheckingBracketPossition
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter expression: ");
            string expression = Console.ReadLine();
            //string expression = ")(a+b)/5-d(";
            int openBracket = 0;
            int closeBracket = 0;
            bool isFirstOppening = false;
            bool isLastClosing = false;
            foreach (var letter in expression)
            {
                if (letter == '(')
                {
                    openBracket++;
                    if (openBracket == 1 && closeBracket == 0)
                    {
                        isFirstOppening = true;
                    }
                    isLastClosing = false;
                }
                if (letter == ')')
                {
                    closeBracket++;
                    isLastClosing = true;
                }
            }
            if (openBracket != closeBracket || isFirstOppening == false || isLastClosing == false)
            {
                Console.WriteLine("Brackets are NOT correct");
            }
            if (openBracket == closeBracket && isFirstOppening == true && isLastClosing == true)
            {
                Console.WriteLine("Brackets are correct");
            }

        }
    }
}
