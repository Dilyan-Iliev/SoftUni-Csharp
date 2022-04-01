using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Mirror_words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();

            string input = Console.ReadLine();

            string pattern = @"(\@|\#)(?<firstWord>[A-Za-z]{3,})\1\1(?<secondWord>[A-Za-z]{3,})\1";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                string word = match.Groups["firstWord"].Value;
                string secondWord = match.Groups["secondWord"].Value;

                string reverseSecondWord = string.Join("", secondWord.Reverse());

                if (word == reverseSecondWord)
                {
                    string result = word + " <=> " + secondWord;
                    list.Add(result);
                }
            }

            int correctWordsCounter = matches.Count;
            CheckForCorrectWords(ref correctWordsCounter);

            PrintList(list);

        }

        static int CheckForCorrectWords(ref int counter)
        {
            if (counter == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{counter} word pairs found!");
            }

            return counter;
        }

        static List<string> PrintList(List<string> list)
        {
            if (list.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", list));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }

            return list;
        }
    }
}
