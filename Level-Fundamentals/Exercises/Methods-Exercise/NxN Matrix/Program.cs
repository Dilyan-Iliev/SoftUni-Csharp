using System;

namespace NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintMatrixFromNumber(number);
        }

        static void PrintMatrixFromNumber (int number)
        {
            for (int row = 1; row <= number; row++)
            {
                for (int colum = 1; colum <= number; colum++)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
