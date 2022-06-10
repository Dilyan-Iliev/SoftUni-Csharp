using System;
using System.Linq;

namespace P._02_Garden
{
    internal class Program
    {
        private const string ErrorMessage = "Invalid coordinates.";

        static void Main()
        {
            int[] sizeData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = sizeData[0];
            var cols = sizeData[1];

            int[,] matrix = new int[rows, cols];

            string coordinates;
            while ((coordinates = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinatesTokens = coordinates
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = coordinatesTokens[0];
                int col = coordinatesTokens[1];

                if (!CheckForValidCoordinates(rows, cols, row, col))
                {
                    Console.WriteLine(ErrorMessage);
                    continue;
                }

                CheckForCoincedence(matrix, row, col);

            }

            PrintOutput(matrix);
        }

        static void CheckForCoincedence(int[,] matrix, int row, int col)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (r == row || c == col)
                    {
                        matrix[r, c] += 1;
                    }
                }
            }
        }

        static bool CheckForValidCoordinates(int rows, int cols, int row, int col)
        {
            if (row < 0 || row >= rows
                                || col < 0 || col >= cols)
            {
                return false;
            }

            return true;
        }

        static void PrintOutput(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
