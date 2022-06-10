using System;
using System.Collections.Generic;
using System.Linq;

namespace P._01_Cooking
{
    public class StartUp
    {
        private const int BreadValue = 25;
        private const int CakeValue = 50;
        private const int PastryValue = 75;
        private const int FruitPieValue = 100;

        private static int breadCount = 0;
        private static int cakeCount = 0;
        private static int pastryCount = 0;
        private static int fruitPieCount = 0;

        private static string currentProduct = string.Empty;

        private static Dictionary<string, int> products = new Dictionary<string, int>()
        {
            { "Bread", 0},
            { "Cake", 0 },
            { "Pastry", 0 },
            { "Fruit Pie", 0 }
        };

        static void Main()
        {
            var liquids = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var ingredients = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var liquidsQueue = new Queue<int>(liquids);
            var ingredientsStack = new Stack<int>(ingredients);

            bool succeeded = false;

            while (liquidsQueue.Any() && ingredientsStack.Any())
            {
                var currentQueueElement = liquidsQueue.Peek();
                var currentStackElement = ingredientsStack.Peek();

                int valuesSum = currentQueueElement + currentStackElement;

                if (CheckForCoincedence(valuesSum))
                {
                    liquidsQueue.Dequeue();
                    ingredientsStack.Pop();

                    products[currentProduct]++;
                }
                else
                {
                    liquidsQueue.Dequeue();

                    ingredientsStack.Pop();
                    ingredientsStack.Push(currentStackElement += 3);
                }

                if (breadCount >= 1 && cakeCount >= 1 && fruitPieCount >= 1 && pastryCount >= 1)
                {
                    succeeded = true;
                    break;
                }
            }

            PrintOutput(liquidsQueue, ingredientsStack, succeeded);
        }

        static void PrintOutput(Queue<int> liquidsQueue, Stack<int> ingredientsStack, bool succeeded)
        {
            if (succeeded || !ingredientsStack.Any() && !liquidsQueue.Any())
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquidsQueue.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquidsQueue)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredientsStack.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredientsStack)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var product in products.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }
        }

        public static bool CheckForCoincedence(int valueSum)
        {
            if (valueSum == BreadValue)
            {
                currentProduct = "Bread";
                breadCount++;
                return true;
            }
            else if (valueSum == CakeValue)
            {
                currentProduct = "Cake";
                cakeCount++;
                return true;
            }
            else if (valueSum == PastryValue)
            {
                currentProduct = "Pastry";
                pastryCount++;
                return true;
            }
            else if (valueSum == FruitPieValue)
            {
                currentProduct = "Fruit Pie";
                fruitPieCount++;
                return true;
            }

            return false;
        }
    }
}
