using System;
using System.Collections.Generic;
using System.Linq;

namespace P._04_Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string filterWord = Console.ReadLine();

            int lowerBound = numbers[0];
            int upperBound = numbers[1];

            List<int> newNumbers = new List<int>();
            for (int i = lowerBound; i <= upperBound; i++)
            {
                //fill new collection with numbers in the given range
                newNumbers.Add(i);
            }

            if (filterWord == "odd")
            {
                IEnumerable<int> filteredCollection = Filter(newNumbers, x => x % 2 != 0);
                Console.WriteLine(string.Join(" ", filteredCollection));
            }
            else if (filterWord == "even")
            {
                IEnumerable<int> filteredCollection = Filter(newNumbers, x => x % 2 == 0);
                Console.WriteLine(string.Join(" ", filteredCollection));
            }

            //if (filterWord == "odd")
            //{
            //    var filteredNumbers = newNumbers.Where(x => x % 2 != 0);
            //    Console.WriteLine(string.Join(" ", filteredNumbers));
            //}
            //else if (filterWord == "even")
            //{
            //    var filteredNumbers = newNumbers.Where(x => x % 2 == 0);
            //    Console.WriteLine(string.Join(" ", filteredNumbers));
            //}
        }

        static IEnumerable<int> Filter(IEnumerable<int> collection, Func<int, bool> filter)
        {
            List<int> result = new List<int>();
            foreach (var item in collection)
            {
                if (filter(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
