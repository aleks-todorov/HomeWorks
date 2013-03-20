using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._3DPoint
{
    public static class PathStorage
    {
        public static List<Point> Sequence { get; set; }

        static PathStorage()
        {
            Sequence = new List<Point>();
        }

        public static void SavePath(List<Point> list)
        {
            StreamWriter writer = new StreamWriter("SavedPath.txt");
            using (writer)
            {
                foreach (var point in list)
                {
                    writer.WriteLine("{0} {1} {2}", point.PossitionX, point.PossitionY, point.PossitionZ);
                }
            }
        }

        public static List<Point> LoadPath()
        {
            var list = new List<Point>();
            StreamReader reader = new StreamReader("SavedPath.txt");
            using (reader)
            {
                char[] splitters = { ' ' };
                var line = reader.ReadLine();

                while (line != null)
                {
                    var coordinates = line.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
                    list.Add(new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1]), int.Parse(coordinates[2])));
                    line = reader.ReadLine();
                }
            }
            return list;
        }

        public static void ClearPoints(Point point)
        {
            Sequence.Clear();
        }
    }
}
