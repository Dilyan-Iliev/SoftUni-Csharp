using System;
using System.Linq;
using System.Collections.Generic;

namespace Treasure_Hunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "Yohoho!")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string currentCommand = cmdArgs[0];

                if (currentCommand == "Loot")
                {
                    //Pick up treasure loot along the way. Insert the items at the beginning of the chest
                    //If an item is already contained, don't insert it

                    for (int i = 1; i < cmdArgs.Length; i++)
                    {
                        if (!items.Contains(cmdArgs[i]))
                        {
                            items.Insert(0, cmdArgs[i]);
                        }
                    }
                }
                else if (currentCommand == "Drop")
                {
                    //Remove the loot at the given position and add it at the end of the treasure chest. 
                    //If the index is invalid, skip the command
                    int index = int.Parse(cmdArgs[1]);

                    if (index < 0 || index > items.Count - 1)
                    {
                        continue;
                    }
                    string currentItem = items.ElementAt(index);
                    items.Remove(currentItem);
                    items.Add(currentItem);
                }
                else if (currentCommand == "Steal")
                {
                    //Someone steals the last count loot items. If there are fewer items than the given count, remove as much as there are. 
                    //Print the stolen items separated by ", ":

                    int count = int.Parse(cmdArgs[1]);
                    List<string> stolenItems = new List<string>();

                    if (count < items.Count)
                    {
                        for (int i = items.Count - count; i < items.Count; i++)
                        {
                            stolenItems.Add(items[i]);
                        }
                        Console.WriteLine(String.Join(", ", stolenItems));
                        items.RemoveRange(items.Count - count, count);
                    }
                    else
                    {
                        for (int i = 0; i < items.Count; i++)
                        {
                            stolenItems.Add(items[i]);
                        }
                        Console.WriteLine(String.Join(", ", stolenItems));
                        items.RemoveRange(0, items.Count);
                    }
                }
            }

            if (items.Count > 0)
            {
                int sumItemsLength = 0;

                for (int i = 0; i < items.Count; i++)
                {
                    sumItemsLength += items[i].Length;
                }

                double finalResult = (double)sumItemsLength / items.Count;
                Console.WriteLine($"Average treasure gain: {finalResult:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
