using System;
using System.Linq;
using System.Collections.Generic;

namespace P._07_Raw_Data
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<Car>();

            for (int i = 1; i <= n; i++)
            {
                string[] inputInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = inputInfo[0];
                int engineSpeed = int.Parse(inputInfo[1]);
                int enginePower = int.Parse(inputInfo[2]);

                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(inputInfo[3]);
                string cargoType = inputInfo[4];

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                //double tire1Pressure = double.Parse(inputInfo[5]);
                //int tire1Age = int.Parse(inputInfo[6]);
                //double tire2Pressure = double.Parse(inputInfo[7]);
                //int tire2Age = int.Parse(inputInfo[8]);
                //double tire3Pressure = double.Parse(inputInfo[9]);
                //int tire3Age = int.Parse(inputInfo[10]);
                //double tire4Pressure = double.Parse(inputInfo[11]);
                //int tire4Age = int.Parse(inputInfo[12]);

                //Tire[] tires = new Tire[4]
                //{
                //    new Tire (tire1Pressure, tire1Age),
                //    new Tire (tire2Pressure, tire2Age),
                //    new Tire (tire3Pressure, tire3Age),
                //    new Tire (tire4Pressure, tire4Age)
                //};

                Tire[] tires = new Tire[4];
                var counter = 0;
                for (int tireIndex = 5; tireIndex < inputInfo.Length; tireIndex+=2)
                {
                    double currentTirePressure = double.Parse(inputInfo[tireIndex]);
                    int currentTireAge = int.Parse(inputInfo[tireIndex+1]);

                    Tire tire = new Tire(currentTirePressure, currentTireAge);
                    tires[counter++] = tire;
                }

                var car = new Car(model, engine, cargo, tires);
                list.Add(car);
            }

            string filterWord = Console.ReadLine();
            PrintOutput(list, filterWord);
        }

        static void PrintOutput(List<Car> list, string filterWord)
        {
            foreach (var car in list)
            {
                if (filterWord == "fragile")
                {
                    if (car.Cargo.Type == filterWord && car.Tires.Any(x => x.Pressure < 1))
                    {
                        Console.WriteLine(car.Model);
                    }
                }
                else if (filterWord == "flammable")
                {
                    if (car.Cargo.Type == filterWord && car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}
