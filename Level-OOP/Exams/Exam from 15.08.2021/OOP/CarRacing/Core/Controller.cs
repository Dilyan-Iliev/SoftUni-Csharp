namespace CarRacing.Core
{
    using System;
    using System.Text;
    using System.Linq;

    using CarRacing.Models.Maps;
    using CarRacing.Models.Cars;
    using CarRacing.Repositories;
    using CarRacing.Models.Racers;
    using CarRacing.Core.Contracts;
    using CarRacing.Utilities.Messages;
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Repositories.Contracts;
    using CarRacing.Models.Racers.Contracts;

    public class Controller : IController
    {
        private readonly IRepository<ICar> cars;
        private readonly IRepository<IRacer> racers;
        private readonly IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();

            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = null;

            switch (type)
            {
                case nameof(SuperCar): car = new SuperCar(make, model, VIN, horsePower); break;
                case nameof(TunedCar): car = new TunedCar(make, model, VIN, horsePower); break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            IRacer racer = null;

            switch (type)
            {
                case nameof(StreetRacer): racer = new StreetRacer(username, car); break;
                case nameof(ProfessionalRacer): racer = new ProfessionalRacer(username, car); break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            racers.Add(racer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.FindBy(racerOneUsername);
            IRacer racerTwo = racers.FindBy(racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }

            if (racerTwo == null)
            {
                throw new ArgumentException
                   (string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return map.StartRace(racerOne, racerTwo);  
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var racer in racers.Models
                .OrderByDescending(x => x.DrivingExperience)
                .ThenBy(x => x.Username))
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
