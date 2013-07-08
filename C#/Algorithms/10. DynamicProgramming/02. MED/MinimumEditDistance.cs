using System;

class MinimumEditDistance
{
    static double costReplace = 1;
    static double costDelete = 0.9;
    static double costInsert = 0.8;

    static void Main(string[] args)
    {
        var wordOne = "developer";
        var wordTwo = "enveloped";

        //Creating the edit distance matrix
        double[,] matrix = new double[wordOne.Length + 1, wordTwo.Length + 1];

        //Setting all the elements on the first row according to predefined value for costDelete
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            matrix[i, 0] = i * costDelete;
        }

        //Setting all the elements on the first col according to predefined value for costInsert
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            matrix[0, i] = i * costInsert;
        }

        //Filling the matrix with the corresponding coefficients. For more info check either google, or Nakov's book for Algorithms
        for (int row = 1; row < matrix.GetLength(0); row++)
        {
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = FindMinOfThreeElements(wordOne, wordTwo, matrix, row, col);
            }
        }

        //The result is in the bottom right cell. In this case matrix[9,9]
        var cost = matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];

        Console.WriteLine(cost);
    }

    private static double FindMinOfThreeElements(string wordOne, string wordTwo, double[,] matrix, int row, int col)
    {
        return Math.Min(matrix[row - 1, col - 1] +
                            GetCostReplace(wordOne[row - 1], wordTwo[col - 1]),
                            Math.Min(matrix[row, col - 1] + costInsert, matrix[row - 1, col] + costDelete));
    }

    public static double GetCostReplace(char a, char b)
    {
        if (a == b)
        {
            return 0;
        }

        return costReplace;
    }
}

