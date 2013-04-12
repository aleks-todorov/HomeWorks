using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.EscapingSymbolsInStrings
{
    class EscapingSymbolsInStrings
    {
        static void Main(string[] args)
        {
            //"The  "use"  of  quotations  causes  difficulties."
            string phraseOne = "The  \"use\"  of  quotations  causes  difficulties.";
            string phraseTwo = @"The  ""use""  of  quotations  causes  difficulties.";

            Console.WriteLine(phraseOne);
            Console.WriteLine(phraseTwo);
        }
    }
}
