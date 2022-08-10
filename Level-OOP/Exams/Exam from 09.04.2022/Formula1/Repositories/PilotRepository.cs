namespace Formula1.Repositories
{
    using System.Linq;
    using Formula1.Models.Contracts;
    using System.Collections.Generic;
    using Formula1.Repositories.Contracts;

    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> pilots;

        public PilotRepository()
        {
            this.pilots = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models 
            => pilots.AsReadOnly();

        public void Add(IPilot model)
        {
            pilots.Add(model);
        }

        public IPilot FindByName(string name)
        {
            IPilot pilot = pilots.FirstOrDefault(x => x.FullName == name);

            return pilot;
        }

        public bool Remove(IPilot model)
          => pilots.Remove(model);
    }
}
