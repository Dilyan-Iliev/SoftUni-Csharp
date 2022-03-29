using System;
using System.Linq;
using System.Collections.Generic;

namespace Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ');

            var dictionary = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string currentWord = word.ToLower();
                if (dictionary.ContainsKey(currentWord)) //това е key във речника
                {
                    dictionary[currentWord]++; //ако ключът го има, увеличаваме стойността с 1
                }
                else
                {
                    dictionary[currentWord] = 1; //ако ключът го няма, слагаме начална стойност 1
                }
            }
            var list = new List<string>();
            foreach (var word in dictionary)
            {
                if (word.Value % 2 != 0)
                {
                    list.Add(word.Key);
                }
            }
            Console.WriteLine(String.Join(" ", list));
        }
    }
}
