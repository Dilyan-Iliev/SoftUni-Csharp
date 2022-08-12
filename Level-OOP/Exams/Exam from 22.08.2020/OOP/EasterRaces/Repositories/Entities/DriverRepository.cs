namespace EasterRaces.Repositories.Entities
{
    using EasterRaces.Models.Drivers.Contracts;
    using System.Linq;

    public class DriverRepository : Repository<IDriver>
    {
        public override IDriver GetByName(string name)
        {
            IDriver driver = models
                .FirstOrDefault(x => x.Name == name);

            return driver;
        }
    }
}
