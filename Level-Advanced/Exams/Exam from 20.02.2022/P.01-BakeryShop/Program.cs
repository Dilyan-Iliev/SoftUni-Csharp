using System;
using System.Linq;
using System.Collections.Generic;

namespace P._01_BakeryShop
{
    internal class Program
    {
        const double croissantWater = 50;
        const double croissantFlour = 50;

        const double muffinWater = 40;
        const double muffinFlour = 60;

        const double baguetteWater = 30;
        const double baguetteFlour = 70;

        const double bagelWater = 20;
        const double bagelFlour = 80;

        public static int bakedMuffinCounter = 0;
        public static int bakedCroissantCounter = 0;
        public static int bakedBaguetteCounter = 0;
        public static int bakedBagelCounter = 0;

        public static string product = string.Empty;

        static void Main(string[] args)
        {
            //Input
            double[] water = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            double[] flour = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            //Collections
            Queue<double> waterQueue = new Queue<double>(water);
            Stack<double> flourStack = new Stack<double>(flour);
            Dictionary<string, int> products = new Dictionary<string, int>();

            while (waterQueue.Any() && flourStack.Any())
            {
                double currentWater = waterQueue.Peek();
                double currentFlour = flourStack.Peek();

                double waterAndFlourSum = currentWater + currentFlour;
                double currentWaterPercantage = (currentWater * 100) / waterAndFlourSum;
                double currentFlourPercantage = (currentFlour * 100) / waterAndFlourSum;

                if (CheckForIngredients(currentWaterPercantage, currentFlourPercantage))
                {
                    waterQueue.Dequeue();
                    flourStack.Pop();
                }
                else
                {
                    var currentFlowerr = flourStack.Pop();
                    var currentWaterr = waterQueue.Dequeue();
                    var flourReduced = currentFlowerr - currentWater;
                    flourStack.Push(flourReduced);
                    bakedCroissantCounter++;
                }

                if (!products.ContainsKey(product))
                {
                    products[product] = 0;
                }
                products[product]++;
            }

            PrintResult(products, waterQueue, flourStack);
        }
            
        static void PrintResult(Dictionary<string, int> products,
            Queue<double> waterQueue, Stack<double> flourStack)
        {
            foreach (var kvp in products
                .Where(x => x.Value > 0)
                .OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            if (!waterQueue.Any())
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", waterQueue)}");
            }

            if (!flourStack.Any())
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flourStack)}");
            }
        }
        static bool CheckForIngredients(double currentWaterPercantage, double currentFlourPercantage)
        {
            if (currentWaterPercantage == croissantWater && currentFlourPercantage == croissantFlour)
            {
                bakedCroissantCounter++;
                product = "Croissant";
                return true;
            }
            else if (currentWaterPercantage == muffinWater && currentFlourPercantage == muffinFlour)
            {
                bakedMuffinCounter++;
                product = "Muffin";
                return true;
            }
            else if (currentWaterPercantage == baguetteWater && currentFlourPercantage == baguetteFlour)
            {
                bakedBaguetteCounter++;
                product = "Baguette";
                return true;
            }
            else if (currentWaterPercantage == bagelWater && currentFlourPercantage == bagelFlour)
            {
                bakedBagelCounter++;
                product = "Bagel";
                return true;
            }

            product = "Croissant";
            return false;
        }
    }
}
