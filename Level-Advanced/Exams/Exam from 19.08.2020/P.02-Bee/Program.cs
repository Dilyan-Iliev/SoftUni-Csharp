using System;

namespace P._02_Bee
{
    internal class Program
    {
        public static int beeStartRow = 0;
        public static int beeStartCol = 0;
        public static int minFlowersNeeded = 5;
        public static int flowersCollected = 0;
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];
            FillMatrix(matrix);

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "left")
                {
                    matrix[beeStartRow, beeStartCol] = '.';
                    beeStartCol--;

                    if (beeStartCol >= 0)
                    {
                        if (matrix[beeStartRow, beeStartCol] == 'f')
                        {
                            flowersCollected++;
                        }
                        else if (matrix[beeStartRow, beeStartCol] == 'O')
                        {
                            matrix[beeStartRow, beeStartCol] = '.';
                            beeStartCol--;

                            if (beeStartCol < 0)
                            {
                                EndProgram();
                                break;
                            }

                            if (matrix[beeStartRow, beeStartCol] == 'f')
                            {
                                flowersCollected++;
                            }
                        }

                        matrix[beeStartRow, beeStartCol] = 'B';
                    }
                    else
                    {
                        EndProgram();
                        break;
                    }
                }
                else if (input == "right")
                {
                    matrix[beeStartRow, beeStartCol] = '.';
                    beeStartCol++;

                    if (beeStartCol < matrixSize)
                    {
                        if (matrix[beeStartRow, beeStartCol] == 'f')
                        {
                            flowersCollected++;
                        }
                        else if (matrix[beeStartRow, beeStartCol] == 'O')
                        {
                            matrix[beeStartRow, beeStartCol] = '.';
                            beeStartCol++;

                            if (beeStartCol >= matrixSize)
                            {
                                EndProgram();
                                break;
                            }

                            if (matrix[beeStartRow, beeStartCol] == 'f')
                            {
                                flowersCollected++;
                            }
                        }

                        matrix[beeStartRow, beeStartCol] = 'B';
                    }
                    else
                    {
                        EndProgram();
                        break;
                    }
                }
                else if (input == "up")
                {
                    matrix[beeStartRow, beeStartCol] = '.';
                    beeStartRow--;

                    if (beeStartRow >= 0)
                    {
                        if (matrix[beeStartRow, beeStartCol] == 'f')
                        {
                            flowersCollected++;
                        }
                        else if (matrix[beeStartRow, beeStartCol] == 'O')
                        {
                            matrix[beeStartRow, beeStartCol] = '.';
                            beeStartRow--;

                            if (beeStartCol < 0)
                            {
                                EndProgram();
                                break;
                            }

                            if (matrix[beeStartRow, beeStartCol] == 'f')
                            {
                                flowersCollected++;
                            }
                        }

                        matrix[beeStartRow, beeStartCol] = 'B';
                    }
                    else
                    {
                        EndProgram();
                        break;
                    }
                }
                else if (input == "down")
                {
                    matrix[beeStartRow, beeStartCol] = '.';
                    beeStartRow++;

                    if (beeStartRow < matrixSize)
                    {
                        if (matrix[beeStartRow, beeStartCol] == 'f')
                        {
                            flowersCollected++;
                        }
                        else if (matrix[beeStartRow, beeStartCol] == 'O')
                        {
                            matrix[beeStartRow, beeStartCol] = '.';
                            beeStartRow++;

                            if (beeStartCol >= matrixSize)
                            {
                                EndProgram();
                                break;
                            }

                            if (matrix[beeStartRow, beeStartCol] == 'f')
                            {
                                flowersCollected++;
                            }
                        }

                        matrix[beeStartRow, beeStartCol] = 'B';
                    }
                    else
                    {
                        EndProgram();
                        break;
                    }
                }
            }

            PrintOutput(matrix);
        }

        static void PrintOutput(char[,] matrix)
        {
            if (flowersCollected >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowersCollected} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {minFlowersNeeded - flowersCollected} flowers more");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string matrixContent = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixContent[col];

                    if (matrix[row, col] == 'B')
                    {
                        beeStartRow = row;
                        beeStartCol = col;
                    }
                }
            }
        }

        static void EndProgram()
        {
            Console.WriteLine("The bee got lost!");
        }
    }
}
