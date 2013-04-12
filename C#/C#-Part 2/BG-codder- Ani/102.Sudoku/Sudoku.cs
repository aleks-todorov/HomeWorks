using System;
using System.Collections.Generic;

//100/100 :)
namespace Sudoku
{
    class Sudoku
    {
        static void Main(string[] args)
        {
            string[,] stringSudoku = new string[9, 9];

            for (int u = 0; u < 9; u++)
            {
                string help = Console.ReadLine().ToString();
                for (int i = 0; i < 9; i++)
                {
                    stringSudoku[u, i] = help[i].ToString();
                }
            }

            List<int[]> initiallyEmptyCells = new List<int[]>();
            int[,] sudoku = new int[9, 9];
            Queue<int>[,] availableOptions = new Queue<int>[9, 9];

            for (int u = 0; u < 9; u++)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (!Int32.TryParse(stringSudoku[u, i], out sudoku[u, i]))
                    {
                        initiallyEmptyCells.Add(new int[] { u, i });
                        availableOptions[u, i] = ReturnNewFilledQueue();
                    }
                }
            }

            CheckCurrentSudokuCellWithRecursion(0, ref sudoku, ref initiallyEmptyCells, ref availableOptions);
            PrintSudoku(ref sudoku);

        }

        static void CheckCurrentSudokuCellWithRecursion(int indexOfCell, ref int[,] sudoku, ref List<int[]> initiallyEmptyCells, ref Queue<int>[,] availableOptions)
        {
            int currentX = initiallyEmptyCells[indexOfCell][0];
            int currentY = initiallyEmptyCells[indexOfCell][1];

            while (!CheckIfSudokuIsSolved(ref sudoku))
            {
                do
                {
                    if (availableOptions[currentX, currentY].Count == 0)
                    {
                        availableOptions[currentX, currentY] = ReturnNewFilledQueue();
                        sudoku[currentX, currentY] = 0;
                        return;
                    }
                    sudoku[currentX, currentY] = availableOptions[currentX, currentY].Dequeue();
                }
                while (CheckIfNumberViolatesSudoku(sudoku[currentX, currentY], currentX, currentY, ref sudoku));

                if (!(indexOfCell == initiallyEmptyCells.Count - 1))
                {
                    CheckCurrentSudokuCellWithRecursion(indexOfCell + 1, ref sudoku, ref initiallyEmptyCells, ref availableOptions);
                }
            }
        }

        static bool CheckIfNumberViolatesSudoku(int number, int x, int y, ref int[,] sudoku)
        {
            //check the row
            for (int i = 0; i < 9; i++)
            {
                if (i == y)
                {
                    continue;
                }
                if (sudoku[x, i] == number)
                {
                    return true;
                }
            }

            //check the column
            for (int u = 0; u < 9; u++)
            {
                if (u == x)
                {
                    continue;
                }
                if (sudoku[u, y] == number)
                {
                    return true;
                }
            }

            //check the box
            //first line
            if (x >= 0 && x <= 2)
            {
                if (y >= 0 && y <= 2)
                {
                    for (int u = 0; u <= 2; u++)
                    {
                        for (int i = 0; i <= 2; i++)
                        {
                            if (u == x && y == i)
                            {
                                continue;
                            }
                            if (sudoku[x, y] == sudoku[u, i])
                            {
                                return true;
                            }
                        }
                    }
                }
                if (y >= 3 && y <= 5)
                {
                    for (int u = 0; u <= 2; u++)
                    {
                        for (int i = 3; i <= 5; i++)
                        {
                            if (x == u && y == i)
                            {
                                continue;
                            }
                            if (sudoku[x, y] == sudoku[u, i])
                            {
                                return true;
                            }
                        }
                    }
                }
                if (y >= 6 && y <= 8)
                {
                    for (int u = 0; u <= 2; u++)
                    {
                        for (int i = 6; i <= 8; i++)
                        {
                            if (x == u && y == i)
                            {
                                continue;
                            }
                            if (sudoku[x, y] == sudoku[u, i])
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            //second line
            if (x >= 3 && x <= 5)
            {
                if (y >= 0 && y <= 2)
                {
                    for (int u = 3; u <= 5; u++)
                    {
                        for (int i = 0; i <= 2; i++)
                        {
                            if (x == u && y == i)
                            {
                                continue;
                            }
                            if (sudoku[x, y] == sudoku[u, i])
                            {
                                return true;
                            }
                        }
                    }
                }
                if (y >= 3 && y <= 5)
                {
                    for (int u = 3; u <= 5; u++)
                    {
                        for (int i = 3; i <= 5; i++)
                        {
                            if (x == u && y == i)
                            {
                                continue;
                            }
                            if (sudoku[x, y] == sudoku[u, i])
                            {
                                return true;
                            }
                        }
                    }
                }
                if (y >= 6 && y <= 8)
                {
                    for (int u = 3; u <= 5; u++)
                    {
                        for (int i = 6; i <= 8; i++)
                        {
                            if (x == u && y == i)
                            {
                                continue;
                            }
                            if (sudoku[x, y] == sudoku[u, i])
                            {
                                return true;
                            }
                        }
                    }
                }
                //third line
                if (x >= 6 && x <= 8)
                {
                    if (y >= 0 && y <= 2)
                    {
                        for (int u = 6; u <= 8; u++)
                        {
                            for (int i = 0; i <= 2; i++)
                            {
                                if (x == u && y == i)
                                {
                                    continue;
                                }
                                if (sudoku[x, y] == sudoku[u, i])
                                {
                                    return true;
                                }
                            }
                        }
                    }
                    if (y >= 3 && y <= 5)
                    {
                        for (int u = 6; u <= 8; u++)
                        {
                            for (int i = 3; i <= 5; i++)
                            {
                                if (x == u && y == i)
                                {
                                    continue;
                                }
                                if (sudoku[x, y] == sudoku[u, i])
                                {
                                    return true;
                                }
                            }
                        }
                    }
                    if (y >= 6 && y <= 8)
                    {
                        for (int u = 6; u <= 8; u++)
                        {
                            for (int i = 6; i <= 8; i++)
                            {
                                if (x == u && y == i)
                                {
                                    continue;
                                }
                                if (sudoku[x, y] == sudoku[u, i])
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        static void PrintSudoku(ref int[,] sudoku)
        {
            for (int u = 0; u < 9; u++)
            {
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(sudoku[u, i]);
                }
                Console.WriteLine();
            }
        }

        static Queue<int> ReturnNewFilledQueue()
        {
            Queue<int> result = new Queue<int>();
            for (int i = 1; i <= 9; i++)
            {
                result.Enqueue(i);
            }
            return result;
        }

        static bool CheckIfSudokuIsSolved(ref int[,] sudoku)
        {
            for (int u = 0; u < 9; u++)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (sudoku[u, i] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}