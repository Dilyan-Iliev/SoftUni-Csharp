using System;
using System.Collections.Generic;

namespace P_rates
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    var dictionary = new Dictionary<string, List<int>>();

        //    string input;
        //    while ((input = Console.ReadLine()) != "Sail")
        //    {
        //        string[] inputArgs = input
        //            .Split("||", StringSplitOptions.RemoveEmptyEntries);

        //        PopulationAndGoldFilling(dictionary, inputArgs);
        //    }

        //    string events;
        //    while ((events = Console.ReadLine()) != "End")
        //    {
        //        string[] eventsArgs = events
        //            .Split("=>", StringSplitOptions.RemoveEmptyEntries);

        //        DictionaryManipulation(dictionary, eventsArgs);
        //    }

        //    PrintDictionary(dictionary);
        //}
        //static Dictionary<string, List<int>> PopulationAndGoldFilling(Dictionary<string, List<int>> dict, string[] arr)
        //{
        //    string city = arr[0];
        //    int population = int.Parse(arr[1]);
        //    int gold = int.Parse(arr[2]);

        //    if (!dict.ContainsKey(city))
        //    {
        //        dict[city] = new List<int>();
        //        dict[city].Add(population);
        //        dict[city].Add(gold);
        //    }
        //    else
        //    {
        //        dict[city][0] += population;
        //        dict[city][1] += gold;
        //    }

        //    return dict;
        //}

        //static Dictionary<string, List<int>> DictionaryManipulation(Dictionary<string, List<int>> dict, string[] arr)
        //{
        //    string command = arr[0];

        //    switch (command)
        //    {
        //        case "Plunder": PlunderCmd(dict, arr); break;
        //        case "Prosper": ProsperCmd(dict, arr); break;
        //    }

        //    return dict;
        //}

        //static Dictionary<string, List<int>> PlunderCmd(Dictionary<string, List<int>> dict, string[] arr)
        //{
        //    string cityToPlunder = arr[1];
        //    int people = int.Parse(arr[2]);
        //    int gold = int.Parse(arr[3]);

        //    dict[cityToPlunder][0] -= people;
        //    dict[cityToPlunder][1] -= gold;

        //    Console.WriteLine($"{cityToPlunder} plundered! {gold} gold stolen, {people} citizens killed.");
        //    if (dict[cityToPlunder][0] <= 0
        //        || dict[cityToPlunder][1] <= 0)
        //    {
        //        Console.WriteLine($"{cityToPlunder} has been wiped off the map!");
        //        dict.Remove(cityToPlunder);
        //    }

        //    return dict;
        //}

        //static Dictionary<string, List<int>> ProsperCmd(Dictionary<string, List<int>> dict, string[] arr)
        //{
        //    string townToProsper = arr[1];
        //    int gold = int.Parse(arr[2]);

        //    if (gold < 0)
        //    {
        //        Console.WriteLine("Gold added cannot be a negative number!");

        //    }
        //    else
        //    {
        //        dict[townToProsper][1] += gold;
        //        Console.WriteLine($"{gold} gold added to the city treasury. {townToProsper} now has {dict[townToProsper][1]} gold.");
        //    }
        //    return dict;
        //}

        //static void PrintDictionary(Dictionary<string, List<int>> dict)
        //{
        //    if (dict.Count > 0)
        //    {
        //        Console.WriteLine($"Ahoy, Captain! There are {dict.Count} wealthy settlements to go to:");
        //        foreach (var kvp in dict)
        //        {
        //            Console.WriteLine($"{kvp.Key} -> Population: {kvp.Value[0]} citizens, Gold: {kvp.Value[1]} kg");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Ahoy Captain! All targets have been plundered and destroyed!");
        //    }
        //}

        //or

        //    static void Main()
        //    {
        //        var dictionary = new Dictionary<string, Town>();

        //        string input;
        //        while ((input = Console.ReadLine()) != "Sail")
        //        {
        //            string[] inputArgs = input
        //                .Split("||", StringSplitOptions.RemoveEmptyEntries);

        //            string town = inputArgs[0];
        //            int townPopulation = int.Parse(inputArgs[1]);
        //            int townGold = int.Parse(inputArgs[2]);

        //            if (!dictionary.ContainsKey(town))
        //            {
        //                var townObj = new Town()
        //                {
        //                    Population = townPopulation,
        //                    TownGold = townGold,
        //                };
        //                dictionary[town] = townObj;
        //                continue;
        //            }
        //            dictionary[town].Population += townPopulation;
        //            dictionary[town].TownGold += townGold;
        //        }

        //        string townState;
        //        while ((townState = Console.ReadLine()) != "End")
        //        {
        //            string[] arr = townState
        //                .Split("=>", StringSplitOptions.RemoveEmptyEntries);

        //            string command = arr[0];
        //            string town = arr[1];

        //            if (command == "Plunder")
        //            {
        //                int people = int.Parse(arr[2]);
        //                int gold = int.Parse(arr[3]);

        //                dictionary[town].Population -= people;
        //                dictionary[town].TownGold -= gold;

        //                Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

        //                if (dictionary[town].Population <= 0
        //                    || dictionary[town].TownGold <= 0)
        //                {
        //                    Console.WriteLine($"{town} has been wiped off the map!");
        //                    dictionary.Remove(town);
        //                }
        //            }
        //            else if (command == "Prosper")
        //            {
        //                int gold = int.Parse(arr[2]);

        //                if (gold < 0)
        //                {
        //                    Console.WriteLine("Gold added cannot be a negative number!");
        //                    continue;
        //                }
        //                dictionary[town].TownGold += gold;
        //                Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {dictionary[town].TownGold} gold.");
        //            }
        //        }

        //        if (dictionary.Count == 0)
        //        {
        //            Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Ahoy, Captain! There are {dictionary.Count} wealthy settlements to go to:");
        //            foreach (var kvp in dictionary)
        //            {
        //                Console.WriteLine($"{kvp.Key} -> Population: {kvp.Value.Population} citizens, Gold: {kvp.Value.TownGold} kg");
        //            }
        //        }
        //    }
        //}

        //public class Town
        //{
        //    public int Population { get; set; }
        //    public int TownGold { get; set; }

        //public Dictionary<string, Town> DictionaryManipulation(Dictionary<string, Town> dict, string[] arr)
        //{
        //TODO:
        //    string command = arr[0];
        //    switch (command)
        //    {

        //    }
        //}

        //    static void Main(string[] args)
        //    {
        //        var dictionary = new Dictionary<string, Town>();

        //        string input;
        //        while ((input = Console.ReadLine()) != "Sail")
        //        {
        //            string[] inputArgs = input
        //                .Split("||", StringSplitOptions.RemoveEmptyEntries);

        //            PopulationAndGoldFilling(dictionary, inputArgs);
        //        }

        //        string townState;
        //        while ((townState = Console.ReadLine()) != "End")
        //        {
        //            string[] arr = townState
        //                .Split("=>", StringSplitOptions.RemoveEmptyEntries);

        //            DictionaryManipulation(dictionary, arr);
        //        }

        //        PrintDictionary(dictionary);
        //    }

        //    static Dictionary<string, Town> PopulationAndGoldFilling(Dictionary<string, Town> dict, string[] arr)
        //    {
        //        string town = arr[0];
        //        int popluation = int.Parse(arr[1]);
        //        int gold = int.Parse(arr[2]);

        //        if (!dict.ContainsKey(town))
        //        {
        //            var townObj = new Town(popluation, gold);
        //            dict[town] = townObj;
        //        }
        //        else
        //        {
        //            dict[town].TownPopulation += popluation;
        //            dict[town].TownGold += gold;
        //        }
        //        return dict;
        //    }

        //    static Dictionary<string, Town> DictionaryManipulation(Dictionary<string, Town> dict, string[] arr)
        //    {
        //        string command = arr[0];

        //        switch (command)
        //        {
        //            case "Plunder": PlunderCmd(dict, arr); break;   
        //            case "Prosper": ProsperCmd(dict, arr); break;
        //        }

        //        return dict;
        //    }

        //    static Dictionary<string, Town> PlunderCmd(Dictionary<string, Town> dict, string[] arr)
        //    {
        //        string cityToPlunder = arr[1];
        //        int people = int.Parse(arr[2]);
        //        int gold = int.Parse(arr[3]);

        //        dict[cityToPlunder].TownPopulation -= people;
        //        dict[cityToPlunder].TownGold -= gold;

        //        Console.WriteLine($"{cityToPlunder} plundered! {gold} gold stolen, {people} citizens killed.");
        //        if (dict[cityToPlunder].TownPopulation <= 0
        //            || dict[cityToPlunder].TownGold <= 0)
        //        {
        //            Console.WriteLine($"{cityToPlunder} has been wiped off the map!");
        //            dict.Remove(cityToPlunder);
        //        }

        //        return dict;
        //    }

        //    static Dictionary<string, Town> ProsperCmd(Dictionary<string, Town> dict, string[] arr)
        //    {
        //        string townToProsper = arr[1];
        //        int gold = int.Parse(arr[2]);

        //        if (gold < 0)
        //        {
        //            Console.WriteLine("Gold added cannot be a negative number!");
        //        }
        //        else
        //        {
        //            dict[townToProsper].TownGold += gold;
        //            Console.WriteLine($"{gold} gold added to the city treasury. {townToProsper} now has {dict[townToProsper].TownGold} gold.");
        //        }

        //        return dict;
        //    }

        //    static void PrintDictionary(Dictionary<string, Town> dict)
        //    {
        //        if (dict.Count > 0)
        //        {
        //            Console.WriteLine($"Ahoy, Captain! There are {dict.Count} wealthy settlements to go to:");
        //            foreach (var kvp in dict)
        //            {
        //                Console.WriteLine($"{kvp.Key} -> Population: {kvp.Value.TownPopulation} citizens, Gold: {kvp.Value.TownGold} kg");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Ahoy Captain! All targets have been plundered and destroyed!");
        //        }
        //    }
        //}


        //public class Town
        //{
        //    public Town(int population, int gold)
        //    {
        //        this.TownPopulation = population;
        //        this.TownGold = gold;
        //    }
        //    public int TownPopulation { get; set; }
        //    public int TownGold { get; set; }  

        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, Town>();

            string input;
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] inputArgs = input
                    .Split("||", StringSplitOptions.RemoveEmptyEntries);

                string town = inputArgs[0];
                int population = int.Parse(inputArgs[1]);
                int gold = int.Parse(inputArgs[2]);

                var obj = new Town(population, gold);
                obj.PopulationAndGoldFilling(dictionary, inputArgs, town, population, gold);
            }

            string townState;
            while ((townState = Console.ReadLine()) != "End")
            {
                string[] arr = townState
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string cmd = arr[0];
                string town = arr[1];
                if (cmd == "Plunder")
                {
                    dictionary[town].PlunderCmd(dictionary, arr, town);
                }
                else if (cmd == "Prosper")
                {
                    dictionary[town].ProsperCmd(dictionary, arr, town);
                }
            }

            PrintDictionary(dictionary);
        }
        static void PrintDictionary(Dictionary<string, Town> dict)
        {
            if (dict.Count == 0)
            {
                Console.WriteLine("Ahoy Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {dict.Count} wealthy settlements to go to:");
                foreach (var kvp in dict)
                {
                    Console.WriteLine($"{kvp.Key} -> Population: {kvp.Value.TownPopulation} citizens, Gold: {kvp.Value.TownGold} kg");
                }
            }
        }
    }
    public class Town
    {
        public Town(int population, int gold)
        {
            this.TownPopulation = population;
            this.TownGold = gold;
        }
        public int TownPopulation { get; set; }
        public int TownGold { get; set; }

        public Dictionary<string, Town> PopulationAndGoldFilling(Dictionary<string, Town> dict, string[] arr
            ,string townName, int population, int gold)
        {
            if (!dict.ContainsKey(townName))
            {
                var townObj = new Town(population, gold);
                dict[townName] = townObj;
            }
            else
            {
                dict[townName].TownPopulation += population;
                dict[townName].TownGold += gold;
            }

            return dict;
        }

        public Dictionary<string, Town> PlunderCmd (Dictionary<string, Town> dict, string[] arr, string town)
        {
            int people = int.Parse(arr[2]);
            int gold = int.Parse(arr[3]);

            dict[town].TownPopulation -= people;
            dict[town].TownGold -= gold;

            Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
            if (dict[town].TownPopulation <= 0
                || dict[town].TownGold <= 0)
            {
                Console.WriteLine($"{town} has been wiped off the map!");
                dict.Remove(town);
            }

            return dict;
        }

        public Dictionary<string, Town> ProsperCmd (Dictionary<string, Town> dict, string[] arr, string town)
        {
            int gold = int.Parse(arr[2]);

            if (gold < 0)
            {
                Console.WriteLine("Gold added cannot be a negative number!");
            }
            else
            {
                dict[town].TownGold += gold;
                Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {dict[town].TownGold} gold.");
            }
            return dict;
        }
    }
}
