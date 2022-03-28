using System;
using System.Linq;
using System.Collections.Generic;

namespace Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> finalResults = new List<int>();

            int endOfIterations = Math.Max(firstList.Count, secondList.Count);

            for (int i = 0; i < endOfIterations; i++)
            {
                if (i < firstList.Count)
                {
                    finalResults.Add(firstList[i]);
                }
                if (i < secondList.Count)
                {
                    finalResults.Add(secondList[i]);
                }
            }
            Console.WriteLine(String.Join(" ",finalResults));
        }
    }
}
