using System;

class SearchingForPathOnBiggerArray
{
    /*Task 8: Modify the above program to check whether a path exists between 
     * two cells without finding all possible paths. 
     * Test it over an empty 100 x 100 matrix.*/

    static char[,] lab = new char[100, 100];
    static char[] path = new char[lab.GetLength(0) * lab.GetLength(1)];
    static int position = 0;
    static bool pathFound = false;
    static Random randomGenerator = new Random();

    static void Main(string[] args)
    {
        var row = randomGenerator.Next(0, 100);
        var col = randomGenerator.Next(0, 100);
        lab[row, col] = 'x';
        FindPath(0, 0, 'D');
        Console.WriteLine();

    }
    static void FindPath(int row, int col, char direction)
    {
        if ((col < 0) || (row < 0) ||
          (col >= lab.GetLength(1)) || (row >= lab.GetLength(0)) || pathFound == true)
        {
            return;
        }

        path[position] = direction;
        position++;

        if (lab[row, col] == 'x')
        {
            PrintPath(path, 1, position - 1);
            pathFound = true;
        }
        if (lab[row, col] == '\0')
        {

            lab[row, col] = 's';

            FindPath(row, col - 1, 'L');
            FindPath(row - 1, col, 'U');
            FindPath(row, col + 1, 'R');
            FindPath(row + 1, col, 'D');
        }

        position--;
    }

    static void PrintPath(char[] path, int startPos, int endPos)
    {
        Console.Write("Found path to the exit: ");
        for (int pos = startPos; pos <= endPos; pos++)
        {
            Console.Write(path[pos]);
        }
        Console.WriteLine();
    }
}

