using System;
using System.Linq;
using System.Collections.Generic;

namespace P._04_Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            for (int i = 1; i <= numberOfLines; i++)
            {
                string line = Console.ReadLine();

                if (!dictionary.ContainsKey(line))
                {
                    dictionary[line] = 0;
                }
                dictionary[line]++;
            }
            
            foreach (var kvp in dictionary
                .Where(x => x.Value % 2 == 0)) 
                //filters only the keys which are presented even number of times in the dictionary
            {
                Console.WriteLine(kvp.Key);
            }
        }
    }
}
