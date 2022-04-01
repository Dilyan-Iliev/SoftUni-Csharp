using System;
using System.Linq;
using System.Collections.Generic;

namespace Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> products = Console.ReadLine()
                .Split('!', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "Go Shopping!")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                products = ListCommands(products, cmdArgs);
            }

            Console.WriteLine(string.Join(", ",products));
        }

        static List<string> ListCommands (List<string> list, string[] cmdArgs)
        {
            string currentCommand = cmdArgs[0];

            switch (currentCommand)
            {
                case "Urgent": list = UrgentCmd(list, cmdArgs); break;
                case "Unnecessary": list = UnnecessaryCmd(list, cmdArgs); break;
                case "Correct": list = CorrectCmd(list, cmdArgs); break;    
                case "Rearrange": list = RearrangeCmd(list, cmdArgs); break;
            }
            return list;
        }

        static List<string> UrgentCmd (List<string> list, string[] cmdArgs)
        {
            //add the item at the start of the list.  If the item already exists, skip this command.
            string itemToAdd = cmdArgs[1];

            if (!list.Contains(itemToAdd))
            {
                list.Insert(0,itemToAdd);
            }
            return list;
        }

        static List<string> UnnecessaryCmd (List<string> list, string[] cmdArgs)
        {
            //remove the item with the given name, only if it exists in the list. Otherwise, skip this command.
            string itemToRemove = cmdArgs[1];

            if (list.Contains(itemToRemove))
            {
                list.Remove(itemToRemove);
            }
            return list;
        }

        static List<string> CorrectCmd (List<string> list, string[] cmdArgs)
        {
            // if the item with the given old name exists, change its name with the new one. Otherwise, skip this command
            string oldItem = cmdArgs[1];
            string newItem = cmdArgs[2];

            int index = list.IndexOf(oldItem);
            if (list.Contains(oldItem))
            {
                string currentItem = newItem;
                //newItem = oldItem;
                list.Insert(index, currentItem);
                list.Remove(oldItem);
            }
            return list;
        }

        static List<string> RearrangeCmd (List<string> list, string[] cmdArgs)
        {
            //if the grocery exists in the list, remove it from its current position and add it at the end of the list. Otherwise, skip this command
            string item = cmdArgs[1];

            if (list.Contains(item))
            {
            list.Remove(item);
            list.Add(item);
            }

            return list;
        }
    }
}
