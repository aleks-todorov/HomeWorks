using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.DeclaringStringsAndAssigningObjectoToString
{
    class DeclaringStringsAndAssigningObjectoToString
    {
        static void Main(string[] args)
        {
            string wordOne = "Hello";
            string wordTwo = "World";
            object phrase = wordOne + " " + wordTwo;
            Console.WriteLine(phrase);
            string wordThree = phrase.ToString();
            Console.WriteLine(wordThree);
        }
    }
}
