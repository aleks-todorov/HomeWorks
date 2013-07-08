using System;

class Application
{
    static void Main(string[] args)
    {
        //For more information about the tasks, see comments below. 
    }

    long Compute(int[] arr)
    {
        /*Task 1:
         * For this method the running time will be n*n, because first we have
         * one for cycle which will runn exactly n times and in it we have 
         * while cycle which will run n-1 times, so the running steps for this are 
         * n*n - n and the complexity is ~O(n*n).
         */

        long count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            int start = 0, end = arr.Length - 1;
            while (start < end)
                if (arr[start] < arr[end])
                { start++; count++; }
                else
                    end--;
        }
        return count;
    }

    long CalcCount(int[,] matrix)
    {
        /*Task2: 
         * For this task the running time will be k(n*m), because we have
         * for cycle which is running n times and in it we have second for cycle which
         * will run m*k, where k is the number of even numbers in the matrix, so we 
         * have k(n*m).The running steps are k(n*m) and 
         * the complexity is ~O(n*m). 
         */

        long count = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
            if (matrix[row, 0] % 2 == 0)
                for (int col = 0; col < matrix.GetLength(1); col++)
                    if (matrix[row, col] > 0)
                        count++;
        return count;
    }

    long CalcSum(int[,] matrix, int row)
    {

        /*Task3 
         * There is an error here: matrix.GetLenght(0) and matrix.GetLenght(1) should be changed. In this case 
         * if matrix.GetLenght(0) != matrix.GetLenght(1) an exception will be thrown. 
         * If we asume that the matrix is squared, so the steps required are: m for the for cycle and
         * the recursion will be called exactly n-1 times. 
         * Running steps: m*n - m and complexity: ~O(n*m). 
         */

        long sum = 0;
        for (int col = 0; col < matrix.GetLength(0); col++)
            sum += matrix[row, col];
        if (row + 1 < matrix.GetLength(1))
            sum += CalcSum(matrix, row + 1);
        return sum;
    }
}
