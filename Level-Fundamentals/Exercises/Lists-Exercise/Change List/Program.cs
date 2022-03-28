using System;
using System.Linq;
using System.Collections.Generic;
namespace Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> numbers = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command;

            while ((command=Console.ReadLine()) != "end")
            {
                string[] arr = command.Split();

                if (arr[0] == "Delete")
                {
                    int numberToDelete = int.Parse(arr[1]);
                    numbers.RemoveAll(x => x == numberToDelete);
                }
                else if (arr[0] == "Insert")
                {
                    int itemToInsert = int.Parse(arr[1]);
                    int indexToBeInsertedOn = int.Parse(arr[2]);
                    numbers.Insert(indexToBeInsertedOn, itemToInsert);
                }
            }
            Console.WriteLine(String.Join(" ",numbers));
        }
    }
}
