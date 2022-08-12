namespace EasterRaces.Models.Cars.Entities
{
    using EasterRaces.Utilities.Messages;
    using System;

    public class MuscleCar : Car
    {
        private int horsePower;
        private const double MuscleCarCubicCentimeters = 5000;
        private const int MinHorsePower = 400;
        private const int MaxHorsePower = 600;


        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, MuscleCarCubicCentimeters, MinHorsePower, MaxHorsePower)
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
