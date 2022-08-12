namespace EasterRaces.Models.Cars.Entities
{
    using EasterRaces.Utilities.Messages;
    using System;

    public class SportsCar : Car
    {
        private int horsePower;

        private const double SportsCarCubicCentimeters = 3000;
        private const int MinHorsePower = 250;
        private const int MaxHorsePower = 450;

        public SportsCar(string model, int horsePower) 
            : base(model, horsePower, SportsCarCubicCentimeters, MinHorsePower, MaxHorsePower)
        {
        }

        public override int HorsePower
        {
            get => horsePower;
            protected set
            {
                if (value < MinHorsePower || value > MaxHorsePower)
                {
                    throw new ArgumentException(
                        string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                horsePower = value;
            }
        }
    }
}
