using System;
using System.Linq;

namespace P._09_Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            //filed is always a square

            char[,] field = new char[fieldSize, fieldSize];

            string[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //example: up right right up right

            int startRow = 0;
            int startCol = 0;

            int coalCounter = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] fieldData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = fieldData[col];

                    if (field[row, col].Equals('s')) //set the start position of the miner
                    {
                        startRow = row;
                        startCol = col;
                    }

                    if (field[row, col].Equals('c')) //set the full amount of coals on the field
                    {
                        coalCounter++;
                    }
                }
            }

            int foundCoalsCounter = 0;

            //int leftCoalsColIndex = 0; //for the case - out of commands and n coals left
            //int leftCoalsRowIndex = 0; //for the case - out of commands and n coals left

            int endRow = 0;
            int endCol = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                string currentCmd = commands[i];
                bool hasToBreak = false;

                if (currentCmd.Equals("up"))
                {
                    startRow--;

                    if (startRow < 0)
                    {
                        startRow++;
                        continue;
                    }

                    FieldBounderies(field, startRow, startCol, ref foundCoalsCounter,
                        coalCounter, endRow, endCol, ref hasToBreak);
                }
                else if (currentCmd.Equals("down"))
                {
                    startRow++;

                    if (startRow >= field.GetLength(0))
                    {
                        startRow--;
                        continue;
                    }

                    FieldBounderies(field, startRow, startCol, ref foundCoalsCounter,
                        coalCounter, endRow, endCol, ref hasToBreak);
                }
                else if (currentCmd.Equals("left"))
                {
                    startCol--;

                    if (startCol < 0)
                    {
                        startCol++;
                        continue;
                    }

                    FieldBounderies(field, startRow, startCol, ref foundCoalsCounter,
                        coalCounter, endRow, endCol, ref hasToBreak);
                }
                else if (currentCmd.Equals("right"))
                {
                    startCol++;

                    if (startCol >= field.GetLength(1))
                    {
                        startCol--;
                        continue;
                    }

                    FieldBounderies(field, startRow, startCol, ref foundCoalsCounter,
                        coalCounter, endRow, endCol, ref hasToBreak);
                }

                if (hasToBreak)
                {
                    return;
                }

                endRow = startRow;
                endCol = startCol;
            }

            int coalsLeft = coalCounter - foundCoalsCounter;
            Console.WriteLine($"{coalsLeft} coals left. ({endRow}, {endCol})");
        }

        static char[,] FieldBounderies(char[,] field, int startRow, int startCol,
            ref int foundCoalsCounter, int coalCounter, int endRow, int endCol, ref bool hasToBreak)
        {
            if (field[startRow, startCol].Equals('c'))
            {
                foundCoalsCounter++;
                field[startRow, startCol] = '*';

                if (foundCoalsCounter == coalCounter)
                {
                    endRow = startRow;
                    endCol = startCol;
                    Console.WriteLine($"You collected all coals! ({endRow}, {endCol})");
                    hasToBreak = true;
                }
            }
            else if (field[startRow, startCol].Equals('e'))
            {
                endRow = startRow;
                endCol = startCol;
                Console.WriteLine($"Game over! ({endRow}, {endCol})");
                hasToBreak = true;
            }

            return field;
        }

        //static void Main(string[] args)
        //{
        //    int fieldSize = int.Parse(Console.ReadLine());
        //    //filed is always a square

        //    char[,] field = new char[fieldSize, fieldSize];

        //    string[] commands = Console.ReadLine()
        //        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        //    //example: up right right up right

        //    int startRow = 0;
        //    int startCol = 0;

        //    int coalCounter = 0;

        //    for (int row = 0; row < field.GetLength(0); row++)
        //    {
        //        char[] fieldData = Console.ReadLine()
        //            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        //            .Select(char.Parse)
        //            .ToArray();

        //        for (int col = 0; col < field.GetLength(1); col++)
        //        {
        //            field[row, col] = fieldData[col];

        //            if (field[row, col].Equals('s')) //set the start position of the miner
        //            {
        //                startRow = row;
        //                startCol = col;
        //            }

        //            if (field[row, col].Equals('c')) //set the full amount of coals on the field
        //            {
        //                coalCounter++;
        //            }
        //        }
        //    }

        //    int foundCoalsCounter = 0;

        //    int leftCoalsRowIndex = 0; //for the case - out of commands and n coals left
        //    int leftCoalsColIndex = 0; //for the case - out of commands and n coals left

        //    int endRow = 0;
        //    int endCol = 0;

        //    for (int i = 0; i < commands.Length; i++)
        //    {
        //        string currentCmd = commands[i];

        //        if (currentCmd.Equals("up"))
        //        {
        //            startRow--;

        //            if (startRow < 0)
        //            {
        //                startRow++;
        //                continue;
        //            }

        //            if (field[startRow, startCol].Equals('c'))
        //            {
        //                foundCoalsCounter++;
        //                field[startRow, startCol] = '*';

        //                if (foundCoalsCounter == coalCounter)
        //                {
        //                    endRow = startRow;
        //                    endCol = startCol;
        //                    Console.WriteLine($"You collected all coals! ({endRow}, {endCol})");
        //                    return;
        //                }
        //            }
        //            else if (field[startRow, startCol].Equals('e'))
        //            {
        //                endRow = startRow;
        //                endCol = startCol;
        //                Console.WriteLine($"Game over! ({endRow}, {endCol})");
        //                return;
        //            }
        //        }
        //        else if (currentCmd.Equals("down"))
        //        {
        //            startRow++;

        //            if (startRow >= field.GetLength(0))
        //            {
        //                startRow--;
        //                continue;
        //            }

        //            if (field[startRow, startCol].Equals('c'))
        //            {
        //                foundCoalsCounter++;
        //                field[startRow, startCol] = '*';

        //                if (foundCoalsCounter == coalCounter)
        //                {
        //                    endRow = startRow;
        //                    endCol = startCol;
        //                    Console.WriteLine($"You collected all coals! ({endRow}, {endCol})");
        //                    return;
        //                }
        //            }
        //            else if (field[startRow, startCol].Equals('e'))
        //            {
        //                endRow = startRow;
        //                endCol = startCol;
        //                Console.WriteLine($"Game over! ({endRow}, {endCol})");
        //                return;
        //            }
        //        }
        //        else if (currentCmd.Equals("left"))
        //        {
        //            startCol--;

        //            if (startCol < 0)
        //            {
        //                startCol++;
        //                continue;
        //            }

        //            if (field[startRow, startCol].Equals('c'))
        //            {
        //                foundCoalsCounter++;
        //                field[startRow, startCol] = '*';

        //                if (foundCoalsCounter == coalCounter)
        //                {
        //                    endRow = startRow;
        //                    endCol = startCol;
        //                    Console.WriteLine($"You collected all coals! ({endRow}, {endCol})");
        //                    return;
        //                }
        //            }
        //            else if (field[startRow, startCol].Equals('e'))
        //            {
        //                endRow = startRow;
        //                endCol = startCol;
        //                Console.WriteLine($"Game over! ({endRow}, {endCol})");
        //                return;
        //            }
        //        }
        //        else if (currentCmd.Equals("right"))
        //        {
        //            startCol++;

        //            if (startCol >= field.GetLength(1))
        //            {
        //                startCol--;
        //                continue;
        //            }

        //            if (field[startRow, startCol].Equals('c'))
        //            {
        //                foundCoalsCounter++;
        //                field[startRow, startCol] = '*';

        //                if (foundCoalsCounter == coalCounter)
        //                {
        //                    endRow = startRow;
        //                    endCol = startCol;
        //                    Console.WriteLine($"You collected all coals! ({endRow}, {endCol})");
        //                    return;
        //                }
        //            }
        //            else if (field[startRow, startCol].Equals('e'))
        //            {
        //                endRow = startRow;
        //                endCol = startCol;
        //                Console.WriteLine($"Game over! ({endRow}, {endCol})");
        //                return;
        //            }
        //        }

        //        leftCoalsRowIndex = startRow;
        //        leftCoalsColIndex = startCol;
        //    }
        //    int coalsLeft = coalCounter - foundCoalsCounter;
        //    Console.WriteLine($"{coalsLeft} coals left. ({leftCoalsRowIndex}, {leftCoalsColIndex})");
        //}
    }
}
