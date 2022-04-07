using System;
using System.Linq;
using System.Collections.Generic;

namespace P._10_Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int durationOfGreenLight = int.Parse(Console.ReadLine());
            int durationOfFreeWindow = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();

            int passedCarsCounter = 0;
            bool isHitted = false;

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                //During the green light cars will enter and exit the crossroads one by one
                // During the free window cars will only exit the crossroads

                if (input == "green")
                {
                    int greenLightTime = durationOfGreenLight;

                    while (queue.Any() && greenLightTime > 0)
                    {
                        string currentCarAtQueue = queue.Dequeue();

                        if (greenLightTime + durationOfFreeWindow - currentCarAtQueue.Length >= 0)
                        {
                            greenLightTime -= currentCarAtQueue.Length;
                            passedCarsCounter++;
                            continue;
                        }

                        if (currentCarAtQueue.Length - greenLightTime + durationOfFreeWindow >= 0)
                        {
                            greenLightTime = 0;
                            passedCarsCounter++;
                            continue;
                        }

                        string hittedChar = currentCarAtQueue.Substring(greenLightTime + durationOfFreeWindow, 1);

                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currentCarAtQueue} was hit at {hittedChar}");
                        isHitted = true;
                        Environment.Exit(0);
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }
            if (!isHitted)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCarsCounter} total cars passed the crossroads.");
            }
        }
    }
}
