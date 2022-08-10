namespace SpaceStation.Core
{
    using System;
    using System.Text;
    using System.Linq;

    using SpaceStation.Repositories;
    using SpaceStation.Models.Planets;
    using SpaceStation.Models.Mission;
    using SpaceStation.Core.Contracts;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Utilities.Messages;
    using SpaceStation.Repositories.Contracts;
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Models.Mission.Contracts;
    using SpaceStation.Models.Astronauts.Contracts;

    public class Controller : IController
    {
        private readonly IRepository<IAstronaut> astrounaoutRepository;
        private readonly IRepository<IPlanet> planetRepository;
        private int exploredPlanetsCounter = 0;

        public Controller()
        {
            this.astrounaoutRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astr = null;

            switch (type)
            {
                case nameof(Biologist): astr = new Biologist(astronautName); break;
                case nameof(Geodesist): astr = new Geodesist(astronautName); break;
                case nameof(Meteorologist): astr = new Meteorologist(astronautName); break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            astrounaoutRepository.Add(astr);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            planetRepository.Add(planet);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = planetRepository
                .FindByName(planetName);


            var suitableAstrounauts = astrounaoutRepository.Models
                .Where(x => x.Oxygen > 60)
                .ToList();

            if (!suitableAstrounauts.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            exploredPlanetsCounter++;
            IMission mission = new Mission();
            mission.Explore(planet, suitableAstrounauts);

            var deadAstronauts = astrounaoutRepository.Models
                .Where(x => x.Oxygen <= 0)
                .ToList();

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts.Count);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanetsCounter} planets were explored!");
            sb.AppendLine($"Astronauts info:");

            foreach (var astr in astrounaoutRepository.Models)
            {
                sb.AppendLine($"Name: {astr.Name}");
                sb.AppendLine($"Oxygen: {astr.Oxygen}");

                var items = astr.Bag.Items.Any() ? string.Join(", ", astr.Bag.Items) : "none";

                sb.AppendLine($"Bag items: {items}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astr = astrounaoutRepository
                .FindByName(astronautName);

            if (astr == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astrounaoutRepository.Remove(astr);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
