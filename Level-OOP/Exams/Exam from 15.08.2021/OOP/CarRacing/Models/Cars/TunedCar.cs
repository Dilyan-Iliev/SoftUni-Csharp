namespace CarRacing.Models.Cars
{
    using System;

    public class TunedCar : Car
    {
        private const double TunedCarFuelAvailable = 65;
        private const double TunedCarFuelConsumptionPerRace = 7.5;

        public TunedCar(string make, string model, string VIN, int horsePower)
            : base(make, model, VIN, horsePower, TunedCarFuelAvailable, TunedCarFuelConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();

            this.HorsePower = (int)Math.Round(this.HorsePower - this.HorsePower * 0.03);
        }
    }
}
