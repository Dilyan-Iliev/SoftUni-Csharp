using System;

namespace P._02_Armory
{
    public class StartUp
    {
        private static int startRow = 0;
        private static int startCol = 0;
        private const char PlayerSymbol = 'A';
        private const char MirrorSymbol = 'M';
        private const char DefaultEmptySymbol = '-';
        private static long collectedGold = 0;
        private const int NeededGold = 65;
        private const string OutOfRangeMessage = "I do not need more swords!";
        private const string EnoughGoldMessage = "Very nice swords, I will come back for more!";

        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            FillMatrix(matrix);

            while (true)
            {
                string direction = Console.ReadLine();

                if (direction == "up")
                {
                    matrix[startRow, startCol] = DefaultEmptySymbol;

                    startRow--;

                    if (startRow < 0)
                    {
                        OutOfRange();
                        break;
                    }

                    NavigateInMatrix(matrix);
                }
                else if (direction == "down")
                {
                    matrix[startRow, startCol] = DefaultEmptySymbol;

                    startRow++;

                    if (startRow >= size)
                    {
                        OutOfRange();
                        break;
                    }

                    NavigateInMatrix(matrix);
                }
                else if (direction == "left")
                {
                    matrix[startRow, startCol] = DefaultEmptySymbol;

                    startCol--;

                    if (startCol < 0)
                    {
                        OutOfRange();
                        break;
                    }

                    NavigateInMatrix(matrix);
                }
                else if (direction == "right")
                {
                    matrix[startRow, startCol] = DefaultEmptySymbol;

                    startCol++;

                    if (startCol >= size)
                    {
                        OutOfRange();
                        break;
                    }

                    NavigateInMatrix(matrix);
                }

                if (collectedGold >= NeededGold)
                {
                    EnoughGold();
                    break;
                }
            }

            PrintOutput(matrix);
        }

        private static void PrintOutput(char[,] matrix)
        {
            Console.WriteLine($"The king paid {collectedGold} gold coins.");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void OutOfRange()
        {
            Console.WriteLine(OutOfRangeMessage);
        }

        static void EnoughGold()
        {
            Console.WriteLine(EnoughGoldMessage);
        }

        static void NavigateInMatrix(char[,] matrix)
        {
            if (char.IsDigit(matrix[startRow, startCol]))
            {
                int goldToAdd = int.Parse(matrix[startRow, startCol].ToString());
                collectedGold += goldToAdd;

                matrix[startRow, startCol] = DefaultEmptySymbol;
            }
            else if (matrix[startRow, startCol] == MirrorSymbol)
            {
                matrix[startRow, startCol] = DefaultEmptySymbol;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == MirrorSymbol)
                        {
                            startRow = row;
                            startCol = col;
                        }
                    }
                }
            }

            matrix[startRow, startCol] = PlayerSymbol;
        }

        static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string matrixData = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixData[col];

                    if (matrix[row, col] == PlayerSymbol)
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }
    }
}
