using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.CheckingIfPointIsInsideFigures
{
    class CheckingIfPointIsInsideFigures
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the X coordinate of the point: ");
            double pointCoordinateX = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Y coordinate of the point: ");
            double pointCoordinateY = double.Parse(Console.ReadLine());
            double circleCenterX = 1.0;
            double circleCenterY = 1.0;
            double circleRadious = 3;
            bool isLocatedInCircle =false;
            if (pointCoordinateX < (circleCenterX + circleRadious) && pointCoordinateX > (circleCenterX - circleRadious) && pointCoordinateY < (circleCenterY + circleRadious) && pointCoordinateY > (circleCenterY - circleRadious))
            {
                Console.WriteLine("Point is located into the circle");
                isLocatedInCircle = true; 
            }
            else
            {
                Console.WriteLine("point is outside the circle");
            }
            double rectangleTopX = -1.0;
            double rectangleTopY = 1.0;
            double rectangleHeight = 2;
            double rectangleWidth = 6.0;
            bool isLocatedInRectangle = false;

            if (pointCoordinateX > rectangleTopX && pointCoordinateX < (rectangleTopX + rectangleWidth) && pointCoordinateY > (rectangleTopY - rectangleHeight) && pointCoordinateY < rectangleTopY)
            {
                Console.WriteLine("Point is locatad in Rectangle Area");
                isLocatedInRectangle = true; 
            }
            else
            {
                Console.WriteLine("Point is not located into the Rectangle");
            }
            if (isLocatedInCircle == true && isLocatedInRectangle == true)
            {
                Console.WriteLine("Point is located into the Circle and the Rectangle at the same time");
            }
        }
    }
}
