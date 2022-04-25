using System;
using System.Linq;
using System.Collections.Generic;

namespace P._10_The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var dictionary = new Dictionary<string, Predicate<string>>();

            string input;

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] inputArgs = input
                        .Split(';', StringSplitOptions.RemoveEmptyEntries);

                string command = inputArgs[0];
                string filterType = inputArgs[1];
                string filterParameter = inputArgs[2];

                string key = filterType + "_" + filterParameter;

                if (command == "Add filter")
                {
                    Predicate<string> predicate = GetPredicate(filterType, filterParameter);
                    dictionary.Add(key, predicate);
                }
                else if (command == "Remove filter")
                {
                    dictionary.Remove(key);
                }
            }

            foreach (var (key, predicate) in dictionary)
            {
                names.RemoveAll(predicate);
            }

            Console.WriteLine(string.Join(" ", names));

            static Predicate<string> GetPredicate(string cmdType, string arg)
            {
                if (cmdType == "Starts with")
                {
                    return x => x.StartsWith(arg);
                }
                else if (cmdType == "Ends with")
                {
                    return x => x.EndsWith(arg);
                }
                else if (cmdType == "Contains")
                {
                    return x => x.Contains(arg);
                }

                int length = int.Parse(arg);
                return x => x.Length == length;
            }
        }
    }
}
