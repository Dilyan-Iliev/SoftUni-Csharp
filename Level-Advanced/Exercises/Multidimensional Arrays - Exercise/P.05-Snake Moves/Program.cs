using System;
using System.Linq;

namespace P._05_Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];

            char[,] matrix = new char[rows, cols];

            string snakeName = Console.ReadLine();

            bool isLeftToRight = true; //flag which tells us from left to right or right to left to go
            int counter = 0; //used for itterating through snakeName symbols

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (isLeftToRight)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snakeName[counter];
                        counter++;

                        if (counter == snakeName.Length)
                        {
                            counter = 0;
                        }
                    }
                    isLeftToRight = false;
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snakeName[counter];
                        counter++;

                        if (counter == snakeName.Length)
                        {
                            counter = 0;
                        }
                    }
                    isLeftToRight = true;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
