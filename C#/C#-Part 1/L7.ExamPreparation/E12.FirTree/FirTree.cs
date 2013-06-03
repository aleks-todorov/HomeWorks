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
            for (int i = 0; i < N - 1; i++)
            {
                symbol = new string('*', (i * 2) + 1);
                space = new string('.', (N - 2 - i));
                Console.Write(space);
                Console.Write(symbol);
                Console.Write(space);
                Console.WriteLine();
            }
            space = new string('.', N - 2);
            Console.WriteLine(space + "*" + space);
        }

    }
}

