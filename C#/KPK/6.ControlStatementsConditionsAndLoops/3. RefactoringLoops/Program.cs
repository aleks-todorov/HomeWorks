using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.RefactoringLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberNeeded = 0;
            for (int index = 0; index < 100; index++)
            {
                Console.WriteLine(array[index]);
                if (index % 10 == 0)
                {
                    if (array[index] == expectedValue)
                    {
                        numberNeeded = 666;
                        break;
                    }
                }
            }
            // More code here
            if (numberNeeded == 666)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
