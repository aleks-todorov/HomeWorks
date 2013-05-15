using System;

public class RotatingMatrix
{
    //This application was small and I did not find need to make it with OOP.
    static void Main(string[] args)
    {
        int number = 0;
        var isValid = false;

        do
        {
            Console.Write("Enter a positive number: ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out number);
        }
        while (!isValid || number < 0);

        int[,] matrix = GenerateRotationWalkMatrix(number);

        PrintOnConsole(matrix);
    }

    public static int[,] GenerateRotationWalkMatrix(int n)
    {
        int[,] matrix = new int[n, n];
        var nextNumber = 1;
        var currentRow = 0;
        var currentCol = 0;
        var directionRow = 1;
        var directionCol = 1;

        while (true)
        {
            matrix[currentRow, currentCol] = nextNumber;

            if (!CheckForAvailableCell(matrix, currentRow, currentCol))
            {
                FindNextAvailableCell(matrix, out currentRow, out currentCol);

                nextNumber++;

                if (currentRow != 0 && currentCol != 0)
                {
                    directionRow = 1; directionCol = 1;

                    while (true)
                    {
                        matrix[currentRow, currentCol] = nextNumber;

                        if (!CheckForAvailableCell(matrix, currentRow, currentCol))
                        {
                            break;
                        }

                        while (CheckIfNextXellIsValid(matrix, currentRow, currentCol, directionRow, directionCol))
                        {
                            RotateUntillAvailableCellIsFound(ref directionRow, ref directionCol);
                        }

                        currentRow += directionRow;
                        currentCol += directionCol;
                        nextNumber++;
                    }
                }

                break;
            }

            while (CheckIfNextXellIsValid(matrix, currentRow, currentCol, directionRow, directionCol))
            {
                RotateUntillAvailableCellIsFound(ref directionRow, ref directionCol);
            }

            currentRow += directionRow;
            currentCol += directionCol;
            nextNumber++;
        }

        return matrix;
    }

    private static bool CheckIfNextXellIsValid(int[,] matrix, int currectRow, int currectCol, int directionRow, int directionCol)
    {
        return CheckForInvalidRow(matrix, currectRow, directionRow) ||
               CheckForInvalidCol(matrix, currectCol, directionCol) ||
               CheckIfNextCellIsNotAvaible(matrix, currectRow, currectCol, directionRow, directionCol);
    }


    //All checks are separated in different methods for readability.
    private static bool CheckIfNextCellIsNotAvaible(int[,] matrix, int currectRow, int currectCol, int directionRow, int directionCol)
    {
        return matrix[currectRow + directionRow, currectCol + directionCol] != 0;
    }

    private static bool CheckForInvalidRow(int[,] matrix, int currectRow, int directionRow)
    {
        return currectRow + directionRow >= matrix.GetLength(0) || currectRow + directionRow < 0;
    }

    private static bool CheckForInvalidCol(int[,] matrix, int currectCol, int directionCol)
    {
        return currectCol + directionCol >= matrix.GetLength(1) || currectCol + directionCol < 0;
    }

    // Help methods required for the correct function of the matrix
    static bool CheckForAvailableCell(int[,] arr, int row, int col)
    {
        int[] dirRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] dirCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

        for (int i = 0; i < dirRow.Length; i++)
        {
            if (row + dirRow[i] >= arr.GetLength(0) || row + dirRow[i] < 0)
            {
                dirRow[i] = 0;
            }

            if (col + dirCol[i] >= arr.GetLength(0) || col + dirCol[i] < 0)
            {
                dirCol[i] = 0;
            }
        }

        for (int i = 0; i < dirRow.Length; i++)
        {
            if (arr[row + dirRow[i], col + dirCol[i]] == 0)
            {
                return true;
            }
        }

        return false;
    }

    static void RotateUntillAvailableCellIsFound(ref int dx, ref int dy)
    {
        int[] dirRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] dirCol = { 1, 0, -1, -1, -1, 0, 1, 1 };
        int cd = 0;

        for (int count = 0; count < dirRow.Length; count++)
        {
            if (dirRow[count] == dx && dirCol[count] == dy)
            {
                cd = count;
                break;
            }
        }

        if (cd == 7)
        {
            dx = dirRow[0];
            dy = dirCol[0];
            return;
        }

        dx = dirRow[cd + 1];
        dy = dirCol[cd + 1];
    }

    static void FindNextAvailableCell(int[,] arr, out int row, out int col)
    {
        row = 0;
        col = 0;

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] == 0)
                {
                    row = i;
                    col = j;
                    return;
                }
            }
        }
    }

    static void PrintOnConsole(int[,] matix)
    {
        for (int row = 0; row < matix.GetLength(0); row++)
        {
            for (int col = 0; col < matix.GetLength(1); col++)
            {
                Console.Write("{0,4}", matix[row, col]);
            }

            Console.WriteLine();
        }
    }
}