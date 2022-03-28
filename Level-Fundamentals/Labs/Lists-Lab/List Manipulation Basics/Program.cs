using System;
using System.Linq;
using System.Collections.Generic;

namespace List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(x=>int.Parse(x))
                .ToList();

            string command;

            while ((command=Console.ReadLine()) != "end") 
            {
                string[] arr = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (arr[0] == "Add")
                {
                    int numberToAdd = int.Parse(arr[1]);
                    numbers.Add(numberToAdd);
                }
                else if (arr[0] == "Remove")
                {
                    int numberToRemove = int.Parse(arr[1]);
                    numbers.Remove(numberToRemove);
                }
                else if (arr[0] == "RemoveAt")
                {
                    int indexToRemove = int.Parse(arr[1]);
                    numbers.RemoveAt(indexToRemove);
                }
                else if (arr[0] == "Insert")
                {
                    int numberToInsert = int.Parse(arr[1]);
                    int index = int.Parse(arr[2]);
                    numbers.Insert(index, numberToInsert);
                }
            }
            Console.WriteLine(String.Join(" ",numbers));
        }

    }
}
