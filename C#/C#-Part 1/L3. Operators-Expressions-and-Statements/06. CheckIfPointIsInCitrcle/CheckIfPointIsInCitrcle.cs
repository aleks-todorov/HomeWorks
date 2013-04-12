using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CheckIfPointIsInCitrcle
{
    class CheckIfPointIsInCitrcle
    {
        static void Main()
        {
            Console.WriteLine("Please enter the value for X axis: ");
            double pointCoordinateX = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the value for Y axis: ");
            double pointCoordinateY = double.Parse(Console.ReadLine());
            double circleCenter = 0;
            double circleRadius = 5;
            if (pointCoordinateX < circleRadius / 2 && pointCoordinateX > -circleRadius/2 && pointCoordinateY > - pointCoordinateY/2 && pointCoordinateY < circleRadius / 2)
            {
                Console.WriteLine("Point with coordiantes X: {0} and Y: {1} is located into the circle." , pointCoordinateX, pointCoordinateY);
            }
            else
            {
                Console.WriteLine("Point with coordiantes X: {0} and Y: {1} is NOT located into the circle.", pointCoordinateX, pointCoordinateY);
            }
        }
    }
}
