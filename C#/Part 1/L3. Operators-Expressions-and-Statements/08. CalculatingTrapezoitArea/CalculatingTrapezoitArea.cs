using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CalculatingTrapezoitArea
{
    class CalculatingTrapezoitArea
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter Trapezoid's side a: ");
            double sideA = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter Trapezoid's side b: ");
            double sideB = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter Trapezoid's height: ");
            double heightH = double.Parse(Console.ReadLine());
            double trapezoitArea = (sideA + sideB) / 2 * heightH;
            Console.WriteLine("The area of the Trapezoit is : " + trapezoitArea);
        }
    }
}
