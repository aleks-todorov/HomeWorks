using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.ChoosingCorrectDecimalType
{
    class ChoosingCorrectDecimalType
    {
        static void Main(string[] args)
        {
            //34.567839023; 12.345; 8923.1234857; 3456.091

            double firstValue = 34.567839023d;
            float secondValue = 12.345f;
            double thirthValue = 8923.1234857d;
            float fourthValue = 3456.091f;

            Console.WriteLine(firstValue);
            Console.WriteLine(secondValue);
            Console.WriteLine(thirthValue);
            Console.WriteLine(fourthValue);
        }
    }
}
