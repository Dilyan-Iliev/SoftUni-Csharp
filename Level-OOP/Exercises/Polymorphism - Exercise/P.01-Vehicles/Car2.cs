using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car2 : Vehicle
    {
        private const double AdditionalFuel = 0.9;
        public Car2(double fuelQuantity, double fuelConsumptionPerKM) : base(fuelQuantity, fuelConsumptionPerKM)
        {
            this.FuelConsumptionPerKM += AdditionalFuel;
        }
    }
}
