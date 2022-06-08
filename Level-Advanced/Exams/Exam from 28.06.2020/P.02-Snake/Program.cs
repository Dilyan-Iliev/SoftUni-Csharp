using System;

namespace P._02_Snake
{
    public class Program
    {
        private static int startRow = 0;
        private static int startCol = 0;
        private static readonly char defaultEmptyPosition = '.';
        private static readonly char snakeNewPosition = 'S';
        private static readonly int neededFood = 10;
        private static int foodEeaten = 0;

        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];
            MatrixFill(matrix);


            while (true)
            {
                string direction = Console.ReadLine();

                if (direction == "up")
                {
                    matrix[startRow, startCol] = defaultEmptyPosition;
                    startRow--;

                    if (startRow < 0)
                    {
                        EndGameMessage();
                        break;
                    }

                    NavigateInMatrix(matrix);
                }
                else if (direction == "down")
                {
                    matrix[startRow, startCol] = defaultEmptyPosition;
                    startRow++;

                    if (startRow >= size)
                    {
                        EndGameMessage();
                        break;
                    }

                    NavigateInMatrix(matrix);
                }
                else if (direction == "left")
                {
                    matrix[startRow, startCol] = defaultEmptyPosition;
                    startCol--;

                    if (startCol < 0)
                    {
                        EndGameMessage();
                        break;
                    }

                    NavigateInMatrix(matrix);
                }
                else if (direction == "right")
                {
                    matrix[startRow, startCol] = defaultEmptyPosition;
                    startCol++;

                    if (startCol >= size)
                    {
                        EndGameMessage();
                        break;
                    }

                    NavigateInMatrix(matrix);
                }

                if (CollectedNeededFood())
                {
                    break;
                }
            }

            PrintOutput(matrix);
        }

        static void PrintOutput(char[,] matrix)
        {
            if (foodEeaten >= neededFood)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodEeaten}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static bool CollectedNeededFood() => foodEeaten >= neededFood;
        //{
        //    if (foodEeaten >= neededFood)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        static void NavigateInMatrix(char[,] matrix)
        {
            if (matrix[startRow, startCol] == '*')
            {
                foodEeaten++;
            }
            else if (matrix[startRow, startCol] == 'B')
            {
                matrix[startRow, startCol] = defaultEmptyPosition;
                SearchForSecondBurrow(matrix);
            }

            matrix[startRow, startCol] = snakeNewPosition;
        }

        static void SearchForSecondBurrow(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }

        static void EndGameMessage()
        {
            Console.WriteLine("Game over!");
        }

        static void MatrixFill(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string matrixData = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixData[col];

                    if (matrix[row, col] == 'S')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }
    }
}
