using System;
using System.Linq;
using System.Collections.Generic;

namespace P._01_Flower_Wreaths
{
    internal class Program
    {
        const int flowersForWreath = 15;
        const int neededWreaths = 5;
        static void Main()
        {
            int[] lilies = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] roses = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> liliesStack = new Stack<int>(lilies);
            Queue<int> rosesQueue = new Queue<int>(roses);

            int wreathCounter = 0;
            int storedFlowers = 0;

            while (liliesStack.Any() && rosesQueue.Any())
            {
                int currentLilie = liliesStack.Peek();
                int currentRose = rosesQueue.Peek();

                int sum = currentLilie + currentRose;

                if (sum == 15)
                {
                    liliesStack.Pop();
                    rosesQueue.Dequeue();

                    wreathCounter++;
                }
                else if (sum > 15)
                {
                    int lilie = liliesStack.Pop() - 2;
                    liliesStack.Push(lilie);
                }
                else if (sum < 15)
                {
                    storedFlowers += sum;

                    liliesStack.Pop();
                    rosesQueue.Dequeue();
                }
            }

            int additionalWreaths = storedFlowers / flowersForWreath;
            wreathCounter += additionalWreaths;

            if (wreathCounter >= neededWreaths)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCounter} wreaths!");
            }
            else
            {
                int neededWreathsMore = neededWreaths - wreathCounter;
                Console.WriteLine($"You didn't make it, you need {neededWreathsMore} wreaths more!");
            }
        }
    }
}
