using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.DeclaringStringsAndObjects
{
    class DeclaringStringsAndObjects
    {
        static void Main(string[] args)
        {
            string wordOne = "Hello";
            string wordTwo = "World";
            object phrase = wordOne + wordTwo;
            Console.WriteLine(phrase);
            string wordThree = (string)phrase;
            Console.WriteLine(wordThree);

        }
    }
}
