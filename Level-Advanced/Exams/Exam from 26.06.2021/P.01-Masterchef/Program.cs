using System;
using System.Linq;
using System.Collections.Generic;

namespace P._01_Masterchef
{
    internal class Program
    {
        const int dippingSauce = 150;
        const int greenSalad = 250;
        const int chocolateCake = 300;
        const int lobster = 400;

        public static int dippingSauceCounter = 0;
        public static int greenSaladCounter = 0;
        public static int chocolateCakeCounter = 0;
        public static int lobsterCounter = 0;

        public static string product = string.Empty;
        static void Main(string[] args)
        {
            int[] ingredients = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] freshnessValues = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> ingredientsQueue = new Queue<int>(ingredients);
            Stack<int> freshnessStack = new Stack<int>(freshnessValues);
            Dictionary<string, int> products = new Dictionary<string, int>();

            while (ingredientsQueue.Any() && freshnessStack.Any())
            {
                var currentIngredient = ingredientsQueue.Peek();
                var currentFreshness = freshnessStack.Peek();

                if (currentIngredient == 0)
                {
                    ingredientsQueue.Dequeue();
                    continue;
                }

                int freshnessLevel = currentIngredient * currentFreshness;

                if (CheckForFreshnessMatch(freshnessLevel))
                {
                    ingredientsQueue.Dequeue();
                    freshnessStack.Pop();

                    if (!products.ContainsKey(product))
                    {
                        products[product] = 0;
                    }
                    products[product]++;
                }
                else
                {
                    freshnessStack.Pop();
                    currentIngredient += 5;
                    ingredientsQueue.Dequeue();
                    ingredientsQueue.Enqueue(currentIngredient);
                }
            }

            PrintOutput(products, ingredientsQueue, freshnessStack);
        }

        static void PrintOutput(Dictionary<string, int> products,
            Queue<int> ingredientsQueue, Stack<int> freshnessStack)
        {
            if (products.Count >= 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes! ");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredientsQueue.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredientsQueue.Sum()}");
            }

            foreach (var kvp in products.OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {kvp.Key} --> {kvp.Value}");
            }
        }
        static bool CheckForFreshnessMatch(int freshnessLevel)
        {
            if (freshnessLevel == dippingSauce)
            {
                product = "Dipping sauce";
                dippingSauceCounter++;
                return true;
            }
            else if (freshnessLevel == greenSalad)
            {
                product = "Green salad";
                greenSaladCounter++;
                return true;
            }
            else if (freshnessLevel == chocolateCake)
            {
                product = "Chocolate cake";
                chocolateCakeCounter++;
                return true;
            }
            else if (freshnessLevel == lobster)
            {
                product = "Lobster";
                lobsterCounter++;
                return true;
            }

            return false;
        }
    }
}
