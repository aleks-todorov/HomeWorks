using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApplication.CommonClasses
{
    public class Display
    {
        private double size;
        private int colors;

        public double Size
        {
            get { return size; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input data");
                }
                else
                {
                    size = value;
                }
            }
        }

        public int Colors
        {
            get { return colors; }
            set
            {
                if (value < 8)
                {
                    throw new ArgumentException("Invalid input data");
                }
                else
                {
                    colors = value;
                }

            }
        }

        public Display(double size, int colors)
        {
            this.Size = size;
            this.Colors = colors;
        }

        public void ToString()
        {
            Console.WriteLine("Display Size: {0} inches", this.Size);
            Console.WriteLine("Display Colors: {0}", this.Colors);
        }
    }
}
