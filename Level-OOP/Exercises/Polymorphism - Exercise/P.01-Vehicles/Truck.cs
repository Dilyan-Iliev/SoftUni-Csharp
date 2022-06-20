using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : IVehicle
    {
        private readonly double fuelConsumptionIncrease = 1.6;

        public Truck(double fuelQuantity, double fuelConsupmtionPerKM)
        {
            FuelQuantity = fuelQuantity;
            FuelConsupmtionPerKM = fuelConsupmtionPerKM + fuelConsumptionIncrease;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsupmtionPerKM { get; private set; }

        public string Drive(double distance)
        {
            double neededFuel = distance * FuelConsupmtionPerKM;

            if (neededFuel > FuelQuantity)
            {
                throw new ArgumentException("Truck needs refueling");
            }

            FuelQuantity -= neededFuel;
            return $"Truck travelled {distance} km";
        }

        public void Refuel(double liters)
        {
            FuelQuantity += liters;
            FuelQuantity = FuelQuantity - (liters * 0.05);
        }

        public override string ToString()
        {
            return $"Truck: {FuelQuantity:f2}";
        }
    }
}
