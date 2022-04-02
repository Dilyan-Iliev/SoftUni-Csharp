using System;
using System.Text.RegularExpressions;

namespace Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(#|\|)(?<product>[[A-Z][a-z]+\s?[A-Za-z]+?)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1";
            // or @"(#|\|)(?<product>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            int sumOfCalories = 0;

            foreach (Match match in matches)
            {
                string product = match.Groups["product"].Value;
                string expireDate = match.Groups["date"].Value;
                int calories = int.Parse(match.Groups["calories"].Value);

                sumOfCalories += calories;
            }

            int daysWithFood = sumOfCalories / 2000;

            Console.WriteLine($"You have food to last you for: {daysWithFood} days!");

            foreach (Match match in matches)
            {
                string product = match.Groups["product"].Value;
                string expireDate = match.Groups["date"].Value;
                int calories = int.Parse(match.Groups["calories"].Value);

                Console.WriteLine($"Item: {product}, Best before: {expireDate}, Nutrition: {calories}");
            }
        }
    }
}
