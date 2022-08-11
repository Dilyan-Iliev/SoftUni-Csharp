namespace CarRacing.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Repositories.Contracts;
    using CarRacing.Utilities.Messages;

    public class CarRepository : IRepository<ICar>
    {
        private readonly IList<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models 
            => models.ToList();

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            models.Add(model);
        }

        public ICar FindBy(string property)
        {
            ICar car = models
                .FirstOrDefault(x => x.VIN == property);

            if (car == null)
            {
                return null;
            }

            return car;
        }

        public bool Remove(ICar model)
         => models.Remove(model);
    }
}
