using System;
using System.Collections.Generic;
using System.Linq;

namespace Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> values = Console.ReadLine()
                .Split('|')
                .Reverse()
                .ToList(); //input 1 2 3 |4 5 6 | 7 8 -> i will have list with 3 items - 1 2 3 | 4 5 6 | 7 8

            List<int> nums = new List<int>();
            foreach (var str in values)
            {
                nums.AddRange(str.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList()); //using AddRange - If you want to add a large number of values at one time, use AddRange. If you are only adding a single value or adding values infrequently, use Add
            }
            Console.WriteLine(String.Join(" ",nums));

        }
    }
}
