using System;

namespace _10.PrinitngTriangleOnConsole
{
    class PrinitngTriangleOnConsole
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            string symbol = new string('*', 1);
            string space = new string('.', 1);
            for (int i = 0; i < N / 2; i++)
            {
                symbol = new string('*', N - i * 2);
                space = new string('.', i);
                Console.Write(space);
                Console.Write(symbol);
                Console.Write(space);
                Console.WriteLine();
            }
            for (int i = 0; i < N / 2 + 1; i++)
            {
                symbol = new string('*', (i * 2) + 1);
                space = new string('.', N / 2 - i);
                Console.Write(space);
                Console.Write(symbol);
                Console.Write(space);
                Console.WriteLine();
            }
        }

    }
}

