using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P._07_CustomOperator
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var evenFiltered = numbers.Where(x => x % 2 == 0).OrderBy(x => x).ToArray();
            var oddFilter = numbers.Where(x => x % 2 != 0).OrderBy(x => x).ToArray();

            var mergedCollection = evenFiltered.Concat(oddFilter).ToArray();

            Console.WriteLine(string.Join(" ", mergedCollection));
        }
    }
}
