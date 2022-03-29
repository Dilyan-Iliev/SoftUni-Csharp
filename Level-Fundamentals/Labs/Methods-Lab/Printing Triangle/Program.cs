using System;

namespace Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintTriangle(n);
            PringReversedTriangle(n);
        }

        static void PrintTriangle(int number)
        {
            for (int row = 1; row <= number; row++)
            {
                for (int column = 1; column <= row; column++)
                {
                    Console.Write(column + " ");
                }
                Console.WriteLine();
            } //вложеният цикъл може да се направи в самостоятелен метод, който да се използва и да улесни кода
            //private static void NestedLoopMethod(int row)
            //{
            //    for (int column = 1; column <= row; column++)
            //    {
            //        Console.Write(column + " ");
            //    }
            //    Console.WriteLine();
            //}
        }

        static void PringReversedTriangle(int number)
        {
            for (int row = number - 1; row >= 0; row--)
            {
                for (int column = 1; column <= row; column++)
                {
                    Console.Write(column + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
