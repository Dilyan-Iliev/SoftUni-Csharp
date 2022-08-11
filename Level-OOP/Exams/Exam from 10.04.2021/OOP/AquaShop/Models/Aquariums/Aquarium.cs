namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Linq;
    using System.Text;

    using System.Collections.Generic;
    using AquaShop.Utilities.Messages;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;

    public abstract class Aquarium : IAquarium
    {
        private string name;

        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            Decorations = new List<IDecoration>();
            Fish = new List<IFish>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort 
            => this.Decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; }

        public void AddDecoration(IDecoration decoration)
         => this.Decorations.Add(decoration);

        public void AddFish(IFish fish)
        {
            if (this.Capacity <= Fish.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.Fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            var fish = Fish.Any() ? 
                string.Join(", ", Fish.Select(x => x.Name)) 
                : "none";

            sb.AppendLine($"Fish: {fish}");
            sb.AppendLine($"Decorations: {Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
         => this.Fish.Remove(fish);
    }
}
