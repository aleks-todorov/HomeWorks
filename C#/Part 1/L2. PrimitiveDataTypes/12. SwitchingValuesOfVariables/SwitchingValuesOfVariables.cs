using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.SwitchingValuesOfVariables
{
    class SwitchingValuesOfVariables
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            int c;
            c = a;
            a = b;
            b = c;
            Console.WriteLine("{0} and {1}", a, b);
        }
    }
}
