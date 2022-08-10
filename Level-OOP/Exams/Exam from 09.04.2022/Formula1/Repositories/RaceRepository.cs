namespace Formula1.Repositories
{
    using System.Linq;
    using Formula1.Models.Contracts;
    using System.Collections.Generic;
    using Formula1.Repositories.Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models 
            => models.AsReadOnly();

        public void Add(IRace model)
        {
            models.Add(model);
        }

        public IRace FindByName(string name)
        {
            IRace race = models.FirstOrDefault(x => x.RaceName == name);

            return race;
        }

        public bool Remove(IRace model)
         => models.Remove(model);
    }
}
