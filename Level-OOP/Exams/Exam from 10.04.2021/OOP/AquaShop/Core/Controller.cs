namespace AquaShop.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using AquaShop.Models.Fish;
    using AquaShop.Repositories;
    using AquaShop.Core.Contracts;
    using AquaShop.Models.Aquariums;
    using System.Collections.Generic;
    using AquaShop.Utilities.Messages;
    using AquaShop.Models.Decorations;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Repositories.Contracts;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;

    public class Controller : IController
    {
        private readonly IList<IAquarium> aquariums;
        private readonly IRepository<IDecoration> decorations;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aq = null;

            switch (aquariumType)
            {
                case nameof(FreshwaterAquarium): aq = new FreshwaterAquarium(aquariumName); break;
                case nameof(SaltwaterAquarium): aq = new SaltwaterAquarium(aquariumName); break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(aq);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            switch (decorationType)
            {
                case nameof(Ornament): decoration = new Ornament(); break;
                case nameof(Plant): decoration = new Plant(); break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType,
            string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;

            switch (fishType)
            {
                case nameof(FreshwaterFish): fish = new FreshwaterFish(fishName, fishSpecies, price); break;
                case nameof(SaltwaterFish): fish = new SaltwaterFish(fishName, fishSpecies, price); break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IAquarium aq = aquariums
                .FirstOrDefault(x => x.Name == aquariumName);

            if (fishType == nameof(FreshwaterFish))
            {
                if (!(aq.GetType().Name == nameof(FreshwaterAquarium)))
                {
                    return OutputMessages.UnsuitableWater;
                }

                aq.Fish.Add(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else // if (fishType == nameof(SaltwaterFish)
            {
                if (!(aq.GetType().Name == nameof(SaltwaterAquarium)))
                {
                    return OutputMessages.UnsuitableWater;
                }

                aq.Fish.Add(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aq = aquariums
                .FirstOrDefault(x => x.Name == aquariumName);

            var totalValue = aq.Fish.Sum(f => f.Price) 
                + aq.Decorations.Sum(d => d.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, totalValue);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aq = aquariums
                .FirstOrDefault(x => x.Name == aquariumName);

            aq.Feed();

            return string.Format(OutputMessages.FishFed, aq.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            IAquarium aq = aquariums
                .FirstOrDefault(x => x.Name == aquariumName);

            aq.AddDecoration(decoration);
            decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var aq in aquariums)
            {
                sb.AppendLine(aq.GetInfo().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
