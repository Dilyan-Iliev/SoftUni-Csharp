namespace _8.Engine
{
    using System;
    using _8.Models;
    using _8.IO.Interfaces;
    using _8.Engine.Interfaces;
    using _8.Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IController controller;

        public Engine(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
            this.controller = new Controller();
        }

        public void Run()
        {
            var carInfo = reader.ReadLine()
                .Split();

            var carFuelQuantity = double.Parse(carInfo[1]);
            var carFuelConsumption = double.Parse(carInfo[2]);

            var truckInfo = reader.ReadLine()
                .Split();

            var truckFuelQuantity = double.Parse(truckInfo[1]);
            var truckFuelConsumption = double.Parse(truckInfo[2]);

            IVehicle car = controller.CreateCar(carFuelQuantity, carFuelConsumption);
            IVehicle truck = controller.CreateTruck(truckFuelQuantity, truckFuelConsumption);

            var numberOfCommands = int.Parse(reader.ReadLine());

            for (int i = 1; i <= numberOfCommands; i++)
            {
                var cmdArgs = reader.ReadLine()
                    .Split();

                var action = cmdArgs[0];
                var vehicleType = cmdArgs[1];

                try
                {
                    if (vehicleType == "Car")
                    {
                        if (action == "Drive")
                        {
                            var distance = double.Parse(cmdArgs[2]);
                            writer.WriteLine(car.Drive(distance));
                        }
                        else if (action == "Refuel")
                        {
                            var fuel = double.Parse(cmdArgs[2]);
                            car.Refuel(fuel);
                        }
                    }
                    else if (vehicleType == "Truck")
                    {
                        if (action == "Drive")
                        {
                            var distance = double.Parse(cmdArgs[2]);
                            writer.WriteLine(truck.Drive(distance));
                        }
                        else if (action == "Refuel")
                        {
                            var fuel = double.Parse(cmdArgs[2]);
                            truck.Refuel(fuel);
                        }
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    writer.WriteLine(ioe.Message);
                }
            }

            writer.WriteLine(car.ToString());
            writer.WriteLine(truck.ToString());
        }
    }
}
