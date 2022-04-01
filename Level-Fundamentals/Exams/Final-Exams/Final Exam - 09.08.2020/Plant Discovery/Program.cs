using System;
using System.Linq;
using System.Collections.Generic;

namespace Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, Plant>();
            int numberOfPlants = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfPlants; i++)
            {
                string[] plantsInfo = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);

                string plantType = plantsInfo[0];
                int plantRarity = int.Parse(plantsInfo[1]);

                if (!dictionary.ContainsKey(plantType))
                {
                    var plant = new Plant()
                    {
                        Rarity = plantRarity,
                    };
                    dictionary[plantType] = plant;
                }
                else // if (dictionary.ContainsKey(plantType))
                {
                    dictionary[plantType].UpdateRarity(plantRarity);
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] cmdArgs = command
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string[] plantInfo = cmdArgs[1]
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string currentCommand = cmdArgs[0];
                //string plant = plantInfo[0];

                if (currentCommand == "Rate")
                {
                    RateCmd(dictionary, plantInfo);
                }
                else if (currentCommand == "Update")
                {
                    UpdateCmd(dictionary, plantInfo);
                }
                else if (currentCommand == "Reset")
                {
                    ResetCmd(dictionary, plantInfo);
                }
            }
            PrintDictionary(dictionary);
        }

        static Dictionary<string, Plant> RateCmd(Dictionary<string, Plant> dict, string[] arr)
        {
            string plant = arr[0];
            int rating = int.Parse(arr[1]);

            if (!dict.ContainsKey(plant))
            {
                Console.WriteLine("error");
            }
            else // if (dict.ContainsKey(plantToRate))
            {
                //dict[plant].Rating = new List<double>();
                dict[plant].Rating.Add(rating);
            }

            return dict;
        }

        static Dictionary<string, Plant> UpdateCmd(Dictionary<string, Plant> dict, string[] arr)
        {
            string plant = arr[0];
            int newRarity = int.Parse(arr[1]);

            if (!dict.ContainsKey(plant))
            {
                Console.WriteLine("error");
            }
            else
            {
                dict[plant].UpdateRarity(newRarity);
            }

            return dict;
        }

        static Dictionary<string, Plant> ResetCmd(Dictionary<string, Plant> dict, string[] arr)
        {
            string plant = arr[0];

            if (!dict.ContainsKey(plant))
            {
                Console.WriteLine("error");
            }
            else
            {
                dict[plant].Rating.Clear();

            }

            return dict;
        }

        static void PrintDictionary(Dictionary<string, Plant> dict)
        {
            Console.WriteLine("Plants for the exhibition:");
            foreach (var kvp in dict)
            {
                if (kvp.Value.Rating.Count == 0)
                {
                    Console.WriteLine($"- {kvp.Key}; Rarity: {kvp.Value.Rarity}; Rating: 0.00");
                }
                else
                {
                    Console.WriteLine($"- {kvp.Key}; Rarity: {kvp.Value.Rarity}; Rating: {(kvp.Value.Rating.Average()):F2}");
                }
            }
        }
    }

    public class Plant
    {
        public Plant()
        {
            this.Rating = new List<double>();
        }

        public int Rarity { get; set; }
        public List<double> Rating { get; set; }

        public int UpdateRarity(int rarity)
        {
            this.Rarity = rarity;
            return this.Rarity;
        }

    }
}
