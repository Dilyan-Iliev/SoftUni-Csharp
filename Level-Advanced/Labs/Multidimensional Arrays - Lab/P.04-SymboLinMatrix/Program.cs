using System;
using System.Linq;

namespace P._04_SymboLinMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //number of rows and cols in the matrix
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] matrixData = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = matrixData[col];
                }
            }

            char symbolToLookFor = char.Parse(Console.ReadLine());
            //bool hasFound = false; //could work without boolean

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currElement = matrix[row, col];

                    if (currElement == symbolToLookFor)
                    {
                        //hasFound = true;
                        //int currentRow = row;
                        //int currentCol = col;
                        //Console.WriteLine($"({currentRow}, {currentCol})");

                        //or
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
                //if (hasFound)
                //{
                //break;
                //}
            }
            Console.WriteLine($"{symbolToLookFor} does not occur in the matrix");
        }
    }
}
