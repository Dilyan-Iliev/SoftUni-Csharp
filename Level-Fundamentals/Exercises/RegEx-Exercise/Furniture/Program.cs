using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();
            double sum = 0;

            var pattern = new Regex(@">>(?<furniture>([A-Z]+[a-z]+)|([A-Z]+))<<((?<price>\d+\.?(\d+)?)\!(?<quantity>\d+))");
            // or new Regex(@">>(?<furniture>([A-Za-z]+))<<((?<price>\d+\.?(\d+)?)\!(?<quantity>\d+))");

            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                var matches = pattern.Matches(input);

                foreach (Match match in matches)
                {
                    string furnitureType = match.Groups["furniture"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    sum += price * quantity;

                    list.Add(furnitureType);
                }
            }

            PrintList(list, sum);
        }

        static void PrintList(List<string> list, double sum)
        {
            Console.WriteLine("Bought furniture:");
            if (list.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, list));
            }
            Console.WriteLine($"Total money spend: {sum:F2}");
        }
    }
}
