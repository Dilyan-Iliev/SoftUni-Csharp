using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();
            string input = Console.ReadLine();
            string pattern = @"([=\/])(?<destination>[A-Z][A-Za-z]{2,})\1";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            int travelPts = 0;
            foreach (Match match in matches)
            {
                string currentDestination = match.Groups["destination"].Value;
                if (!list.Contains(currentDestination))
                {
                    list.Add(currentDestination);
                    travelPts += currentDestination.Length;
                }
            }

            Console.WriteLine($"Destinations: {string.Join(", ", list)}");
            Console.WriteLine($"Travel Points: {travelPts}");
            
        }
    }
}
