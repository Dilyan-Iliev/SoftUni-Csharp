namespace Formula1.Repositories
{
    using System.Linq;
    using Formula1.Models.Contracts;
    using System.Collections.Generic;
    using Formula1.Repositories.Contracts;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly List<IFormulaOneCar> cars;

        public FormulaOneCarRepository()
        {
            cars = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models
            => cars.AsReadOnly();

        public void Add(IFormulaOneCar model)
        {
            cars.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            IFormulaOneCar car = cars.FirstOrDefault(x => x.Model == name);

            return car;
        }

        public bool Remove(IFormulaOneCar model)
          => cars.Remove(model);
    }
}
