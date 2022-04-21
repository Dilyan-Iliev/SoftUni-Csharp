using System;
using System.Linq;
using System.Collections.Generic;

namespace P._03_Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<IEnumerable<int>, int> func = FindSmallestNumber;
            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            int minNumber = func(numbers);
            Console.WriteLine(minNumber);
        }

        static int FindSmallestNumber(IEnumerable<int> numbers)
        //IEnumerable makes it universal for all collections
        {
            int number = int.MaxValue;

            foreach (var item in numbers)
            {
                if (item < number)
                {
                    number = item;
                }
            }
            return number;
        }
    }
}
