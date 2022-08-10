namespace Formula1.Core
{
    using System;
    using System.Text;
    using System.Linq;
    using Formula1.Models;
    using Formula1.Models.Cars;
    using Formula1.Repositories;
    using Formula1.Core.Contracts;
    using Formula1.Models.Contracts;
    using System.Collections.Generic;
    using Formula1.Repositories.Contracts;

    public class Controller : IController
    {
        private readonly IRepository<IPilot> pilotRepository;
        private readonly IRepository<IRace> raceRepository;
        private readonly IRepository<IFormulaOneCar> carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IFormulaOneCar car = carRepository.FindByName(carModel);

            if (car == null)
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }

            IPilot pilot = pilotRepository.FindByName(pilotName);

            if (pilot == null
                || pilot.Car != null)
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }

            pilot.AddCar(car);
            carRepository.Remove(car);
            return $"Pilot {pilotName} will drive a {car.GetType().Name} {carModel} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }

            IPilot pilot = pilotRepository.FindByName(pilotFullName);

            if (pilot == null
                || pilot.CanRace == false
                || race.Pilots
                .Any(x => x.FullName == pilotFullName))
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }

            race.AddPilot(pilot);
            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = null;

            //TODO - factory
            switch (type)
            {
                case nameof(Ferrari): car = new Ferrari(model, horsepower, engineDisplacement); break;
                case nameof(Williams): car = new Williams(model, horsepower, engineDisplacement); break;
                default:
                    throw new InvalidOperationException($"Formula one car type {type} is not valid.");
            }

            if (carRepository.Models.Any(x => x.Model == model))
            {
                throw new InvalidOperationException($"Formula one car {model} is already created.");
            }

            carRepository.Add(car);
            return $"Car {type}, model {model} is created.";
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilot = new Pilot(fullName);

            if (pilotRepository.Models.Any(x => x.FullName == fullName))
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }

            pilotRepository.Add(pilot);
            return $"Pilot {fullName} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = new Race(raceName, numberOfLaps);

            if (raceRepository.Models.Any(x => x.RaceName == raceName))
            {
                throw new InvalidOperationException($"Race {raceName} is already created.");
            }

            raceRepository.Add(race);
            return $"Race {raceName} is created.";
        }

        public string PilotReport()
        {
            var sb = new StringBuilder();

            foreach (var pilot in pilotRepository.Models
                .OrderByDescending(x => x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            var sb = new StringBuilder();

            foreach (var race in raceRepository.Models.Where(x => x.TookPlace == true))
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            else if (race.TookPlace == true)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }
            else if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }

            int numberOfLaps = race.NumberOfLaps;
            List<IPilot> winningPilots = race.Pilots
                .OrderByDescending(x => x.Car.RaceScoreCalculator(numberOfLaps))
                .Take(3)
                .ToList();
                
            race.TookPlace = true;

            var sb = new StringBuilder();
            int count = 1;

            foreach (var pilot in winningPilots)
            {
                if (count == 1)
                {
                    pilot.WinRace();
                    sb.AppendLine($"Pilot {pilot.FullName} wins the {raceName} race.");
                }
                else if (count == 2)
                {
                    sb.AppendLine($"Pilot {pilot.FullName} is second in the {raceName} race.");
                }
                else // if count == 3
                {
                    sb.AppendLine($"Pilot {pilot.FullName} is third in the {raceName} race.");
                }

                count++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
