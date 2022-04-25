using System;
using System.Linq;
using System.Collections.Generic;

namespace P._09_Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "Party!")
            {
                var cmdArgs = command.Split().ToList();

                string currentCmd = cmdArgs[0];

                Predicate<string> predicate = GetPredicate(cmdArgs[1], cmdArgs[2]);

                if (currentCmd == "Remove")
                {
                    names.RemoveAll(predicate);
                }
                else if (currentCmd == "Double")
                {
                    var doubledNames = names.FindAll(predicate);
                    if (doubledNames.Any())
                    {
                        int index = names.FindIndex(predicate);
                        names.InsertRange(index, doubledNames);
                    }
                }
            }

            if (names.Any())
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
        static Predicate<string> GetPredicate(string cmdType, string arg)
        {
            switch (cmdType)
            {
                case "StartsWith": return name => name.StartsWith(arg);
                case "EndsWith": return name => name.EndsWith(arg);
                case "Length": return name => name.Length == int.Parse(arg);
                default:
                    return null;
            }
        }
    }
}
