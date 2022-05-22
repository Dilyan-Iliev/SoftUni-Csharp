using System;
using System.Linq;
using System.Collections.Generic;

namespace P._01_MealPlan
{
    internal class Program
    {
        const int saladCalories = 350;
        const int soupCalories = 490;
        const int pastaCalories = 680;
        const int steakCalories = 790;
        static void Main()
        {
            string[] meals = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

            int[] maxCaloriesPerDay = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<string> mealsQueue = new Queue<string>(meals);
            Stack<int> caloriesStack = new Stack<int>(maxCaloriesPerDay);

            int eatenMealsCounter = 0;

            while (mealsQueue.Any() && caloriesStack.Any())
            {
                string currentMeal = mealsQueue.Dequeue();
                int currentCalories = caloriesStack.Peek();

                int remainingCalories = 0;
                remainingCalories = MealCheck(currentMeal, currentCalories, remainingCalories);

                caloriesStack.Pop();
                if (remainingCalories > 0)
                {
                    caloriesStack.Push(remainingCalories);
                }
                else if (remainingCalories == 0)
                {
                    caloriesStack.Pop();
                }
                else if (remainingCalories < 0)
                {
                    if (caloriesStack.Any())
                    {
                        currentCalories = caloriesStack.Peek();
                        currentCalories -= Math.Abs(remainingCalories);
                        caloriesStack.Pop();
                        caloriesStack.Push(currentCalories);
                    }
                }
                eatenMealsCounter++;
            }

            PrintOutput(mealsQueue, caloriesStack, eatenMealsCounter);
        }
        static void PrintOutput(Queue<string> mealsQueue, Stack<int> caloriesStack, int eatenMealsCounter)
        {
            if (caloriesStack.Any())
            {
                Console.WriteLine($"John had {eatenMealsCounter} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesStack)} calories.");
            }
            else if (mealsQueue.Any())
            {
                Console.WriteLine($"John ate enough, he had {eatenMealsCounter} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", mealsQueue)}.");
            }
        }
        static int MealCheck(string currentMeal, int currentCalories, int remainingCalories)
        {
            if (currentMeal == "salad")
            {
                remainingCalories = currentCalories - saladCalories;
            }
            else if (currentMeal == "soup")
            {
                remainingCalories = currentCalories - soupCalories;
            }
            else if (currentMeal == "pasta")
            {
                remainingCalories = currentCalories - pastaCalories;
            }
            else if (currentMeal == "steak")
            {
                remainingCalories = currentCalories - steakCalories;
            }

            return remainingCalories;
        }
    }
}
