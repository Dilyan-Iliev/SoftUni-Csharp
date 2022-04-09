using System;
using System.Linq;

namespace SumMatrixElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tableDimensions = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = tableDimensions[0];
            int cols = tableDimensions[1];

            int[,] table = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] tableData = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    table[row, col] = tableData[col]; //всеки път на съответния ред и съответната колона
                    //добавяме елемент от tableData масива, за да напълня table матрицата
                }
            }

            int sum = 0;

            for (int row = 0; row < table.GetLength(0); row++)
            {
                for (int col = 0; col < table.GetLength(1); col++)
                {
                    int currentElement = table[row, col];
                    sum += currentElement;
                }
            }
            Console.WriteLine(table.GetLength(0));
            Console.WriteLine(table.GetLength(1));
            Console.WriteLine(sum);


            //or partly with jagged arrays

            //int[] tableDimensions = Console.ReadLine()
            //    .Split(", ")
            //    .Select(int.Parse)
            //    .ToArray();

            //int rows = tableDimensions[0];
            //int cols = tableDimensions[1];

            //int[][] jagged = new int[rows][];

            //for (int row = 0; row < rows; row++)
            //{
            //    //int[] arr = new int[cols];
            //   int[] arr = Console.ReadLine()
            //        .Split(",")
            //        .Select(int.Parse).ToArray();

            //    jagged[row] = new int[arr.Length];

            //    for (int col = 0; col < arr.Length; col++) // or jagged[row].Length
            //    {
            //        jagged[row][col] = arr[col]; //съответната колона от всеки ред(който е масив) 
            //        // е равна на съответния елемент от arr[]
            //    }
            //}

            //int sum = 0;

            //for (int row = 0; row < jagged.Length; row++)
            //{
            //    for (int col = 0; col < jagged[row].Length; col++)
            //    {
            //        int currentElement = jagged[row][col];
            //        sum += currentElement;
            //    }
            //}
            ////мога да изкарам сумата, но ?? как да изкарам броя редове и колони
            //Console.WriteLine(rows);
            //Console.WriteLine(cols);
            //Console.WriteLine(sum);
        }
    }
}
