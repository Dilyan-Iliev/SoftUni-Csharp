using System;

namespace P._02_Snake
{
    internal class Program
    {
        public static int snakeStartRow = 0;
        public static int snakeStartCol = 0;
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];

            MatrixFill(matrix);

            int foodEaten = 0;

            while (true)
            {
                string direction = Console.ReadLine();

                if (direction == "up")
                {
                    matrix[snakeStartRow, snakeStartCol] = '.';
                    snakeStartRow--;

                    if (snakeStartRow >= 0)
                    {
                        SnakeMoves(matrix, ref foodEaten);
                        matrix[snakeStartRow, snakeStartCol] = 'S';
                    }
                    else
                    {
                        Console.WriteLine("Game over!");
                        Console.WriteLine($"Food eaten: {foodEaten}");
                        break;
                    }
                }
                else if (direction == "down")
                {
                    matrix[snakeStartRow, snakeStartCol] = '.';
                    snakeStartRow++;

                    if (snakeStartRow < matrixSize)
                    {
                        SnakeMoves(matrix, ref foodEaten);
                        matrix[snakeStartRow, snakeStartCol] = 'S';
                    }
                    else
                    {
                        Console.WriteLine("Game over!");
                        Console.WriteLine($"Food eaten: {foodEaten}");
                        break;
                    }
                }
                else if (direction == "left")
                {
                    matrix[snakeStartRow, snakeStartCol] = '.';
                    snakeStartCol--;

                    if (snakeStartCol >= 0)
                    {
                        SnakeMoves(matrix, ref foodEaten);
                        matrix[snakeStartRow, snakeStartCol] = 'S';
                    }
                    else
                    {
                        Console.WriteLine("Game over!");
                        Console.WriteLine($"Food eaten: {foodEaten}");
                        break;
                    }
                }
                else if (direction == "right")
                {
                    matrix[snakeStartRow, snakeStartCol] = '.';
                    snakeStartCol++;

                    if (snakeStartCol < matrixSize)
                    {
                        SnakeMoves(matrix, ref foodEaten);
                        matrix[snakeStartRow, snakeStartCol] = 'S';
                    }
                    else
                    {
                        Console.WriteLine("Game over!");
                        Console.WriteLine($"Food eaten: {foodEaten}");
                        break;
                    }
                }

                if (foodEaten == 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    Console.WriteLine($"Food eaten: {foodEaten}");
                    break;
                }
            }

            PrintOutput(matrix);
        }

        static void SnakeMoves(char[,] matrix, ref int foodEaten)
        {
            if (matrix[snakeStartRow, snakeStartCol] == '*')
            {
                matrix[snakeStartRow, snakeStartCol] = '.';
                foodEaten++;
            }
            else if (matrix[snakeStartRow, snakeStartCol] == 'B')
            {
                matrix[snakeStartRow, snakeStartCol] = '.';

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            snakeStartRow = row;
                            snakeStartCol = col;
                        }
                    }
                }
            }
        }

        static void PrintOutput(char[,] matrix)
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

        static void MatrixFill(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string matrixContent = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixContent[col];

                    if (matrix[row, col] == 'S')
                    {
                        snakeStartRow = row;
                        snakeStartCol = col;
                    }
                }
            }
        }
    }
}
