using System;
using System.Linq;

namespace Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double[] numbers = input.Split()
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                //numbers[i] = double.Parse(array[i]);
                Console.WriteLine($"{(decimal)numbers[i]} => {Math.Round((decimal)numbers[i], MidpointRounding.AwayFromZero)}");
            }

            //double[] array1 = Console.ReadLine().Split( ).Select(double.Parse).ToArray();
            //foreach (double num in array1)
            //{
            //    Console.WriteLine($"{(decimal)num} => {Math.Round((decimal)num, MidpointRounding.AwayFromZero)}");
            //}
        }
    }
}
