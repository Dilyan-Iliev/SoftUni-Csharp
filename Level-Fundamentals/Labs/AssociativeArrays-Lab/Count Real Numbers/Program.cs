using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                int[] numbers = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(num => int.Parse(num))
                    .ToArray();

                SortedDictionary<int, int> dictionary = new SortedDictionary<int, int>();

                foreach (var num in numbers)
                {
                    if (!dictionary.ContainsKey(num))
                    {
                        dictionary[num] = 1;
                    }
                    else
                    {
                        dictionary[num]++;
                    }
                }
                PrintDictionary(dictionary);
            }

            static void PrintDictionary(SortedDictionary<int, int> dictionary)
            {
                foreach (var item in dictionary)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
            }
        }
    }
}
