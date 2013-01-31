using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.ProgramCalculatingCorrectlyFloatDecimals
{
    class ProgramCalculatingCorrectlyDecimals
    {
        static void Main(string[] args)
        {
            float valueOne = 5.3f;
            float valueTwo = 6.01f;
            float valueThree = 5.00000001f;
            float valueFour =  5.00000003f;

            Console.WriteLine(valueOne == valueTwo); //False
            Console.WriteLine(valueThree == valueFour); // True
           
        }
    }
}
