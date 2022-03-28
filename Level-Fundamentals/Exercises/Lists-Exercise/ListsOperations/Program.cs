using System;
using System.Linq;
using System.Collections.Generic;

namespace ListsOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] arr = command.Split();

                if (arr[0] == "Add")
                {
                    int numberToAdd = int.Parse(arr[1]);
                    numbers.Add(numberToAdd);
                }
                else if (arr[0] == "Insert")
                {
                    int numberToInsert = int.Parse(arr[1]);
                    int index = int.Parse(arr[2]);
                    if (index>=0 && index < numbers.Count)
                    {

                    numbers.Insert(index, numberToInsert);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (arr[0] == "Remove")
                {
                    int indexToRemove = int.Parse(arr[1]);
                    if (indexToRemove >=0 && indexToRemove < numbers.Count)
                    {
                    numbers.RemoveAt(indexToRemove);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (arr[0] == "Shift")
                {
                    int numbersOfShifts = int.Parse(arr[2]);

                    if (arr[1] == "left")
                    {
                        while (numbersOfShifts>0)
                        {
                            int currentFirstElement = numbers[0];
                            numbers.Add(currentFirstElement);//елементът на нулева позиция чрез Add Отива най-отзад
                            numbers.RemoveAt(0);//след този елемент, който е бил на 0лева позиция и е отишъл най-отзад, го махам от 0левата позиция
                            numbersOfShifts--;
                        }
                    }
                    else //arr[1] == "right"
                    {
                        while (numbersOfShifts > 0)
                        {
                            int currentLastElement = numbers[numbers.Count - 1];
                            numbers.Insert(0, currentLastElement);
                            numbers.RemoveAt(numbers.Count-1);
                            numbersOfShifts--;
                        }
                    }
                }
            }
            Console.WriteLine(String.Join(" ",numbers));
        }
    }
}
