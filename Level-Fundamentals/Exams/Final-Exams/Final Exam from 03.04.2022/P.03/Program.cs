using System;
using System.Collections.Generic;

namespace P._03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task - Wild Zoo

            Dictionary<string, Animal> stateOfFoodDictionary = new Dictionary<string, Animal>();
            Dictionary<string, int> hungryAnimalsDictionary = new Dictionary<string, int>();

            string command;
            while ((command = Console.ReadLine()) != "EndDay")
            {
                string[] cmdArgs = command
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string[] furtherInfo = cmdArgs[1]
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);

                string currentCmd = cmdArgs[0];

                string animal = furtherInfo[0];

                if (currentCmd == "Add")
                {
                    AddCmd(stateOfFoodDictionary, animal, furtherInfo);
                }
                else if (currentCmd == "Feed")
                {
                    FeedCmd(stateOfFoodDictionary, animal, furtherInfo);
                }
            }
            foreach (var kvp in stateOfFoodDictionary)
            {
                if (kvp.Value.NeededFoodQuantity > 0)
                {
                    string currentArea = kvp.Value.AreaLivingIn;
                    if (!hungryAnimalsDictionary.ContainsKey(currentArea))
                    {
                        hungryAnimalsDictionary[currentArea] = 1;
                    }
                    else
                    {
                        hungryAnimalsDictionary[currentArea]++;
                    }
                }
            }
            PrintOutput(stateOfFoodDictionary, hungryAnimalsDictionary);
        }

        static void PrintOutput(Dictionary<string, Animal> stateOfFoodDictionary,
            Dictionary<string, int> hungryAnimalsDictionary)
        {
            Console.WriteLine("Animals:");
            foreach (var kvp in stateOfFoodDictionary)
            {
                Console.WriteLine($" {kvp.Key} -> {kvp.Value.NeededFoodQuantity}g");
            }

            Console.WriteLine("Areas with hungry animals:");
            foreach (var kvp in hungryAnimalsDictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        static Dictionary<string, Animal> AddCmd(Dictionary<string, Animal> dict, string animal, string[] arr)
        {
            int neededFood = int.Parse(arr[1]);
            string area = arr[2];

            if (!dict.ContainsKey(animal))
            {
                Animal animalObj = new Animal(neededFood, area);
                dict.Add(animal, animalObj);
            }
            else
            {
                dict[animal].NeededFoodQuantity += neededFood;
            }

            return dict;
        }

        static Dictionary<string, Animal> FeedCmd(Dictionary<string, Animal> dict, string animal, string[] arr)
        {
            int food = int.Parse(arr[1]);

            if (dict.ContainsKey(animal))
            {
                dict[animal].NeededFoodQuantity -= food;

                if (dict[animal].NeededFoodQuantity <= 0)
                {
                    Console.WriteLine($"{animal} was successfully fed");
                    dict.Remove(animal);
                }
            }
            else
            {
                return dict;
            }

            return dict;
        }
    }

    class Animal
    {
        public Animal(int food, string area)
        {
            this.NeededFoodQuantity = food;
            this.AreaLivingIn = area;
        }
        public int NeededFoodQuantity { get; set; }
        public string AreaLivingIn { get; set; }

    }
}
