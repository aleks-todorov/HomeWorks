using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._3DPoint
{
    public struct Point
    {
        private static Point origin = new Point(0, 0, 0);

        public Point Origin
        {
            get { return origin; }
        }

        public int PossitionX { get; set; }
        public int PossitionY { get; set; }
        public int PossitionZ { get; set; }

        public Point(int possitionX, int possitionY, int possitionZ)
            : this()
        {
            this.PossitionX = possitionX;
            this.PossitionY = possitionY;
            this.PossitionZ = possitionZ;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("PossitionX: {0}", this.PossitionX);
            result.AppendFormat("PossitionY: {0}", this.PossitionY);
            result.AppendFormat("PossitionZ: {0}", this.PossitionZ);
            return result.ToString();
        }

    }
}
