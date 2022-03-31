using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var playerNames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var dictionary = new Dictionary<string, double>();

            string namesPattern = @"(?<name>[A-Za-z]+)";
            string distancePattern = @"(?<distance>\d+)";

            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                string name = string.Empty;
                string distance = string.Empty; 

                Regex namesRegex = new Regex(namesPattern);
                Regex distanceRegex = new Regex(distancePattern);

                MatchCollection nameMatches = namesRegex.Matches(input);
                MatchCollection distanceMatches = distanceRegex.Matches(input);

                foreach (Match match in nameMatches)
                {
                    name += match.Groups["name"].Value;
                }
                foreach (Match match in distanceMatches)
                {
                    distance += match.Groups["distance"].Value;
                }

                int distanceOfRacer = distance
                    .Sum(x => int.Parse(x.ToString())); //sum all the digits in the distance string by using LINQ

                if (!dictionary.ContainsKey(name))
                {
                    if (playerNames.Contains(name))
                    {
                        dictionary[name] = distanceOfRacer;
                    }
                }
                else // if (dictionary.ContainsKey(name))
                {
                    if (playerNames.Contains(name))
                    {
                        dictionary[name] += distanceOfRacer;
                    }
                }
            }

            var orderedDictionary = dictionary.OrderByDescending(x => x.Value)
                .Take(3)
                .ToDictionary(x => x.Key, x => x.Value);

            int counter = 1;
            foreach (var kvp in orderedDictionary)
            {
                if (counter == 1)
                {
                    Console.WriteLine($"1st place: {kvp.Key}");
                }
                else if (counter == 2)
                {
                    Console.WriteLine($"2nd place: {kvp.Key}");
                }
                else if (counter == 3)
                {
                    Console.WriteLine($"3rd place: {kvp.Key}");
                }

                counter++;
            }
        }
    }
}
