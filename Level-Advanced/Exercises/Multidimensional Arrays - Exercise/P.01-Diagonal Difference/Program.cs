using System;
using System.Linq;

namespace P._01_Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n,n];

            for (int row = 0; row < n; row++)
            {
                int[] matrixData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row,col] = matrixData[col];
                }
            }

            int firstSum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        firstSum += matrix[row, col];
                    }
                }
            }

            int secondSum = 0;
            int counter = matrix.GetLength(1) - 1; 
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                secondSum += matrix[row, counter];
                counter--; //за да вземаме 1во последния елемент на реда, послед предпоследния и после предпредпоследния
            }
            int difference = Math.Abs(firstSum - secondSum);
            Console.WriteLine(difference);
        }
    }
}
