using System;
using System.Linq;
using System.Collections.Generic;

namespace P._06_Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 1; i <= numberOfLines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = input[0];
                string[] clothes = input[1]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (!dictionary.ContainsKey(color))
                {
                    dictionary[color] = new Dictionary<string, int>();
                }

                for (int k = 0; k < clothes.Length; k++)
                {
                    string currentWear = clothes[k];

                    if (!dictionary[color].ContainsKey(currentWear))
                    {
                        dictionary[color][currentWear] = 0;
                    }
                    dictionary[color][currentWear]++;
                }
            }

            string[] clothesToLookFor = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string colorToLookFor = clothesToLookFor[0];
            string pieceOfClothingToLookFor = clothesToLookFor[1];

            PrintOutput(dictionary, colorToLookFor, pieceOfClothingToLookFor);
        }

        static void PrintOutput(Dictionary<string, Dictionary<string, int>> dictionary,
            string colorToLookFor, string pieceOfClothingToLookFor)
        {
            foreach (var color in dictionary)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var wear in color.Value)
                {
                    if (color.Key == colorToLookFor && wear.Key == pieceOfClothingToLookFor)
                    {
                        Console.WriteLine($"* {wear.Key} - {wear.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {wear.Key} - {wear.Value}");
                    }
                }
            }
        }
    }
}
