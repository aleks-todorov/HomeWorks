using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CalculateShapeSurface
{
    class Circle : Shape
    {
        public Circle(double width, double height)
            : base(width, height)
        {
            try
            {
                if (this.Width != this.Height)
                {
                    throw new ArgumentException();
                }
                else
                {
                    this.Width = width;
                    this.Height = height;
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Both Values must be equal!!!");
            }
        }

        public override double CalculateSurface()
        {
            double area = (this.Width * Math.PI * Math.PI);
            return area;
        }
    }
}
