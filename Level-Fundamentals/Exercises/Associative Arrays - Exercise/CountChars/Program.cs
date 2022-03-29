using System;
using System.Linq;
using System.Collections.Generic;

namespace Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var dictionary = new Dictionary<char, int>();

            foreach (var word in words)
            {
                char[] wordLetters = word.ToCharArray();

                foreach (char letter in wordLetters)
                {
                    if (!dictionary.ContainsKey(letter))
                    {
                        dictionary[letter] = 1;
                    }
                    else
                    {
                        dictionary[letter]++;
                    }
                }
            }

            PrintResult(dictionary);
        }

        static void PrintResult(Dictionary<char, int> dictionary)
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
