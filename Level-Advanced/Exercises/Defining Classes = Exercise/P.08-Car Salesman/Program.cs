using System;
using System.Linq;
using System.Collections.Generic;

namespace P._08_Car_Salesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfEngineInfoLines = int.Parse(Console.ReadLine());
            var engineList = new List<Engine>();

            for (int i = 1; i <= numberOfEngineInfoLines; i++)
            {
                string[] engineInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //based on array.Length -> which engine constructor to use (create new engine in the each if)

                //if (engineInfo.Length == 2)
                string engineModel = engineInfo[0];
                int enginePower = int.Parse(engineInfo[1]);
                var engine = new Engine(engineModel, enginePower);

                if (engineInfo.Length == 3)
                {
                    if (int.TryParse(engineInfo[2], out int dissplacement))
                    {
                        //if engineInfo[2] is dissplacement
                        engine.Displacement = dissplacement;
                    }
                    else
                    {
                        //if engineInfo[2] is efficiency
                        string engineEfficiencty = engineInfo[2];
                        engine.Efficiency = engineEfficiencty;
                    }
                }
                else if (engineInfo.Length == 4)
                {
                    engine.Displacement = int.Parse(engineInfo[2]);
                    engine.Efficiency = engineInfo[3];
                }

                engineList.Add(engine);
            }

            int numberOfCarInfoLines = int.Parse(Console.ReadLine());
            var carList = new List<Car>();

            for (int i = 1; i <= numberOfCarInfoLines; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string carModel = carInfo[0];
                Engine carEngine = engineList.Where(x => x.EngineModel == carInfo[1]).First();

                var car = new Car(carModel, carEngine);

                if (carInfo.Length == 3)
                {
                    if (int.TryParse(carInfo[2], out int weight))
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        string carColor = carInfo[2];
                        car.Color = carColor;
                    }
                }
                else if (carInfo.Length == 4)
                {
                    int carWeight = int.Parse(carInfo[2]);
                    string carColor = carInfo[3];
                    car.Weight = carWeight;
                    car.Color = carColor;
                }

                carList.Add(car);
            }

            foreach (var car in carList)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
