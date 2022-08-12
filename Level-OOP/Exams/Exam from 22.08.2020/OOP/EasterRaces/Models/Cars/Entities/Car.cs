namespace EasterRaces.Models.Cars.Entities
{
    using System;

    using EasterRaces.Utilities.Messages;
    using EasterRaces.Models.Cars.Contracts;

    public abstract class Car : ICar
    {
        private string model;

        protected Car(string model, int horsePower, double cubicCentimeters,
            int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)
                    || value.Length < 4)
                {
                    throw new ArgumentException(
                        string.Format(ExceptionMessages.InvalidModel, value, 4));
                }

                model = value;
            }
        }

        public abstract int HorsePower { get; protected set; }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            double result = CubicCentimeters / HorsePower * laps;

            return result;
        }
    }
}
