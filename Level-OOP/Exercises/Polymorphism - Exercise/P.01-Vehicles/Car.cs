using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : IVehicle
    {
        private readonly double fuelConsumptionIncrease = 0.9;
        public Car(double fuelQuantity, double fuelConsupmtion)
        {
            FuelQuantity = fuelQuantity;
            FuelConsupmtionPerKM = fuelConsupmtion + fuelConsumptionIncrease;
        }
        public double FuelQuantity { get; private set; }

        public double FuelConsupmtionPerKM { get; private set; }

        public string Drive(double distance)
        {
            double neededFuel = distance * FuelConsupmtionPerKM;

            if (neededFuel > FuelQuantity)
            {
                throw new Exception("Car needs refueling");
            }

            FuelQuantity -= neededFuel;
            return $"Car travelled {distance} km";

        }

        public void Refuel(double liters)
        {
            FuelQuantity+= liters;
        }

        public override string ToString()
        {
            return $"Car: {FuelQuantity:f2}";
        }
    }
}
