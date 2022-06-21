using System;

namespace VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] truckData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] busData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double carFuel = double.Parse(carData[1]);
            double carLitersPerKm = double.Parse(carData[2]);
            double carCarTankCapacity = double.Parse(carData[3]);

            double truckFuel = double.Parse(truckData[1]);
            double truckLitersPerKm = double.Parse(truckData[2]);
            double truckTankCapacity = double.Parse(truckData[3]);

            double busFuel = double.Parse(busData[1]);
            double busLitersPerKm = double.Parse(busData[2]);
            double busTankCapacity = double.Parse(busData[3]);

            Vehicle car = new Car(carFuel, carLitersPerKm, carCarTankCapacity);
            Vehicle truck = new Truck(truckFuel, truckLitersPerKm, truckTankCapacity);
            Vehicle bus = new Bus(busFuel, busLitersPerKm, busTankCapacity);

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
                        case "Bus":
                            if (command == "Drive")
                            {
                                result = bus.Drive(double.Parse(input[2]));
                                PrintResult(result);
                            }
                            else if (command == "Refuel")
                            {
                                bus.Refuel(double.Parse(input[2]));
                            }
                            else if (command == "DriveEmpty")
                            {
                                result = bus.Drive(double.Parse(input[2]));
                                PrintResult(result);
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
            Console.WriteLine(bus.ToString());
        }

        static void PrintResult(string result)
        {
            Console.WriteLine(result);
        }
    }
}
