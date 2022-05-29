using System;
using System.Linq;

namespace P._02_Warships
{
    internal class Program
    {
        public static int playerOneInitialShips = 0;
        public static int playerTwoInitialShips = 0;

        public static int playerOneHitShips = 0;
        public static int playerTwoHitShips = 0;
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[] attacksCoordinates = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[matrixSize, matrixSize];
            MatrixFill(matrix);

            for (int i = 0; i < attacksCoordinates.Length; i += 2)
            {
                int row = attacksCoordinates[i];
                int col = attacksCoordinates[i + 1];

                if (row < 0 || col >= matrixSize
                               ||
                    row >= matrixSize || col < 0)
                {
                    continue;
                }

                if (matrix[row, col] == '*')
                {
                    continue;
                }

                if (matrix[row, col] == '<')
                {
                    matrix[row, col] = 'X';
                    playerOneHitShips++;
                }
                else if (matrix[row, col] == '>')
                {
                    matrix[row, col] = 'X';
                    playerTwoHitShips++;
                }
                else if (matrix[row, col] == '#')
                {
                    matrix[row, col] = 'X';

                    CheckForValidCoordinatesAroundTheSeaMine(matrixSize, matrix, row, col);
                }

            }

            PrintOutput();
        }

        static void PrintOutput()
        {
            int sunkenShips = playerOneHitShips + playerTwoHitShips;

            if (playerOneHitShips == playerOneInitialShips)
            {
                Console.WriteLine($"Player Two has won the game! {sunkenShips} ships have been sunk in the battle.");
            }
            else if (playerTwoHitShips == playerTwoInitialShips)
            {
                Console.WriteLine($"Player One has won the game! {sunkenShips} ships have been sunk in the battle.");
            }
            else
            {
                int playerOneLeftShips = playerOneInitialShips - playerOneHitShips;
                int playerTwoLeftShips = playerTwoInitialShips - playerTwoHitShips;
                Console.WriteLine($"It's a draw! Player One has {playerOneLeftShips} ships left. Player Two has {playerTwoLeftShips} ships left.");
            }
        }

        static void CheckForValidCoordinatesAroundTheSeaMine(int matrixSize, char[,] matrix, int row, int col)
        {
            if (row + 1 < matrixSize)
            {
                if (matrix[row + 1, col] == '<')
                {
                    playerOneHitShips++;
                }
                else if (matrix[row + 1, col] == '>')
                {
                    playerTwoHitShips++;
                }

                matrix[row + 1, col] = 'X';
            }

            if (row - 1 >= 0)
            {
                if (matrix[row - 1, col] == '<')
                {
                    playerOneHitShips++;
                }
                else if (matrix[row - 1, col] == '>')
                {
                    playerTwoHitShips++;
                }

                matrix[row - 1, col] = 'X';
            }

            if (col - 1 >= 0)
            {
                if (matrix[row, col - 1] == '<')
                {
                    playerOneHitShips++;
                }
                else if (matrix[row, col - 1] == '>')
                {
                    playerTwoHitShips++;
                }

                matrix[row, col - 1] = 'X';
            }

            if (col + 1 < matrixSize)
            {
                if (matrix[row, col + 1] == '<')
                {
                    playerOneHitShips++;
                }
                else if (matrix[row, col + 1] == '>')
                {
                    playerTwoHitShips++;
                }

                matrix[row, col + 1] = 'X';
            }

            if (row + 1 < matrixSize && col + 1 < matrixSize)
            {
                if (matrix[row + 1, col + 1] == '<')
                {
                    playerOneHitShips++;
                }
                else if (matrix[row + 1, col + 1] == '>')
                {
                    playerTwoHitShips++;
                }

                matrix[row + 1, col + 1] = 'X';
            }

            if (row + 1 < matrixSize && col - 1 >= 0)
            {
                if (matrix[row + 1, col - 1] == '<')
                {
                    playerOneHitShips++;
                }
                else if (matrix[row + 1, col - 1] == '>')
                {
                    playerTwoHitShips++;
                }

                matrix[row + 1, col - 1] = 'X';
            }

            if (row - 1 >= 0 && col + 1 < matrixSize)
            {
                if (matrix[row - 1, col + 1] == '<')
                {
                    playerOneHitShips++;
                }
                else if (matrix[row - 1, col + 1] == '>')
                {
                    playerTwoHitShips++;
                }

                matrix[row - 1, col + 1] = 'X';
            }

            if (row - 1 >= 0 && col - 1 >= 0)
            {
                if (matrix[row - 1, col - 1] == '<')
                {
                    playerOneHitShips++;
                }
                else if (matrix[row - 1, col - 1] == '>')
                {
                    playerTwoHitShips++;
                }

                matrix[row - 1, col - 1] = 'X';
            }
        }

        static void MatrixFill(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] matrixContent = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixContent[col];

                    if (matrix[row, col] == '<')
                    {
                        playerOneInitialShips++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        playerTwoInitialShips++;
                    }
                }
            }
        }
    }
}
