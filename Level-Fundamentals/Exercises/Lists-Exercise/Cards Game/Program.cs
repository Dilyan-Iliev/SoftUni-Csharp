using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            List<int> secondList = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                if (firstList[0] > secondList[0])
                {
                    firstList.Add(firstList[0]);
                    firstList.Add(secondList[0]);
                }
                else if (secondList[0] > firstList[0])
                {
                    secondList.Add(secondList[0]);
                    secondList.Add(firstList[0]);
                }
                firstList.RemoveAt(0);
                secondList.RemoveAt(0);

                if (firstList.Count == 0)
                {
                    int sum = secondList.Sum();
                    Console.WriteLine($"Second player wins! Sum: {sum}");
                    break;
                }
                else if (secondList.Count == 0)
                {
                    int sum = firstList.Sum();
                    Console.WriteLine($"First player wins! Sum: {sum}");
                    break;
                }
            }
        }
    }
}
