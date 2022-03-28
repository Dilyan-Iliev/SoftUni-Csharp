using System;
using System.Linq;
using System.Collections.Generic;

namespace HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();

            while (numberOfCommands>0)
            {
                string currentComand = Console.ReadLine();
                string[] arr = currentComand.Split();
                //string remover = currentComand.Remove(currentComand.Length - 1); //всеки път ще премаха знакът ! от командата ако е даден със space
                //string[] arr = remover.Split();

                if (arr[2] == "going!")
                {
                    bool isTheSame = names.Contains(arr[0]);
                    if (isTheSame == true)
                    {
                        Console.WriteLine($"{arr[0]} is already in the list!");
                    }
                    else
                    {
                    names.Add(arr[0]);
                    }
                }
                else if (arr[2] == "not")
                {
                    bool isTheSame = names.Contains(arr[0]);
                    if (isTheSame == true)
                    {
                        names.Remove(arr[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{arr[0]} is not in the list!");
                    }
                }
                numberOfCommands--;
            }
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
}
