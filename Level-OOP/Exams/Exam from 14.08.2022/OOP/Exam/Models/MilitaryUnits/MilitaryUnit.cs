namespace PlanetWars.Models.MilitaryUnits
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using System;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        public double Cost { get; private set; }

        protected MilitaryUnit(double cost)
        {
            Cost = cost;
            this.EnduranceLevel = 1;
        }

        public int EnduranceLevel { get; private set; }

        public void IncreaseEndurance()
        {
            this.EnduranceLevel += 1;

            if (this.EnduranceLevel > 20)
            {
                this.EnduranceLevel = 20;

                throw new ArgumentException("Endurance level cannot exceed 20 power points.");
            }

            //think of switching their places
        }
    }
}
