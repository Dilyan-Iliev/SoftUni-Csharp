namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly IList<IPlanet> models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models 
            => models.ToList();

        public void Add(IPlanet model)
        {
            models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            IPlanet planet = models
                .FirstOrDefault(x => x.Name == name);

            if (planet == null)
            {
                return null;
            }

            return planet;
        }

        public bool Remove(IPlanet model)
         => models.Remove(model);
    }
}
