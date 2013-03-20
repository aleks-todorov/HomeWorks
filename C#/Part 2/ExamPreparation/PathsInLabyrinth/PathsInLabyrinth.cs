#define DEBUG_MODE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathsInLabyrinth
{
    class PathsInLabyrinth
    {
        static char[,] lab =
        {
            {'-','-','-','*','-','-','-'},
            {'*','*','-','*','-','*','-'},
            {'-','-','-','-','-','-','-'},
            {'-','*','*','*','*','*','-'},
            {'-','-','-','-','-','-','e'}
       };

        static char[] path = new char[lab.GetLength(0) * lab.GetLength(1)];
        static int possition = 0;

        static void FindPath(int row, int col, char direction)
        {

#if DEBUG_MODE
            PrintLabirinth(lab, row, col);
#endif

            if ((col < 0) || (row < 0) || (col >= lab.GetLength(1)) || (row >= lab.GetLength(0)))
            {
                return;
            }

            path[possition] = direction;
            possition++;
            if (lab[row, col] == 'e')
            {
                PrintPath(path, 1, possition - 1);
            }
            if (lab[row, col] == '-')
            {
                lab[row, col] = 's';
                FindPath(row, col - 1, 'L');
                FindPath(row - 1, col, 'U');
                FindPath(row, col + 1, 'R');
                FindPath(row + 1, col, 'D');

                //Backtracking off
                //lab[row, col] = '-';
            }
            possition--;
        }

        private static void PrintLabirinth(char[,] lab, int currentRow, int currentCol)
        {
            for (int row = 0; row < lab.GetLength(0); row++)
            {
                for (int col = 0; col < lab.GetLength(1); col++)
                {
                    if (row == currentRow && col == currentCol)
                    {
                        Console.ForegroundColor.Equals("red");
                    }
                    Console.Write(lab[row, col]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        static void PrintPath(char[] path, int startPossition, int endPossition)
        {
            Console.WriteLine("Found path to the exit: ");
            for (int pos = startPossition; pos <= endPossition; pos++)
            {
                Console.Write(path[pos]);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            FindPath(0, 0, 'S');
        }
    }
}
