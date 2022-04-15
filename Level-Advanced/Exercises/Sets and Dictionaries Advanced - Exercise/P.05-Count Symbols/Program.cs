using System;
using System.Linq;
using System.Collections.Generic;

namespace P._05_Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> sortedDictionary = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!sortedDictionary.ContainsKey(input[i]))
                {
                    sortedDictionary[input[i]] = 0;
                }
                sortedDictionary[input[i]]++;
            }

            foreach (var kvp in sortedDictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
