using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsupmtionPerKM { get; }
        string Drive(double distance);
        void Refuel(double liters);
    }
}
