namespace PlanetWars.Models.Planets
{
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Planet : IPlanet
    {
        private readonly IRepository<IMilitaryUnit> unitRepo;
        private readonly IRepository<IWeapon> weaponRepo;

        //private readonly IList<IMilitaryUnit> army;
        //private readonly IList<IWeapon> weapons;

        private string name;
        private double budget;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;

            this.unitRepo = new UnitRepository();
            this.weaponRepo = new WeaponRepository();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Planet name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public double Budget
        {
            get => this.budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Budget's amount cannot be negative.");
                }

                this.budget = value;
            }
        }

        public double MilitaryPower => this.CalculateMilitaryPower();

        private double CalculateMilitaryPower()
        {
            double sum = this.unitRepo.Models.Sum(x => x.EnduranceLevel) + this.weaponRepo.Models.Sum(x => x.DestructionLevel);

            if (this.unitRepo.Models.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                sum += sum * 0.3;
            }
            if (this.weaponRepo.Models.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                sum += sum * 0.45;
            }

            return Math.Round(sum, 3);
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => this.unitRepo.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weaponRepo.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.unitRepo.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weaponRepo.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            var sb = new StringBuilder();
            var forces = this.Army.Any()
                ? string.Join(", ", Army.Select(x => x.GetType().Name).ToList()) : "No units";

            var weapons = this.Weapons.Any()
                ? string.Join(", ", Weapons.Select(x => x.GetType().Name).ToList()) : "No weapons";

            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            sb.AppendLine($"--Forces: {forces}");
            sb.AppendLine($"--Combat equipment: {weapons}");
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (amount > this.Budget)
            {
                throw new InvalidOperationException("Budget too low!");
            }

            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in unitRepo.Models)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
