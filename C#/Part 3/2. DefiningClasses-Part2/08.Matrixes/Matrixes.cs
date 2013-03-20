using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08.MatrixOperations;

namespace _08.Matrixes
{
    class Matrixes
    {
        static void Main(string[] args)
        {
            //Task 8: 
            JustMatrix<int> matrixA = new JustMatrix<int>(5, 5);
            matrixA.FillMatrix();
            Console.WriteLine(matrixA.ToString());
            JustMatrix<int> matrixB = new JustMatrix<int>(5, 5);
            matrixB.FillMatrix();
            Console.WriteLine(matrixB.ToString());
            //Task 9:
            //Console.WriteLine(matrix[3, 4]);

            //Task 10:
            JustMatrix<int> matrixC;
            matrixC = matrixA + matrixB;
            Console.WriteLine(matrixC.ToString());
            matrixC = matrixA - matrixB;
            Console.WriteLine(matrixC.ToString());
            matrixC = matrixA * matrixB;
            Console.WriteLine(matrixC.ToString());

        }
    }
}
