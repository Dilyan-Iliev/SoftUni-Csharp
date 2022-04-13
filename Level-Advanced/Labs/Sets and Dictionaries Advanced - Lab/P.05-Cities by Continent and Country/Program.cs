using System;
using System.Linq;
using System.Collections.Generic;

namespace P._05_Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dictionary = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 1; i <= n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string continent = info[0];
                string country = info[1];
                string city = info[2];

                if (!dictionary.ContainsKey(continent))
                {
                    dictionary[continent] = new Dictionary<string, List<string>>();
                }

                if (!dictionary[continent].ContainsKey(country))
                {
                    dictionary[continent][country] = new List<string>();
                    dictionary[continent][country].Add(city);
                }
                else
                {
                    dictionary[continent][country].Add(city);
                }
            }
            foreach (var continent in dictionary)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
