using System;
using System.Linq;

namespace P._02_SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];

            int[,] table = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] tableData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    table[row, col] = tableData[col];
                }
            }


            for (int col = 0; col < table.GetLength(1); col++)
            {
                int tableColsSum = 0;
                for (int row = 0; row < table.GetLength(0); row++)
                {
                    int currentElement = table[row, col];
                    tableColsSum += currentElement;
                }
                Console.WriteLine(tableColsSum);
            }
        }
    }
}
