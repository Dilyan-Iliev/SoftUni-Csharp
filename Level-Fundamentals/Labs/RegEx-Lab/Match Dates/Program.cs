using System;
using System.Text.RegularExpressions;

namespace Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dates = Console.ReadLine();

            var regex = new Regex(@"\b(?<day>\d{2})(-|.|\/)(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b");

            var matches = regex.Matches(dates);

            foreach (Match match in matches)
            {
                var day = match.Groups["day"].Value;
                var month = match.Groups["month"].Value;
                var year = match.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
