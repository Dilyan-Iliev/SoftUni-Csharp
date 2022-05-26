using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
            this.DefaultFuelConsumption = 8;
        }

        //public override void Drive(double kilometers)
        //{
        //    this.Fuel -= kilometers * this.FuelConsumption;
        //}
    }
}
