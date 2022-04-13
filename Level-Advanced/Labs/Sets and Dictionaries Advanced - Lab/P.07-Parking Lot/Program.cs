using System;
using System.Collections.Generic;

namespace P._07_Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string direction = inputArgs[0];
                string carNumber = inputArgs[1];

                if (direction == "IN")
                {
                    set.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    set.Remove(carNumber);
                }
            }

            if (set.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var carNumber in set)
                {
                    Console.WriteLine(carNumber);
                }
            }
        }
    }
}
