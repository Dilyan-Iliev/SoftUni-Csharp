namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly IList<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models 
            => this.models.ToList();

        public void AddItem(IPlanet model)
          =>this.models.Add(model);
        

        public IPlanet FindByName(string name) 
            => models.FirstOrDefault(x => x.Name == name);

        public bool RemoveItem(string name)
          => this.models.Remove(FindByName(name));
    }
}
