using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._3DPoint
{
    public static class CalculatingDistance
    {
        public static double Estimatedifference(Point pointA, Point pointB)
        {
            double distance = Math.Sqrt(Math.Pow(pointA.PossitionX - pointB.PossitionX, 2) + Math.Pow(pointA.PossitionY - pointB.PossitionY, 2) + Math.Pow(pointA.PossitionZ - pointB.PossitionZ, 2));
            return distance;
        }

    }
}
