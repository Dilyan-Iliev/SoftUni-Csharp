namespace EasterRaces.Repositories.Entities
{
    using System.Linq;
    using EasterRaces.Models.Cars.Contracts;

    public class CarRepository : Repository<ICar>
    {
        public override ICar GetByName(string name)
        {
            ICar car = models
                .FirstOrDefault(x => x.Model == name);

            return car;
        }
    }
}
