using System;

namespace P._02_SuperMario
{
    public class StartUp
    {
        private static int startRow = 0;
        private static int startCol = 0;
        static void Main(string[] args)
        {
            int initialLives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            char[][] jagged = new char[rows][]; //rectangular which means i dont know the cols in each row

            JaggedArrayFill(jagged);
            FindStartPosition(jagged);

            while (true)
            {
                string[] coordinates = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries); ;
                string direction = coordinates[0];
                int enemyRow = int.Parse(coordinates[1]);
                int enemyCol = int.Parse(coordinates[2]);

                jagged[enemyRow][enemyCol] = 'B';

                if (direction == "W" && IsValidRow(startRow - 1, rows))
                {
                    jagged[startRow][startCol] = '-';
                    startRow--;

                }
                else if (direction == "S" && IsValidRow(startRow + 1, rows))
                {
                    jagged[startRow][startCol] = '-';
                    startRow++;
                }
                else if (direction == "A" && IsValidCol(startCol - 1, jagged))
                {
                    jagged[startRow][startCol] = '-';
                    startCol--;
                }
                else if (direction == "D" && IsValidCol(startCol + 1, jagged))
                {
                    jagged[startRow][startCol] = '-';
                    startCol++;
                }

                initialLives--;
                if (IsOutOfLives(initialLives))
                {
                    Console.WriteLine(LoseGameMessage());
                    jagged[startRow][startCol] = 'X';
                    break;
                }

                if (jagged[startRow][startCol] == 'B')
                {
                    initialLives -= 2;

                    if (IsOutOfLives(initialLives))
                    {
                        Console.WriteLine(LoseGameMessage());
                        jagged[startRow][startCol] = 'X';
                        break;
                    }
                }
                else if (jagged[startRow][startCol] == 'P')
                {
                    jagged[startRow][startCol] = '-';
                    Console.WriteLine(WinGameMessage(initialLives));
                    break;
                }

                jagged[startRow][startCol] = 'M';
            }

            PrintMatrix(jagged);
        }

        static void FindStartPosition(char[][] jagged)
        {
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    if (jagged[row][col] == 'M')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }

        static void JaggedArrayFill(char[][] jagged)
        {
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();
                jagged[row] = rowData.ToCharArray();
            }
        }

        static bool IsValidRow(int startRow, int rows) => startRow >= 0 && startRow < rows;

        static bool IsValidCol(int startCol, char[][] jagged)
            => startCol >= 0 && startCol < jagged[startRow].Length;

        static bool IsOutOfLives(int lives) => lives <= 0;

        static string LoseGameMessage() => $"Mario died at {startRow};{startCol}.";

        static string WinGameMessage(int lives) => $"Mario has successfully saved the princess! Lives left: {lives}";

        static void PrintMatrix(char[][] jagged)
        {
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                Console.WriteLine(string.Join("", jagged[row]));
            }
        }
    }
}
