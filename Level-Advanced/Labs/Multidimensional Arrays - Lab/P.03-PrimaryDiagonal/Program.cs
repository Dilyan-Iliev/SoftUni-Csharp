using System;
using System.Linq;

namespace P._03_PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixRowsAndCols = int.Parse(Console.ReadLine());

            int[,] table = new int[matrixRowsAndCols, matrixRowsAndCols];

            for (int row = 0; row < matrixRowsAndCols; row++)
            {
                int[] matrixData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < matrixRowsAndCols; col++)
                {
                    table[row, col] = matrixData[col];
                }
            }

            int matrixDiagonalSum = 0;

            for (int row = 0; row < table.GetLength(0); row++)
            {
                
                for (int col = 0; col < table.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        matrixDiagonalSum += table[row, col]; 
                    //винаги ми трябва елемент, при който номера на реда е равен на номера на колоната
                    }
                }
            }
            Console.WriteLine(matrixDiagonalSum);
        }
    }
}
