using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string numbersPattern = @"(?<number>\d)";
            string emojiPattern = @"([:]{2}|[*]{2})(?<name>[A-Z][a-z]{2,})\1";


            //Regex numbersRegex = new Regex(numbersPattern);
            //Regex emojiRegex = new Regex(emojiPattern);

            //or

            MatchCollection numberMatches = Regex.Matches(input, numbersPattern);
            MatchCollection emojiMatches = Regex.Matches(input, emojiPattern);

            int numbersSum = 1;

            foreach (Match match in numberMatches)
            {
                numbersSum *= int.Parse(match.Groups["number"].Value);
            }

            var importantEmojis = new List<string>();

            int counter = 0;
            foreach (Match match in emojiMatches)
            {
                int emojiSum = 0;
                string currentEmoji = match.Value;
                for (int i = 0; i < currentEmoji.Length; i++)
                {
                    if (char.IsLetter(currentEmoji[i]))
                    {
                    emojiSum += currentEmoji[i];
                    }
                }
                if (emojiSum > numbersSum)
                {
                    importantEmojis.Add(currentEmoji);
                }
                counter++;
            }

            Console.WriteLine($"Cool threshold: {numbersSum}");
            Console.WriteLine($"{counter} emojis found in the text. The cool ones are:");
            foreach (var item in importantEmojis)
            {
                Console.WriteLine(item);
            }
        }
    }
}
