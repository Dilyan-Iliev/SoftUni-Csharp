namespace SpaceStation.Models.Astronauts
{
    using System;
    using SpaceStation.Models.Bags.Contracts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Utilities.Messages;
    using SpaceStation.Models.Bags;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;

        public Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;

            Bag = new Backpack();
        }

        public string Name
        {
            get => name;    
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }

                name = value;
            }
        }

        public double Oxygen
        {
            get => oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                oxygen = value;
            }
        }

        public bool CanBreath { get; }

        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            this.Oxygen -= 10;

            //astronaut oxygen should not drop below 0 ? 
            if (this.Oxygen < 0)
            {
                this.Oxygen = 0;
            }
        }
    }
}
