namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly IList<IAstronaut> models;

        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models
            => this.models.ToList();

        public void Add(IAstronaut model)
        {
            this.models.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            IAstronaut astr = models
                .FirstOrDefault(x => x.Name == name);

            if (astr == null)
            {
                return null;
            }

            return astr;
        }

        public bool Remove(IAstronaut model)
         => models.Remove(model);
    }
}
