using System;
using System.Linq;
using System.Collections.Generic;

namespace Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacityOfEachWagon = int.Parse(Console.ReadLine());

            string command;

            while ((command=Console.ReadLine())!="end")
            {
                string[] arr = command.Split(); //масив от командата

                if (arr[0] == "Add")
                {
                    wagons.Add(int.Parse(arr[1]));
                }
                else //ако arr[0] не е текст, а е число
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if(wagons[i] + int.Parse(arr[0]) > maxCapacityOfEachWagon)
                        {
                            continue; //в случай, че в съответния вагон няма място за целия вход - arr[0]
                        }
                        else
                        {
                            wagons[i] += int.Parse(arr[0]);
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(String.Join(" ",wagons));
        }
    }
}
