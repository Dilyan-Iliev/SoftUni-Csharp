using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumptionPerKM)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKM = fuelConsumptionPerKM;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumptionPerKM { get; protected set; }

        public virtual string Drive(double distance)
        {
            double neededFuel = distance * FuelConsumptionPerKM;

            if (neededFuel > FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} traveled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            FuelQuantity += liters;
        }
    }
}
