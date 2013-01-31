using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SolvingQuadraticEquation
{
    class SolvingQuadraticEquation
    {
        static void Main(string[] args)
        {
            double a = int.Parse(Console.ReadLine());
            double b = int.Parse(Console.ReadLine());
            double c = int.Parse(Console.ReadLine());
            double rootOne;
            double rootTwo;
            double D = b * b - 4 * a * c;
            if (D < 0)
            {
                Console.WriteLine("There are no real roots");
            }
            else if (D == 0)
            {
                rootOne = rootTwo = (-b / 2 * a);
                Console.WriteLine("Roon one and root two are equal to : {0}", rootOne);
            }
            else if (D > 0)
            {
                rootOne = ((-b + Math.Sqrt(D)) / (2 * a));
                rootTwo = ((-b - Math.Sqrt(D)) / (2 * a));
                Console.WriteLine("Root one is {0} and root two is {1}", rootOne, rootTwo);
            }
        }
    }
}
