using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            var dictionary = new Dictionary<string, string>();

            for (int i = 1; i <= numberOfLines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                dictionary = DictionaryOperations(input, dictionary);


            }
            PrintDictionary(dictionary);
        }

        static Dictionary<string, string> DictionaryOperations(string[] arr, Dictionary <string, string> dictionary)
        {
            string cmd = arr[0];
            switch (cmd)
            {
                case "register": RegisterCmd(arr, dictionary); break;
                case "unregister": UnregisterCmd(arr, dictionary) ; break;
            }

            return dictionary;
        }

        static void RegisterCmd(string[] arr, Dictionary <string, string> dictionary)
        {
            string user = arr[1];
            string licenseID = arr[2];

            if (!dictionary.ContainsKey(user))
            {
                dictionary[user] = licenseID;
                Console.WriteLine($"{user} registered {licenseID} successfully");
            }
            else if (dictionary.ContainsKey(user))
            {
                Console.WriteLine($"ERROR: already registered with plate number {licenseID}");
            }
        }

        static void UnregisterCmd(string[] arr, Dictionary <string, string> dictionary)
        {
            string user = arr[1];
            if (!dictionary.ContainsKey(user))
            {
                Console.WriteLine($"ERROR: user {user} not found");
            }
            else if (dictionary.ContainsKey(user))
            {
                dictionary.Remove(user);
                Console.WriteLine($"{user} unregistered successfully");
            }
        }

        static void PrintDictionary(Dictionary <string, string> dictionary)
        {
            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
