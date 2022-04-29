using System;
using System.Collections.Generic;

namespace P._06_Speed_Racing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var dictionary = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                var inputData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var carModel = inputData[0];
                var carFuelAmount = double.Parse(inputData[1]);
                var carFuelConsumptionFor1km = double.Parse(inputData[2]);


                if (!dictionary.ContainsKey(carModel))
                {
                    var car = new Car(carModel, carFuelAmount, carFuelConsumptionFor1km);
                    dictionary[carModel] = car;
                    //it works with dictionary[car.Model] = car;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var carModel = cmdArgs[1];
                var amountOfKm = double.Parse(cmdArgs[2]);

                if (cmdArgs[0] == "Drive")
                {
                    dictionary[carModel].CheckForDistance(amountOfKm);

                }
            }

            foreach (KeyValuePair<string, Car> keyValuePair in dictionary)
            {
                Console.WriteLine($"{keyValuePair.Key} {keyValuePair.Value.FuelAmount:f2} {keyValuePair.Value.TravelledDistance}");
            }
        }
    }
}
