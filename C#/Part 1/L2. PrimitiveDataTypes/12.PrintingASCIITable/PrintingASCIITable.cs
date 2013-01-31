using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.PrintingASCIITable
{
    class PrintingASCIITable
    {
        static void Main(string[] args)
        {
            char symbol;
            for (int i = 0; i < 255; i++)
            {
                symbol = (char)i;
                Console.WriteLine(symbol);
            }
        }
    }
}
