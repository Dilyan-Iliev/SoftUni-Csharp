using System;
using System.Text.RegularExpressions;

namespace P._02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task - Easter Eggs

            Regex regex = new Regex(@"(@+|#+)(?<egg>[a-z]{3,})(@+|#+)\W*(\/+)(?<letter>\d+)(\/+)");

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input); 

            foreach (Match match in matches)
            {
                string eggColor = match.Groups["egg"].Value;
                string numberOfEggs = match.Groups["letter"].Value;

                if (!match.Success)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($"You found {numberOfEggs} {eggColor} eggs!");
                }
            }

        }
    }
}
