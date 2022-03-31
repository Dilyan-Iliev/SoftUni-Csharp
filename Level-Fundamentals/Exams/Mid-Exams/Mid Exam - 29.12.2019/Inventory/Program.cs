using System;
using System.Linq;
using System.Collections.Generic;

namespace Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;

            while ((command=Console.ReadLine()) != "Craft!")
            {
                string[] cmdArgs = command.Split(" - ");

                string currentCommand = cmdArgs[0];
                string currentItem = cmdArgs[1];

                if(currentCommand == "Collect")
                {
                    //string itemToCollect = cmdArgs[1];

                    if (!items.Contains(currentItem))
                    {
                        items.Add(currentItem);
                    }
                }
                else if (currentCommand == "Drop")
                {
                    //string itemToDrop = cmdArgs[1];

                    if (items.Contains(currentItem))
                    {
                        items.Remove(currentItem);
                    }
                }
                else if (currentCommand == "Combine Items")
                {
                    string[] itemsToCombine = currentItem.Split(':');

                    string oldItem = itemsToCombine[0];
                    string newItem = itemsToCombine[1];

                    if (items.Contains(oldItem))
                    {
                        items.Insert(items.IndexOf(oldItem)+1, newItem);
                    }
                }
                else if (currentCommand == "Renew")
                {
                    if (items.Contains(currentItem))
                    {
                        items.Insert(items.Count, currentItem);
                        items.Remove(currentItem);
                    }
                }
            }
            Console.WriteLine(String.Join(", ",items));
        }


        //static List<string> CommandCollect(List<string> list, string[] cmdArgs)
        //{
        //    string itemToCollect = cmdArgs[1];

        //    if (!list.Contains(itemToCollect))
        //    {
        //        list.Add(itemToCollect);
        //    }

        //    return list;
        //}

        //static List<string> CommandDrop(List<string> list, string[] cmdArgs)
        //{
        //    string itemToDrop = cmdArgs[1];

        //    if (list.Contains(itemToDrop))
        //    {
        //        list.Remove(itemToDrop);
        //    }

        //    return list;
        //}
    }
}
