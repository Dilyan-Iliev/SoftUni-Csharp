using System;
using System.Linq;
using System.Collections.Generic;

namespace Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            
            var dictionary = new Dictionary<string, List<string>>();

            for (int i = 1; i <= numberOfLines; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!dictionary.ContainsKey(word))
                {//ако ключът го няма в речника, за него създавам нов списък, в който добавям стойностите
                    dictionary[word] = new List<string>();
                    dictionary[word].Add(synonym);
                }
                else
                {//ако ключът го има в речника, то за него има създаден списък, добавям стойността в списъка
                    dictionary[word].Add(synonym);
                }
            }
            foreach (var word in dictionary)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }
        }
    }
}
