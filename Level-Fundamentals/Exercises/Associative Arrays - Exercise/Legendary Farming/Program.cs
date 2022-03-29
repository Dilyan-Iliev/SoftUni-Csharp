using System;
using System.Linq;
using System.Collections.Generic;

namespace Legendary_Farming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, int>();
            var junkDictionary = new Dictionary<string, int>();
            dictionary["shards"] = 0;
            dictionary["motes"] = 0;
            dictionary["fragments"] = 0;

            bool materialsCollected = false;

            while (!materialsCollected)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < inputArgs.Length; i += 2)
                {
                    int materialQuantity = int.Parse(inputArgs[i]);
                    string currentMaterial = inputArgs[i + 1].ToLower();

                    if (dictionary.ContainsKey(currentMaterial))
                    {
                        dictionary[currentMaterial] += materialQuantity;

                        if (dictionary[currentMaterial] >= 250)
                        {
                            GetLegendaryItem(currentMaterial);

                            dictionary[currentMaterial] -= 250;
                            materialsCollected = true;
                            break;
                        }
                    }

                    else
                    {
                        if (!junkDictionary.ContainsKey(currentMaterial))
                        {
                            junkDictionary.Add(currentMaterial, 0);
                        }

                        junkDictionary[currentMaterial] += materialQuantity;
                    }
                }
            }

            SortedDictionary(dictionary);
            SortedDictionary(junkDictionary);

            static void SortedDictionary(Dictionary<string, int> dictionary)
            {
                foreach (var item in dictionary)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }

            static void GetLegendaryItem(string material)
            {
                string legendary = string.Empty;

                if (material == "shards")
                {
                    legendary = "Shadowmourne";
                }
                else if (material == "fragments")
                {
                    legendary = "Valanyr";

                }
                else if (material == "motes")
                {
                    legendary = "Dragonwrath";
                }

                Console.WriteLine($"{legendary} obtained!");
            }
        }
    }
}
