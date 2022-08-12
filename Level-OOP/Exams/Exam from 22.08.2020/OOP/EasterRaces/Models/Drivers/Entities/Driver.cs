namespace EasterRaces.Models.Drivers.Entities
{
    using System;

    using EasterRaces.Utilities.Messages;
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Drivers.Contracts;

    public class Driver : IDriver
    {
        private string name;
        private int numberOfWins = 0;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value)
                    || value.Length < 5)
                {
                    throw new ArgumentException(
                        string.Format(ExceptionMessages.InvalidName, value, 5));
                }

                name = value;
            }
        }

        public Driver(string name)
        {
            Name = name;
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; }

        public bool CanParticipate
        {
            get
            {
                if (Car == null)
                {
                    return false;
                }
                return true;
            }
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }

            this.Car = car;
        }

        public void WinRace()
        {
            numberOfWins++;
        }
    }
}
