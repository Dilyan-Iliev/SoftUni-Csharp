using System;
using System.Linq;
using System.Collections.Generic;

namespace Need_for_Speed_III
{
    internal class Program
    {
        static int maxMileageOfACar = 100000;
        static int maxFuelCapacityOfACar = 75;
        static int minMileageOfACar = 10000;
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, Car>();
            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfCars; i++)
            {
                string[] carsInfo = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);
                string carModel = carsInfo[0];
                int carDistance = int.Parse(carsInfo[1]);
                int carFuel = int.Parse(carsInfo[2]);

                if (!dictionary.ContainsKey(carModel))
                {
                    var car = new Car(carDistance, carFuel);
                    dictionary[carModel] = car;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                DictionaryCmds(dictionary, cmdArgs);
            }
            PrintDictionary(dictionary);
        }

        static Dictionary<string, Car> DictionaryCmds(Dictionary<string, Car> dict, string[] arr)
        {
            string command = arr[0];
            string carModel = arr[1];

            switch (command)
            {
                case "Drive": DriveCmd(dict, arr, carModel); break;
                case "Refuel": RefuelCmd(dict, arr, carModel); break;
                case "Revert": RevertCmd(dict, arr, carModel); break;
            }
            return dict;
        }

        static Dictionary<string, Car> DriveCmd(Dictionary<string, Car> dict, string[] arr, string carModel)
        {
            int distance = int.Parse(arr[2]);
            int fuel = int.Parse(arr[3]);

            if (dict[carModel].CarFuel >= fuel)
            {
                dict[carModel].CarFuel -= fuel;
                dict[carModel].CarMileage += distance;

                Console.WriteLine($"{carModel} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                if (dict[carModel].CarMileage >= maxMileageOfACar)
                {
                    Console.WriteLine($"Time to sell the {carModel}!");
                    dict.Remove(carModel);
                }
            }
            else
            {
                Console.WriteLine("Not enough fuel to make that ride");
            }

            return dict;
        }

        static Dictionary<string, Car> RefuelCmd(Dictionary<string, Car> dict, string[] arr, string carModel)
        {
            int fuel = int.Parse(arr[2]);

            if (dict[carModel].CarFuel + fuel > maxFuelCapacityOfACar)
            {
                Console.WriteLine($"{carModel} refueled with {maxFuelCapacityOfACar - dict[carModel].CarFuel} liters");
                dict[carModel].CarFuel = maxFuelCapacityOfACar;
            }
            else
            {
                dict[carModel].CarFuel += fuel;
                Console.WriteLine($"{carModel} refueled with {fuel} liters");
            }

            return dict;
        }

        static Dictionary<string, Car> RevertCmd(Dictionary<string, Car> dict, string[] arr, string carModel)
        {
            int kilometers = int.Parse(arr[2]);

            dict[carModel].CarMileage -= kilometers;
            if (dict[carModel].CarMileage >= minMileageOfACar)
            {
                Console.WriteLine($"{carModel} mileage decreased by {kilometers} kilometers");
            }
            else if (dict[carModel].CarMileage < minMileageOfACar)
            {
                dict[carModel].CarMileage = minMileageOfACar;
            }

            return dict;
        }

        static void PrintDictionary(Dictionary<string, Car> dict)
        {
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} -> Mileage: {kvp.Value.CarMileage} kms, Fuel in the tank: {kvp.Value.CarFuel} lt.");
            }
        }
    }

    public class Car
    {
        public Car(int distance, int fuel)
        {
            this.CarMileage = distance;
            this.CarFuel = fuel;
        }
        public int CarMileage { get; set; }
        public int CarFuel { get; set; }

    }
}
