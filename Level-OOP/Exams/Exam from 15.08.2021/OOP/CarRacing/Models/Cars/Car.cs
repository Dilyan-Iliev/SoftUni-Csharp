﻿namespace CarRacing.Models.Cars
{
    using System;
    using CarRacing.Utilities.Messages;
    using CarRacing.Models.Cars.Contracts;

    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelConsumptionPerRace;

        private const int VinNExactLength = 17;

        public Car(string make, string model, string VIN, int horsePower,
            double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = VIN;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        public string Make
        {
            get => make;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                }

                make = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                }

                model = value;
            }
        }

        public string VIN
        {
            get => vin;
            private set
            {
                if (value.Length != VinNExactLength)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                }

                vin = value;
            }
        }

        public int HorsePower
        {
            get => horsePower;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                }

                horsePower = value;
            }
        }

        public double FuelAvailable { get; private set; }

        public double FuelConsumptionPerRace
        {
            get => fuelConsumptionPerRace;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                }

                fuelConsumptionPerRace = value;
            }
        }

        public virtual void Drive()
        {
            FuelAvailable -= FuelConsumptionPerRace;

            if (FuelAvailable < 0)
            {
                FuelAvailable = 0;
            }
        }
    }
}