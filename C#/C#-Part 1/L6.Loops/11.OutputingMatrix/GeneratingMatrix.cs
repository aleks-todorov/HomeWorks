using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.OutputingMatrix
{
    class GeneratingMatrix
    {
        static void Main()
        {
               int number = int.Parse(Console.ReadLine());
          
            for (int i = 0; i < number; i++)
            {
                for (int n = 1; n <= number; n++)
                {
                    Console.Write((n + i) + " "); 
                }
                Console.WriteLine(); 
            }
        }
    }
}
