using System;
using System.Linq;

namespace P._02_TruffleHunter
{
    public class StartUp
    {
        private const char BlackTruffleSymbol = 'B';
        private const char WhiteTruffleSymbol = 'W';
        private const char SummerTruffleSymbol = 'S';
        private const char DefaultSymbol = '-';

        private static int blackTruffleCounter = 0;
        private static int whiteTruffleCounter = 0;
        private static int summerTruffleCounter = 0;
        private static int eatenTruffles = 0;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            FillMatrix(matrix);

            string input;
            while ((input = Console.ReadLine()) != "Stop the hunt")
            {
                var tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);

                if (command == "Collect")
                {
                    if (!IsValidRow(row, size) && !IsValidCol(col, size))
                    {
                        continue;
                    }

                    if (matrix[row, col] == BlackTruffleSymbol)
                    {
                        blackTruffleCounter++;
                    }
                    else if (matrix[row, col] == WhiteTruffleSymbol)
                    {
                        whiteTruffleCounter++;
                    }
                    else if (matrix[row, col] == SummerTruffleSymbol)
                    {
                        summerTruffleCounter++;
                    }

                    matrix[row, col] = DefaultSymbol;
                }
                else if (command == "Wild_Boar")
                {
                    string direction = tokens[3];

                    if (direction == "up")
                    {
                        while (IsValidRow(row, size))
                        {
                            if (HasTruffles(row, col, matrix))
                            {
                                eatenTruffles++;
                            }

                            row -= 2;
                        }
                    }
                    else if (direction == "down")
                    {
                        while (IsValidRow(row, size))
                        {
                            if (HasTruffles(row, col, matrix))
                            {
                                eatenTruffles++;
                            }

                            row += 2;
                        }
                    }
                    else if (direction == "left")
                    {
                        while (IsValidCol(col, size))
                        {
                            if (HasTruffles(row, col, matrix))
                            {
                                eatenTruffles++;
                            }

                            col -= 2;
                        }
                    }
                    else if (direction == "right")
                    {
                        while (IsValidCol(col, size))
                        {
                            if (HasTruffles(row, col, matrix))
                            {
                                eatenTruffles++;
                            }

                            col += 2;
                        }
                    }
                }
            }

            Console.WriteLine($"Peter manages to harvest {blackTruffleCounter} black, {summerTruffleCounter} summer, and {whiteTruffleCounter} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenTruffles} truffles.");
            PrintMatrix(matrix);
        }

        static bool HasTruffles(int row, int col, char[,] matrix)
        {
            if (matrix[row, col] == BlackTruffleSymbol
                || matrix[row, col] == WhiteTruffleSymbol
                || matrix[row, col] == SummerTruffleSymbol)
            {
                matrix[row, col] = DefaultSymbol;

                return true;
            }

            return false;
        }

        static void PrintMatrix(char[,] matrix)
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

        static bool IsValidRow(int row, int size) => row >= 0 && row < size;

        static bool IsValidCol(int col, int size) => col >= 0 && col < size;

        static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] matrixData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixData[col];
                }
            }
        }
    }
}
