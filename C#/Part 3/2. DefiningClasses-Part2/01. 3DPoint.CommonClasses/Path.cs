using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._3DPoint
{
    public static class Path
    {
        public static List<Point> Sequence { get; set; }

        static Path()
        {
            Sequence = new List<Point>();
        }

        public static void AddPoint(Point point)
        {
            Sequence.Add(point);
        }

        public static void ClearPoints(Point point)
        {
            Sequence.Clear();
        }
    }
}
