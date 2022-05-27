using System;

namespace P._02_Selling
{
    internal class Program
    {
        public static int startRow = 0;
        public static int startCol = 0;

        public static int minDollarsNeeded = 50;
        public static int dollarsCollected = 0;
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];

            MatrixFill(matrix);

            while (true)
            {
                string direction = Console.ReadLine();

                if (direction == "up")
                {
                    matrix[startRow, startCol] = '-';
                    startRow--;

                    if (startRow >= 0)
                    {
                        MovementInMatrix(matrix);
                        matrix[startRow, startCol] = 'S';
                    }
                    else
                    {
                        OutOfRangeMessage();
                        break;
                    }
                }
                else if (direction == "down")
                {
                    matrix[startRow, startCol] = '-';
                    startRow++;

                    if (startRow < matrixSize)
                    {
                        MovementInMatrix(matrix);
                        matrix[startRow, startCol] = 'S';
                    }
                    else
                    {
                        OutOfRangeMessage();
                        break;
                    }
                }
                else if (direction == "left")
                {
                    matrix[startRow, startCol] = '-';
                    startCol--;

                    if (startCol >= 0)
                    {
                        MovementInMatrix(matrix);
                        matrix[startRow, startCol] = 'S';
                    }
                    else
                    {
                        OutOfRangeMessage();
                        break;
                    }
                }
                else if (direction == "right")
                {
                    matrix[startRow, startCol] = '-';
                    startCol++;

                    if (startCol < matrixSize)
                    {
                        MovementInMatrix(matrix);
                        matrix[startRow, startCol] = 'S';
                    }
                    else
                    {
                        OutOfRangeMessage();
                        break;
                    }
                }

                if (dollarsCollected >= 50)
                {
                    break;
                }
            }

            PrintOutput(matrix);
        }

        static void PrintOutput(char[,] matrix)
        {
            if (dollarsCollected >= minDollarsNeeded)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {dollarsCollected}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        static void OutOfRangeMessage()
        {
            Console.WriteLine("Bad news, you are out of the bakery.");
        }
        static void MovementInMatrix(char[,] matrix)
        {
            if (char.IsDigit(matrix[startRow, startCol]))
            {
                dollarsCollected += int.Parse(matrix[startRow, startCol].ToString());
            }
            else if (matrix[startRow, startCol] == 'O')
            {
                matrix[startRow, startCol] = '-';

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'O')
                        {
                            startRow = row;
                            startCol = col;
                        }
                    }
                }
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
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }
    }
}
