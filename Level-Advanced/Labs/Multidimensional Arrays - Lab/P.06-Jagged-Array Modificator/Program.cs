using System;
using System.Linq;
using System.Collections.Generic;

namespace P._06_Jagged_Array_Modificator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            int[][] jaggedArr = new int[numberOfRows][];

            //fill the jaggedArray
            for (int row = 0; row < jaggedArr.Length; row++) //length is numberOfRows
            {
                int[] array = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                jaggedArr[row] = new int[array.Length];

                for (int col = 0; col < jaggedArr[row].Length; col++) //lengnth is array.Length
                {
                    jaggedArr[row][col] = array[col];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split();

                string currentCmd = cmdArgs[0];
                int rowToManipulate = int.Parse(cmdArgs[1]);
                int colToManipulate = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (rowToManipulate < 0 || rowToManipulate >= jaggedArr.Length
                    || colToManipulate < 0 || colToManipulate >= jaggedArr[rowToManipulate].Length)
                //1во проверявам дали иска да вкарам елементи на ред, който е по-малък или по-голям 
                //от дължината на основния масив;
                //след това проверявам дали изобщо има такъв елемент на съответния ред
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (currentCmd == "Add")
                {
                    jaggedArr[rowToManipulate][colToManipulate] += value;
                }
                else if (currentCmd == "Subtract")
                {
                    jaggedArr[rowToManipulate][colToManipulate] -= value;
                }
            }

            for (int row = 0; row < jaggedArr.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArr[row]));
            }


            //or with array of lists:


            //int numberOfRows = int.Parse(Console.ReadLine());

            //List<int>[] jagged = new List<int>[numberOfRows];

            //for (int row = 0; row < jagged.Length; row++)
            //{
            //    List<int> listElements = Console.ReadLine()
            //        .Split()
            //        .Select(int.Parse)
            //        .ToList();

            //    jagged[row] = new List<int>();

            //    for (int col = 0; col < listElements.Count; col++)
            //    {
            //        jagged[row].Add(listElements[col]);
            //    }
            //}

            //string command;
            //while ((command = Console.ReadLine()) != "END")
            //{
            //    string[] cmdArgs = command.Split();
            //    string currentCmd = cmdArgs[0];
            //    int rowToManipulate = int.Parse(cmdArgs[1]);
            //    int colToManipulate = int.Parse(cmdArgs[2]);
            //    int value = int.Parse(cmdArgs[3]);

            //    if (rowToManipulate < 0 || rowToManipulate >= jagged.Length
            //        || colToManipulate < 0 || colToManipulate >= jagged[rowToManipulate].Count)
            //    {
            //        Console.WriteLine("Invalid coordinates");
            //        continue;
            //    }

            //    if (currentCmd == "Add")
            //    {
            //        jagged[rowToManipulate][colToManipulate] += value;
            //    }
            //    else if (currentCmd == "Subtract")
            //    {
            //        jagged[rowToManipulate][colToManipulate] -= value;
            //    }
            //}

            //for (int row = 0; row < jagged.Length; row++)
            //{
            //    Console.WriteLine(string.Join(" ", jagged[row]));
            //}
        }
    }
}
