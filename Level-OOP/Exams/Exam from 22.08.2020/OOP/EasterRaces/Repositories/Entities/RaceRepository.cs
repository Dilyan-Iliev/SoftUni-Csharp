namespace EasterRaces.Repositories.Entities
{
    using System.Linq;
    using EasterRaces.Models.Races.Contracts;

    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            IRace race = models
                .FirstOrDefault(x => x.Name == name);

            return race;
        }
    }
}
