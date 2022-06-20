using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck2 : Vehicle
    {
        private const double AdditionalFuel = 1.6;
        public Truck2(double fuelQuantity, double fuelConsumptionPerKM) : base(fuelQuantity, fuelConsumptionPerKM)
        {
            this.FuelConsumptionPerKM += AdditionalFuel;
        }

        public override void Refuel(double liters)
        {
            liters *= 0.5;
            base.Refuel(liters);
        }
    }
}
