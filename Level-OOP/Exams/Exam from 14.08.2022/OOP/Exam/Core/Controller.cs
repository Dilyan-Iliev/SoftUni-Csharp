namespace PlanetWars.Core
{
    using PlanetWars.Core.Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Repositories.Contracts;
    using System;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private readonly IRepository<IPlanet> planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            IMilitaryUnit militaryUnit = null;

            switch (unitTypeName)
            {
                case nameof(SpaceForces): militaryUnit = new SpaceForces(); break;
                case nameof(AnonymousImpactUnit): militaryUnit = new AnonymousImpactUnit(); break;
                case nameof(StormTroopers): militaryUnit = new StormTroopers(); break;
                default:
                    throw new InvalidOperationException($"{unitTypeName} still not available!");
            }

            if (planet.Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }

            planet.Spend(militaryUnit.Cost);
            planet.AddUnit(militaryUnit);

            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            IWeapon weapon = null;

            switch (weaponTypeName)
            {
                case nameof(BioChemicalWeapon): weapon = new BioChemicalWeapon(destructionLevel); break;
                case nameof(NuclearWeapon): weapon = new NuclearWeapon(destructionLevel); break;
                case nameof(SpaceMissiles): weapon = new SpaceMissiles(destructionLevel); break;
                default:
                    throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }

            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return $"{planetName} purchased {weaponTypeName}!";
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.FindByName(name) != null)
            {
                return $"Planet {name} is already added!";
            }

            IPlanet planet = new Planet(name, budget);
            planets.AddItem(planet);

            return $"Successfully added Planet: {name}";
        }

        public string ForcesReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in planets.Models
                .OrderByDescending(x => x.MilitaryPower)
                .ThenBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet attackingPlanet = planets.FindByName(planetOne);
            IPlanet deffendingPlanet = planets.FindByName(planetTwo);

            if (attackingPlanet.MilitaryPower == deffendingPlanet.MilitaryPower)
            {
                if (attackingPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
                {
                    attackingPlanet.Spend(attackingPlanet.Budget / 2);
                    attackingPlanet.Profit(deffendingPlanet.Budget / 2);
                    attackingPlanet.Profit(
                        deffendingPlanet.Army.Sum(x => x.Cost) + deffendingPlanet.Weapons.Sum(x => x.Price));

                    planets.RemoveItem(planetTwo);
                    return $"{planetOne} destructed {planetTwo}!";
                }
                else if (deffendingPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
                {
                    deffendingPlanet.Spend(deffendingPlanet.Budget / 2);
                    deffendingPlanet.Profit(attackingPlanet.Budget / 2);
                    deffendingPlanet.Profit(
                        attackingPlanet.Army.Sum(x => x.Cost) + attackingPlanet.Weapons.Sum(x => x.Price));

                    planets.RemoveItem(planetOne);
                    return $"{planetTwo} destructed {planetOne}!";
                }
                else if ((attackingPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon))
                    && deffendingPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
                    || (!attackingPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon))
                    && !deffendingPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon))))
                {
                    attackingPlanet.Spend(attackingPlanet.Budget / 2);
                    deffendingPlanet.Spend(deffendingPlanet.Budget / 2);

                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }
            }
            else if (attackingPlanet.MilitaryPower > deffendingPlanet.MilitaryPower)
            {
                attackingPlanet.Spend(attackingPlanet.Budget / 2);
                attackingPlanet.Profit(deffendingPlanet.Budget / 2);
                attackingPlanet.Profit(
                    deffendingPlanet.Army.Sum(x => x.Cost) + deffendingPlanet.Weapons.Sum(x => x.Price));

                planets.RemoveItem(planetTwo);
                return $"{planetOne} destructed {planetTwo}!";
            }
            else if (attackingPlanet.MilitaryPower < deffendingPlanet.MilitaryPower)
            {
                deffendingPlanet.Spend(deffendingPlanet.Budget / 2);
                deffendingPlanet.Profit(attackingPlanet.Budget / 2);
                deffendingPlanet.Profit(
                    attackingPlanet.Army.Sum(x => x.Cost) + attackingPlanet.Weapons.Sum(x => x.Price));

                planets.RemoveItem(planetOne);
                return $"{planetTwo} destructed {planetOne}!";
            }

            return null;
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }

            if (!planet.Army.Any())
            {
                throw new InvalidOperationException("No units available for upgrade!");
            }

            //planet.Army.ToList().ForEach(x => x.IncreaseEndurance());

            foreach (var unit in planet.Army)
            {
                unit.IncreaseEndurance();
            }

            planet.Spend(1.25);
            return $"{planetName} has upgraded its forces!";
        }
    }
}
