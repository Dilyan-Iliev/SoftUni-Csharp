using System;
using System.Linq;
using System.Collections.Generic;

namespace P._10_ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<string>>();
            //var forceUserFirst = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] inputArgs;
                string forceSide;
                string forceUser;
                if (input.Contains(" | "))
                {
                    inputArgs = input
                        .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    forceSide = inputArgs[0];
                    forceUser = inputArgs[1];

                    if (!dictionary.ContainsKey(forceSide))
                    {
                        dictionary[forceSide] = new List<string>();
                        dictionary[forceSide].Add(forceUser);
                    }
                }
                else if (input.Contains(" -> "))
                {
                    inputArgs = input
                        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    forceSide = inputArgs[1];
                    forceUser = inputArgs[0];

                    foreach (var kvp in dictionary)
                    {
                        if (kvp.Value.Contains(forceUser))
                        {
                            kvp.Value.Remove(forceUser);
                        }
                    }

                    if (!dictionary.ContainsKey(forceSide))
                    {
                        dictionary[forceSide] = new List<string>();
                    }
                    dictionary[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            foreach (var kvp in dictionary
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                    Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");
                foreach (var item in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {item}");
                }
            }
        }
    }
}
