using System;
using System.Linq;

namespace P._07_PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            long[][] pascal = new long[numberOfRows][];

            for (int i = 0; i < numberOfRows; i++)
            {
                pascal[i] = new long[i + 1]; //всеки масив ще е с един елемент повече от предходния
            }


            for (int row = 0; row < numberOfRows; row++)
            {
                pascal[row][0] = 1; //1я елемент винаги ще е единица
                pascal[row][pascal[row].Length - 1] = 1; //последния елемент винаги ще е единица

                for (int col = 1; col < pascal[row].Length - 1; col++)
                {
                    pascal[row][col] = pascal[row - 1][col - 1] + pascal[row - 1][col];
                }
            }

            for (int row = 0; row < pascal.Length; row++)
            {
                Console.WriteLine(string.Join(" ", pascal[row]));
            }
        }
    }
}
