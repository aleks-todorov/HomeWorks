using System;
using System.Collections.Generic;

class KnapstacProblem
{

    /* Task 1:  In order to simplify the example I have created custom input(so no complex parsing is required:  
6
beer 3 2
vodka 8 12
cheese 4 5
nuts 1 4
ham 2 3
whiskey 8 13
10
       
     * This video rally helped me to understand the concept of this task: 
     * 
     * http://www.youtube.com/watch?v=EH6h7WA7sDw
     * 
*/

    static void Main(string[] args)
    {
        var products = new List<Product>();

        //Reading the input
        int numberOfEntries = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfEntries; i++)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var name = input[0];
            var weight = int.Parse(input[1]);
            var cost = int.Parse(input[2]);
            products.Add(new Product(name, weight, cost));
        }

        var knapstackCapacity = int.Parse(Console.ReadLine());

        //Creating 2 assistance matrixes

        int[,] valueMatrix = new int[numberOfEntries + 1, knapstackCapacity + 1];
        int[,] keepMatrix = new int[numberOfEntries + 1, knapstackCapacity + 1];

        for (int row = 1; row <= numberOfEntries; row++)
        {
            for (int col = 1; col <= knapstackCapacity; col++)
            {

                //Here we check if the product can fit in the knapstack
                if (products[row - 1].Weight == col)
                {
                    //Here we check if the cost of the previous item with this weight is the same or smaller
                    if (products[row - 1].Cost >= valueMatrix[row - 1, col])
                    {
                        valueMatrix[row, col] = products[row - 1].Cost;
                        keepMatrix[row, col] = 1;
                    }
                    else
                    {
                        valueMatrix[row, col] = valueMatrix[row - 1, col];
                        keepMatrix[row, col] = 0;
                    }
                }

                    //This is little more complicated. First we check if the item can fit
                else if (col > products[row - 1].Weight)
                {
                    //Here we check if the item cost + the item that can fit in the remaining free space cost's is bigger than the previous item cost.
                    if (products[row - 1].Cost + valueMatrix[row - 1, col - products[row - 1].Weight] >= valueMatrix[row - 1, col])
                    {
                        valueMatrix[row, col] = products[row - 1].Cost + valueMatrix[row - 1, col - products[row - 1].Weight];
                        keepMatrix[row, col] = 1;
                    }
                    else
                    {
                        valueMatrix[row, col] = valueMatrix[row - 1, col];
                        keepMatrix[row, col] = 0;
                    }
                }
            }
        }

        //Selecting the optimal possibility 

        var startCol = keepMatrix.GetLength(1);

        while (startCol > 0)
        {
            var allFound = false;

            var startRow = keepMatrix.GetLength(0);

            for (int i = startRow - 1; i >= 0; i--)
            {
                for (int j = startCol - 1; j >= 0; j--)
                {
                    if (keepMatrix[i, j] == 1)
                    {
                        Console.WriteLine(products[i - 1].ToString());
                        allFound = true;
                        startCol = j - products[i - 1].Weight;
                        break;
                    }
                }

                if (allFound == true)
                {
                    break;
                }
            }
        }
    }
}
