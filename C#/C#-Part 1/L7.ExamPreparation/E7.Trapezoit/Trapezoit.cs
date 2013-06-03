using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E7.Trapezoit
{
    class Trapezoit
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string dots = new string('.', N);
            string stars = new string('*', N);
            Console.WriteLine(dots + stars);
            for (int i = 1; i < N; i++)
            {
                dots = new string('.', N - i);
                Console.Write(dots + "*");
                dots = new string('.', N - 2 + i);
                Console.WriteLine(dots + "*");
            }
            stars = new string('*', 2 * N);
            Console.WriteLine(stars);
        }
    }
}
