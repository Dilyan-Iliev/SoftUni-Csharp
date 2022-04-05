using System;
using System.Collections.Generic;

namespace P._08_TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCarsToPass = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int count = 0;

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < numberOfCarsToPass; i++)
                    {
                        if (cars.Count > 0)
                        {
                            string carToPass = cars.Dequeue();
                            Console.WriteLine($"{carToPass} passed!");
                            count++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
