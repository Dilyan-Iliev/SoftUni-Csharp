using System;
using System.Linq;

namespace P._06_JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggedArr = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] fillingArray = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jaggedArr[row] = new double[fillingArray.Length];

                //или само jaggedArr[row] = fillingArray без долния вложен for loop

                for (int col = 0; col < fillingArray.Length; col++)
                {
                    jaggedArr[row][col] = fillingArray[col];
                }
            }

            for (int row = 0; row < jaggedArr.Length - 1; row++)
            {
                if (jaggedArr[row].Length == jaggedArr[row + 1].Length)
                {
                    for (int currRow = row; currRow <= row + 1; currRow++) //за да обходя и долния ред
                    {
                        for (int col = 0; col < jaggedArr[currRow].Length; col++)
                        {
                            jaggedArr[currRow][col] *= 2;
                            // or to think of jaggedArr[currRow].Select(x => x * 2);
                        }
                    }
                }
                else
                {
                    for (int currRow = row; currRow <= row + 1; currRow++) //за да обходя и долния ред
                    {
                        for (int col = 0; col < jaggedArr[currRow].Length; col++)
                        {
                            jaggedArr[currRow][col] /= 2;
                           //or to think of jaggedArr[currRow].Select(x => x / 2);
                        }
                    }
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string currentCmd = cmdArgs[0];
                int rowToManipulate = int.Parse(cmdArgs[1]);
                int colToManipulate = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                bool check;

                if (currentCmd == "Add")
                {
                    check = CheckForValidIndices(jaggedArr, rowToManipulate, colToManipulate);

                    if (!check)
                    {
                        continue;
                    }
                    jaggedArr[rowToManipulate][colToManipulate] += value;

                }
                else if (currentCmd == "Subtract")
                {
                    check = CheckForValidIndices(jaggedArr, rowToManipulate, colToManipulate);

                    if (!check)
                    {
                        continue;
                    }
                    jaggedArr[rowToManipulate][colToManipulate] -= value;
                }
            }
            PrintOutput(jaggedArr);
        }

        static void PrintOutput(double[][] jaggedArr)
        {
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    Console.Write(jaggedArr[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
        static bool CheckForValidIndices(double[][] jagged, int row, int col)
        {
            if (row < 0 || row >= jagged.Length
                || col < 0 || col >= jagged[row].Length)
            {
                return false;
            }
            return true;
        }
    }
}
