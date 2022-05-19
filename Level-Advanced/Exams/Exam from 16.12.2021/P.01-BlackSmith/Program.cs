using System;
using System.Linq;
using System.Collections.Generic;

namespace P._01_BlackSmith
{
    internal class Program
    {
        const int gladiusResourcesNeeded = 70;
        const int shamshirResourcesNeeded = 80;
        const int katanaResourcesNeeded = 90;
        const int sabreResourcesNeeded = 110;
        const int broadswordResourcesNeeded = 150;

        public static int gladiusBuilt = 0;
        public static int shamshirBuilt = 0;
        public static int katanaBuilt = 0;
        public static int sabreBuilt = 0;
        public static int broadswordBuilt = 0;

        public static string swordName = string.Empty;
        static void Main(string[] args)
        {
            //Input
            int[] steel = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] carbon = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            //Collections
            Queue<int> steelQueue = new Queue<int>(steel);
            Stack<int> carbonStack = new Stack<int>(carbon);
            Dictionary<string, int> swords = new Dictionary<string, int>();

            while (steelQueue.Any() && carbonStack.Any())
            {
                int currentSteel = steelQueue.Peek();
                int currentCarbon = carbonStack.Peek();

                int resourcesSum = currentSteel + currentCarbon;

                if (CheckForResourcesMatch(resourcesSum))
                {
                    steelQueue.Dequeue();
                    carbonStack.Pop();

                    if (!swords.ContainsKey(swordName))
                    {
                        swords[swordName] = 0;
                    }
                    swords[swordName]++;
                }
                else
                {
                    steelQueue.Dequeue();
                    int carbonToManipulate = carbonStack.Peek() + 5;
                    carbonStack.Pop();
                    carbonStack.Push(carbonToManipulate);
                }
            }

            PrintOutput(swords, steelQueue, carbonStack);
        }

        static void PrintOutput(Dictionary<string, int> swords,
            Queue<int> steelQueue, Stack<int> carbonStackk)
        {
            if (swords.Any())
            {
                Console.WriteLine($"You have forged {swords.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steelQueue.Any())
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steelQueue)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbonStackk.Any())
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbonStackk)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            if (swords.Any())
            {
                foreach (var kvp in swords.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }
        }
        static bool CheckForResourcesMatch(int resourcesSum)
        {
            if (resourcesSum == gladiusResourcesNeeded)
            {
                swordName = "Gladius";
                gladiusBuilt++;
                return true;
            }
            else if (resourcesSum == shamshirResourcesNeeded)
            {
                swordName = "Shamshir";
                shamshirBuilt++;
                return true;
            }
            else if (resourcesSum == katanaResourcesNeeded)
            {
                swordName = "Katana";
                katanaBuilt++;
                return true;
            }
            else if (resourcesSum == sabreResourcesNeeded)
            {
                swordName = "Sabre";
                sabreBuilt++;
                return true;
            }
            else if (resourcesSum == broadswordResourcesNeeded)
            {
                swordName = "Broadsword";
                broadswordBuilt++;
                return true;
            }

            return false;
        }
    }
}
