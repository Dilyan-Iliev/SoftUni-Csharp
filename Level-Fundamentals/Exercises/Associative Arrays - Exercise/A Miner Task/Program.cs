using System;
using System.Linq;
using System.Collections.Generic;

namespace A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, int>();

            int count = 1;
            string dictionaryKey = string.Empty;

            string input;
            while ((input = Console.ReadLine()) != "stop")
            {
                if (count % 2 != 0)
                {
                    dictionaryKey = input;
                    if (!dictionary.ContainsKey(dictionaryKey))
                    {
                        dictionary.Add(input, 0); //задавам начална default-на стойност на value-то.
                    }
                 
                }
                else if (count % 2 == 0)
                {
                    int dictionaryValue = int.Parse(input);

                    if (dictionary.ContainsKey(dictionaryKey))
                    {
                        dictionary[dictionaryKey] += dictionaryValue;
                    }
                }
                count++;
            }

            PrintResult(dictionary);
        }

        static void PrintResult(Dictionary<string, int> dictionary)
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
