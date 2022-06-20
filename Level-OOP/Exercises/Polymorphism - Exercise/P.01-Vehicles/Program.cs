using System;

namespace Vehicles
{
    public class StartUp
    {
        //109.64
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] truckData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double carFuel = double.Parse(carData[1]);
            double carLitersPerKm = double.Parse(carData[2]);

            double truckFuel = double.Parse(truckData[1]);
            double truckLitersPerKm = double.Parse(truckData[2]);

            Car car = new Car(carFuel, carLitersPerKm);
            Truck truck = new Truck(truckFuel, truckLitersPerKm);

            int lines = int.Parse(Console.ReadLine());

            for (int i = 1; i <= lines; i++)
            {
                try
                {
                    string[] input = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string command = input[0];
                    string vehicleType = input[1];

                    string result = string.Empty;

                    switch (vehicleType)
                    {
                        case "Car":
                            if (command == "Drive")
                            {
                                result = car.Drive(double.Parse(input[2]));
                                PrintResult(result);
                            }
                            else if (command == "Refuel")
                            {
                                car.Refuel(double.Parse(input[2]));
                            }
                            break;
                        case "Truck":
                            if (command == "Drive")
                            {
                                result = truck.Drive(double.Parse(input[2]));
                                PrintResult(result);
                            }
                            else if (command == "Refuel")
                            {
                                truck.Refuel(double.Parse(input[2]));
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }

        static void PrintResult(string result)
        {
            Console.WriteLine(result);
        }
    }
}
