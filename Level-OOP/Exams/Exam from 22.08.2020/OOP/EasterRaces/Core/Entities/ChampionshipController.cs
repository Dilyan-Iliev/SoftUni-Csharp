namespace EasterRaces.Core.Entities
{
    using System;
    using System.Text;
    using System.Linq;

    using EasterRaces.Core.Contracts;
    using EasterRaces.Utilities.Messages;
    using EasterRaces.Models.Cars.Entities;
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Races.Entities;
    using EasterRaces.Repositories.Entities;
    using EasterRaces.Models.Races.Contracts;
    using EasterRaces.Models.Drivers.Entities;
    using EasterRaces.Models.Drivers.Contracts;

    public class ChampionshipController : IChampionshipController
    {
        private readonly CarRepository cars;
        private readonly DriverRepository drivers;
        private readonly RaceRepository races;

        public ChampionshipController()
        {
            cars = new CarRepository();
            drivers = new DriverRepository();
            races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            ICar car = cars.GetByName(carModel);
            IDriver driver = drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            else if (car == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);
            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = races.GetByName(raceName);
            IDriver driver = drivers.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            else if (driver == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);
            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (cars.GetByName(model) != null)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.CarExists, model));
            }

            ICar car = null;

            switch (type)
            {
                case "Muscle": car = new MuscleCar(model, horsePower); break;
                case "Sports": car = new SportsCar(model, horsePower); break;
            }

            cars.Add(car);
            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            if (drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException(
                    string.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driver = new Driver(driverName);

            drivers.Add(driver);
            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (races.GetByName(name) != null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            races.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var bestDrivers = race.Drivers
                .OrderByDescending
                (x => x.Car.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            var sb = new StringBuilder();
            int counter = 1;

            foreach (var dr in bestDrivers)
            {
                if (counter == 1)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, dr.Name, race.Name));
                    dr.WinRace();
                }
                else if (counter == 2)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, dr.Name, race.Name));
                }
                else if (counter == 3)
                {
                    sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, dr.Name, race.Name));
                }

                counter++;
            }

            races.Remove(race);
            return sb.ToString().TrimEnd();
        }
    }
}
