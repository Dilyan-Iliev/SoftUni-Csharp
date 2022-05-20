using System;
using System.Linq;
using System.Collections.Generic;

namespace P._01_LootBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstBox = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondBox = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> firstBoxQueue = new Queue<int>(firstBox);
            Stack<int> secondBoxStack = new Stack<int>(secondBox);

            long claimedItems = 0;

            while (firstBoxQueue.Any() && secondBoxStack.Any())
            {
                var currentFirstBoxElement = firstBoxQueue.Peek();
                var currentSecondBoxElement = secondBoxStack.Peek();

                int elementsSum = currentFirstBoxElement + currentSecondBoxElement;

                if (elementsSum % 2 == 0)
                {
                    claimedItems += elementsSum;

                    firstBoxQueue.Dequeue();
                    secondBoxStack.Pop();
                }
                else
                {
                    var element = secondBoxStack.Pop();
                    firstBoxQueue.Enqueue(element);
                }
            }

            PrintOutput(firstBoxQueue, secondBoxStack, claimedItems);
        }

        static void PrintOutput(Queue<int> firstBoxQueue, Stack<int> secondBoxStack, long claimedItems)
        {
            if (!firstBoxQueue.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (!secondBoxStack.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
