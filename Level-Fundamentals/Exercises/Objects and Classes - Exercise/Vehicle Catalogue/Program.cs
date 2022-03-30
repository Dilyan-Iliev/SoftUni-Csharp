using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Vehicles> vehicles = new List<Vehicles>();

            double carsTotalHorsePower = 0;
            double trucksTotalHorsePower = 0;
            double carsCounter = 0;
            double trucksCounter = 0;

            
            while (true)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split()
                    .ToArray();
                if (inputArgs[0] == "End")
                {
                    break;
                }

                string vehicleType = inputArgs[0];
                string model = inputArgs[1];
                string color = inputArgs[2];
                double horsePower = double.Parse(inputArgs[3]);

                if (vehicleType == "car")
                {
                    vehicleType = "Car";
                    carsCounter++;
                    carsTotalHorsePower += horsePower;
                }
                if (vehicleType == "truck")
                {
                    vehicleType = "Truck";
                    trucksCounter++;
                    trucksTotalHorsePower += horsePower;
                }

                Vehicles vehicle = new Vehicles(vehicleType, model, color, horsePower);
                vehicles.Add(vehicle);
            }

            //string modelsOfVehicles;
            while (true)
            {
                string model = Console.ReadLine();

                if (model == "Close the Catalogue")
                {
                    double averageCarsHorsePower = carsTotalHorsePower / carsCounter;
                    double averageTrucksHorsePower = trucksTotalHorsePower / trucksCounter;
                    double averageCar = carsTotalHorsePower / carsCounter;
                    double averageTruck = trucksTotalHorsePower / trucksCounter;

                    if (averageCarsHorsePower >0 && averageTrucksHorsePower > 0)
                    {
                        Console.WriteLine($"Cars have average horsepower of: {averageCar:F2}.");
                        Console.WriteLine($"Trucks have average horsepower of: {averageTruck:F2}.");
                        break;
                    }
                    else if (trucksCounter == 0)
                    {
                        Console.WriteLine($"Cars have average horsepower of: {averageCar:F2}.");
                        Console.WriteLine($"Trucks have average horsepower of: {averageTruck:F2}.");
                        break;
                    }
                    else if (carsCounter == 0)
                    {
                        Console.WriteLine($"Cars have average horsepower of: {averageCar:F2}.");
                        Console.WriteLine($"Trucks have average horsepower of: {averageTruck:F2}.");
                        break;
                    }

                }
                foreach (var item in vehicles)
                {
                    if (item.Model == model)
                    {
                        Console.WriteLine($"Type: {item.VehicleType}");
                        Console.WriteLine($"Model: {item.Model}");
                        Console.WriteLine($"Color: {item.Color}");
                        Console.WriteLine($"Horsepower: {item.HorsePower}");
                    }
                }
            }

            //double averageCarsHorsePower = carsTotalHorsePower / carsCounter;
            //double averageTrucksHorsePower = trucksTotalHorsePower / trucksCounter;

            //Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsePower:F2}.");
            //Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsePower:F2}.");
        }
    }
}

class Vehicles
{
    public Vehicles(string vehicleType, string model, string color, double horsePower)
    {
        VehicleType = vehicleType;
        Model = model;
        Color = color;
        HorsePower = horsePower;
    }
    public string VehicleType { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public double HorsePower { get; set; }

    public override string ToString()
    {
        return $"Type: {VehicleType} Model: {Model} Color: {Color} Horsepower: {HorsePower}";
    }
}

