using System;
using System.Linq;

namespace P._04_Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            string[][] jaggedArr = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                string[] matrixData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                jaggedArr[row] = new string[matrixData.Length];

                for (int col = 0; col < matrixData.Length; col++)
                {
                    jaggedArr[row][col] = matrixData[col];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[0] != "swap") //in case input is without swap Cmd
                {
                    PrintError();
                    continue;
                }

                if (cmdArgs.Length < 5 || cmdArgs.Length > 5) //in case i have fewer or more
                                                              //elements in the input
                {
                    PrintError();
                    continue;
                }

                //valid inputs
                string currentCmd = cmdArgs[0];
                int row1 = int.Parse(cmdArgs[1]);
                int col1 = int.Parse(cmdArgs[2]);
                int row2 = int.Parse(cmdArgs[3]);
                int col2 = int.Parse(cmdArgs[4]);

                if (row1 < 0 || row1 >= jaggedArr.Length
                    || row2 < 0 || row2 >= jaggedArr.Length
                    || col1 < 0 || col1 >= jaggedArr[row1].Length
                        || col2 < 0 || col2 >= jaggedArr[row2].Length) //in case indices are invalid
                {
                    PrintError();
                    continue;
                }

                string currentElement = jaggedArr[row1][col1];
                jaggedArr[row1][col1] = jaggedArr[row2][col2];
                jaggedArr[row2][col2] = currentElement;

                PrintJagged(jaggedArr);
            }
        }

        static void PrintError()
        {
            Console.WriteLine("Invalid input!");
        }

        static string[][] PrintJagged(string[][] jaggedArr)
        {
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    Console.Write(jaggedArr[row][col] + " ");
                }
                Console.WriteLine();
            }

            return jaggedArr;
        }
    }
}


