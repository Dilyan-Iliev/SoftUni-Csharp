using System;

namespace _3
{
    internal class Program
    {
        private static int startRow = 0;
        private static int startCol = 0;
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            MatrixFill(matrix);

            int firstMove = 1;
            int holes = 0;
            int rods = 0;

            string direction;
            while ((direction = Console.ReadLine()) != "End")
            {
                if (direction == "up" && IsValidRow(startRow - 1, size))
                {
                    if (FirstMove(ref firstMove, matrix))
                    {
                        holes++;
                    }

                    matrix[startRow, startCol] = '*';
                    startRow--;

                    if (IsThereRod(matrix))
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        startRow++;
                        matrix[startRow, startCol] = 'V';
                        rods++;
                        continue;
                    }

                    holes = MatrixMovement(matrix, holes);
                }
                else if (direction == "down" && IsValidRow(startRow + 1, size))
                {
                    if (FirstMove(ref firstMove, matrix))
                    {
                        holes++;
                    }

                    matrix[startRow, startCol] = '*';
                    startRow++;

                    if (IsThereRod(matrix))
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        startRow--;
                        matrix[startRow, startCol] = 'V';
                        rods++;
                        continue;
                    }

                    holes = MatrixMovement(matrix, holes);
                }
                else if (direction == "left" && IsValidCol(startCol - 1, size))
                {
                    if (FirstMove(ref firstMove, matrix))
                    {
                        holes++;
                    }

                    matrix[startRow, startCol] = '*';
                    startCol--;

                    if (IsThereRod(matrix))
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        startCol++;
                        matrix[startRow, startCol] = 'V';
                        rods++;
                        continue;
                    }

                    holes = MatrixMovement(matrix, holes);
                }
                else if (direction == "right" && IsValidCol(startCol + 1, size))
                {
                    if (FirstMove(ref firstMove, matrix))
                    {
                        holes++;
                    }

                    matrix[startRow, startCol] = '*';
                    startCol++;

                    if (IsThereRod(matrix))
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        startCol--;
                        matrix[startRow, startCol] = 'V';
                        rods++;
                        continue;
                    }

                    holes = MatrixMovement(matrix, holes);
                }
                else if ((!IsValidRow(startRow - 1, size) || !IsValidRow(startRow + 1, size))
                    || (!IsValidCol(startCol - 1, size) || !IsValidCol(startCol + 1, size)))
                {
                    if (FirstMove(ref firstMove, matrix))
                    {
                        holes++;
                    }
                }
            }

            Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rods} rod(s).");
            PrintMatrix(matrix);
        }

        private static int MatrixMovement(char[,] matrix, int holes)
        {
            if (matrix[startRow, startCol] == 'C')
            {
                matrix[startRow, startCol] = 'E';
                holes++;
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
                PrintMatrix(matrix);
                Environment.Exit(0);
            }
            else if (matrix[startRow, startCol] == '*')
            {
                matrix[startRow, startCol] = 'V';
                Console.WriteLine($"The wall is already destroyed at position [{startRow}, {startCol}]!");
            }
            else if (matrix[startRow, startCol] == '-')
            {
                matrix[startRow, startCol] = 'V';
                holes++;
            }

            return holes;
        }

        private static bool FirstMove(ref int firstMove, char[,] matrix)
        {
            if (firstMove == 1)
            {

                firstMove++;
                return true;
            }

            return false;
        }
        private static void MatrixFill(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'V')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }
        private static bool IsValidRow(int row, int size) => row >= 0 && row < size;
        private static bool IsValidCol(int col, int size) => col >= 0 && col < size;
        private static bool IsThereRod(char[,] matrix) => matrix[startRow, startCol] == 'R';
        private static void PrintMatrix(char[,] matrix)
        {
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
