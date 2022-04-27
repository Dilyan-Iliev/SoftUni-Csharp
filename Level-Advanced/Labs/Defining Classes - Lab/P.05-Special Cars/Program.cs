using System;
using System.Linq;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string tiresInfoInput;
            List<Tire> tires = new List<Tire>();

            while ((tiresInfoInput = Console.ReadLine()) != "No more tires")
            {
                string[] tiresInfoInputArgs = tiresInfoInput
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int year = 0;
                double pressure = 0;
                for (int i = 0; i < tiresInfoInputArgs.Length; i += 2)
                {
                    year += int.Parse(tiresInfoInputArgs[i]);
                    pressure += double.Parse(tiresInfoInputArgs[i + 1]);
                }

                Tire tire = new Tire(year, pressure);
                tires.Add(tire);
            }

            string enginesInfoInput;
            List<Engine> engines = new List<Engine>();

            while ((enginesInfoInput = Console.ReadLine()) != "Engines done")
            {
                string[] enginesInfoInputArgs = enginesInfoInput
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < enginesInfoInputArgs.Length; i += 2)
                {
                    int horsePower = int.Parse(enginesInfoInputArgs[i]);
                    double cubicCapacity = double.Parse(enginesInfoInputArgs[i + 1]);

                    var engine = new Engine(horsePower, cubicCapacity);
                    engines.Add(engine);
                }
            }

            string carsInfoInput;
            List<Car> cars = new List<Car>();

            while ((carsInfoInput = Console.ReadLine()) != "Show special")
            {
                string[] carsInfoInputArgs = carsInfoInput
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string carMake = carsInfoInputArgs[0];
                string carModel = carsInfoInputArgs[1];
                int carYear = int.Parse(carsInfoInputArgs[2]);
                double fuelQuantity = double.Parse(carsInfoInputArgs[3]);
                double fuelConsumption = double.Parse(carsInfoInputArgs[4]);
                int engineIndex = int.Parse(carsInfoInputArgs[5]);
                int tiresIndex = int.Parse(carsInfoInputArgs[6]);

                var car = new Car(carMake, carModel, carYear, fuelQuantity,
                    fuelConsumption, engines[engineIndex], tires[tiresIndex]);

                cars.Add(car);
            }

            PrintOutput(cars);
        }

        private static void PrintOutput(List<Car> cars)
        {
            foreach (var car in cars)
            {
                if (car.Year >= 2017 && car.EngineIndex.HorsePower > 330
                    && (car.TiresIndex.Pressure >= 9 && car.TiresIndex.Pressure <= 10))
                {
                    //Console.WriteLine(car.ToString());

                    //or

                    car.FuelQuantity = car.Drive20Kilometers(car.FuelQuantity, car.FuelConsumption);
                    Console.WriteLine($"Make: {car.Make}");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Year: {car.Year}");
                    Console.WriteLine($"HorsePowers: {car.EngineIndex.HorsePower}");
                    Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                }
            }
        }
    }
}

