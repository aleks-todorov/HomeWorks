using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MatrixOperations
{
    public class JustMatrix<T>
        where T : struct
    {
        Random random = new Random();
        public T[,] Array { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public JustMatrix(int rows, int cols)
        {
            Array = new T[rows, cols];
            Row = Array.GetLength(0);
            Col = Array.GetLength(1);
        }

        public T this[int row, int col]
        {
            get
            {
                if (Row < row || Col < col || row < 0 || col < 0)
                {
                    throw new ArgumentOutOfRangeException("Index was outside the boundaries of the array");
                }
                else return Array[row, col];
            }

            set
            {
                if (Row < row || Col < col || row < 0 || col < 0)
                {
                    throw new ArgumentOutOfRangeException("Index was outside the boundaries of the array");
                }
                else Array[row, col] = value;
            }
        }

        public void FillMatrix()
        {
            for (int row = 0; row < Array.GetLength(0); row++)
            {
                for (int col = 0; col < Array.GetLength(1); col++)
                {
                    Array[row, col] = (T)Convert.ChangeType(Convert.ToDecimal(random.Next(0, 10)), typeof(T));
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < Array.GetLength(0); row++)
            {
                for (int col = 0; col < Array.GetLength(1); col++)
                {
                    result.Append(Array[row, col] + " ");
                }
                result.Append("\n");
            }
            return result.ToString();
        }

        public static JustMatrix<T> operator +(JustMatrix<T> matrixA, JustMatrix<T> matrixB)
        {
            JustMatrix<T> newArr = new JustMatrix<T>(matrixA.Row, matrixA.Col);
            try
            {
                if (matrixA.Row != matrixB.Row || matrixA.Col != matrixB.Col)
                {

                    throw new ArgumentException();
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Both Matrices are not of the same size. Addition cannot be done!");
                return newArr;
            }

            for (int row = 0; row < matrixA.Row; row++)
            {
                for (int col = 0; col < matrixA.Col; col++)
                {
                    //Implemented with both ways. 
                    newArr[row, col] = (T)Convert.ChangeType(Convert.ToDecimal(matrixA[row, col]) + Convert.ToDecimal(matrixB[row, col]), typeof(T));
                    //newArr[row, col] = (dynamic)matrixA[row, col] + (dynamic)matrixB[row, col];
                }
            }
            return newArr;
        }
        public static JustMatrix<T> operator -(JustMatrix<T> matrixA, JustMatrix<T> matrixB)
        {
            JustMatrix<T> newArr = new JustMatrix<T>(matrixA.Row, matrixA.Col);
            try
            {
                if (matrixA.Row != matrixB.Row || matrixA.Col != matrixB.Col)
                {

                    throw new ArgumentException();
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Both Matrices are not of the same size. Substraction cannot be done!");
                return newArr;
            }

            for (int row = 0; row < matrixA.Row; row++)
            {
                for (int col = 0; col < matrixA.Col; col++)
                {
                    //Implemented with both ways. 
                    //newArr[row, col] = (T)Convert.ChangeType(Convert.ToDecimal(matrixA[row, col]) - Convert.ToDecimal(matrixB[row, col]), typeof(T));
                    newArr[row, col] = (dynamic)matrixA[row, col] - (dynamic)matrixB[row, col];
                }
            }
            return newArr;
        }

        public static JustMatrix<T> operator *(JustMatrix<T> matrixA, JustMatrix<T> matrixB)
        {

            JustMatrix<T> newArr = new JustMatrix<T>(matrixA.Row, matrixB.Col);

            for (int row = 0; row < newArr.Row; row++)
            {
                for (int col = 0; col < newArr.Col; col++)
                {
                    for (int i = 0; i < matrixA.Col; i++)
                    {
                        newArr[row, col] += (dynamic)matrixA[row, i] * (dynamic)matrixB[i, col];
                    }
                }
            }
            return newArr;
        }

        public static Boolean operator true(JustMatrix<T> matrixA)
        {
            T sum = (dynamic)0;
            for (int row = 0; row < matrixA.Row; row++)
            {
                for (int col = 0; col < matrixA.Col; col++)
                {
                    sum += (dynamic)matrixA[row, col];
                }
            }

            if (sum > (dynamic)0)
            {
                return true;
            }
            return false;
        }

        public static Boolean operator false(JustMatrix<T> matrixA)
        {
            T sum = (dynamic)0;
            for (int row = 0; row < matrixA.Row; row++)
            {
                for (int col = 0; col < matrixA.Col; col++)
                {
                    sum += (dynamic)matrixA[row, col];
                }
            }

            if (sum != (dynamic)0)
            {
                return false;
            }
            return true;
        }
    }
}
