using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CalculatingCircleSize
{
    class CalculatingCircleSize
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter circle radius:");
            double circleRadius = double.Parse(Console.ReadLine());
            double pi = 3.1415;
            double circleArea =pi * circleRadius* circleRadius;
            double circlePerimetr = 2 * pi * circleRadius;
            Console.WriteLine("Circle Area is: {0:F2} and its Perimetr is {1:F2}", circleArea, circlePerimetr); 
        }
    }
}
