using System;
using System.Linq;
using System.Collections.Generic;

namespace P._12_Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bottlesWithWater = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> bottlesStack = new Stack<int>(bottlesWithWater);
            Queue<int> cupsQueue = new Queue<int>(cupsCapacity);

            int wastedWater = 0;
            bool isNewOne = true;
            int currentCup = 0;

            while (bottlesStack.Any() && cupsQueue.Any())
            {
                if (isNewOne)
                {
                    currentCup = cupsQueue.Peek();
                    isNewOne = false;
                }
                int currentBottle = bottlesStack.Pop();

                if (currentCup - currentBottle <= 0)
                {
                    int left = currentCup - currentBottle;
                    wastedWater += left;
                    cupsQueue.Dequeue();
                    isNewOne = true;
                }
                else
                {
                    currentCup -= currentBottle;
                }
            }

            if (cupsQueue.Any())
            {
                Console.WriteLine($"Cups: {string.Join(' ', cupsQueue)}");
            }
            else if (bottlesStack.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottlesStack)}");
            }
            Console.WriteLine($"Wasted litters of water: {Math.Abs(wastedWater)}");
        }
    }
}
