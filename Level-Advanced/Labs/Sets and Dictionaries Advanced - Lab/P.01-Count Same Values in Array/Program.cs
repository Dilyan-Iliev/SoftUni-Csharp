using System;
using System.Linq;
using System.Collections.Generic;

namespace P._01_Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                

            Dictionary<string, int> numbersDictionary = new Dictionary<string, int>();

            foreach (var number in numbers)
            {
                if (!numbersDictionary.ContainsKey(number))
                {
                    numbersDictionary[number] = 0;
                }
                numbersDictionary[number]++;    
            }

            foreach (var kvp in numbersDictionary)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
