using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double AdditionalFuel = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AdditionalFuel;
        }

        public override void Refuel(double liters)
        {
            ValidateLitersAndQuantity(liters);
            liters *= 0.95;
            base.Refuel(liters);
        }
    }
}
