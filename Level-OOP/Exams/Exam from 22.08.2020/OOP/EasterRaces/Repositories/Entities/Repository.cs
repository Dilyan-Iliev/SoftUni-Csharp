namespace EasterRaces.Repositories.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using EasterRaces.Repositories.Contracts;

    public abstract class Repository<T> : IRepository<T>
    {
        protected readonly IList<T> models;

        protected Repository()
        {
            this.models = new List<T>();
        }

        public void Add(T model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
         => models.ToList();

        public abstract T GetByName(string name);

        public bool Remove(T model)
         => models.Remove(model);
    }
}
