using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Task 1: 
//Implement an extension method Substring(int index, int length) for the class 
//StringBuilder that returns new StringBuilder and has the same functionality as Substring in the class String.

namespace _01.ExtensionMethodSubstring
{
    class ExtensionMethodSubstring
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            text.Append("1234567891011121314151617181920");
            Console.WriteLine(text.Substring(5));
        }
    }
}
