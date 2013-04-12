using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CalculateShapeSurface
{
    class Application
    {
        static void Main(string[] args)
        {
            var rect = new Rectangle(5, 5);
            var area = rect.CalculateSurface();
            Console.WriteLine(area);
            var triangle = new Triangle(6, 5);
            var triangleArea = triangle.CalculateSurface();
            Console.WriteLine(triangleArea);
            //Throws an Exception
            // var circle = new Circle(5, 6);
            var circle = new Circle(5, 5);
            Console.WriteLine(circle.CalculateSurface());
            Console.WriteLine("\nAnd the same results using array: \n");
            Shape[] shapes = new Shape[3];
            shapes[0] = new Rectangle(5, 5);
            shapes[1] = new Triangle(6, 5);
            shapes[2] = new Circle(5, 5);

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.CalculateSurface());
            }
        }
    }
}
