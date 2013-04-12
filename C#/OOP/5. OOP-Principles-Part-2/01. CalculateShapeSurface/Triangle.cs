using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CalculateShapeSurface
{
    class Triangle : Shape
    {
        public Triangle(double width, double height)
            : base(width, height)
        {

        }

        public override double CalculateSurface()
        {
            double area = (this.Width * this.Height) / 2;
            return area;
        }
    }
}
