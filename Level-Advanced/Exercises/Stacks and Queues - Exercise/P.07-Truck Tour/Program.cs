using System;
using System.Linq;
using System.Collections.Generic;

namespace P._07_Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> truckTour = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse).ToArray();

                int amountOfPetrol = input[0];
                int distance = input[1];

                truckTour.Enqueue(new int[] {amountOfPetrol, distance}); //ше вкара amountOfPetrol и distance понеже имаме масив в опашката
            }

            int startIndex = 0;

            while (true)
            {
                int currentPetrol = 0;

                foreach (var item in truckTour) //item ще е int array
                {
                    int truckPetrol = item[0];
                    int truckDistance = item[1];

                    currentPetrol += truckPetrol;
                    currentPetrol -= truckDistance;

                    if (currentPetrol - truckDistance < 0)
                    {
                        int[] element = truckTour.Dequeue();
                        truckTour.Enqueue(element);
                        startIndex++;
                        break;
                    }
                }

                if (currentPetrol >= 0)
                {
                    Console.WriteLine(startIndex);
                    break;
                }
            }
        }
    }
}
