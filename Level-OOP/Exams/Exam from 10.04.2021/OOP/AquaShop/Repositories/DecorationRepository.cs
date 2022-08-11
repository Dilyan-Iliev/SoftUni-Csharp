namespace AquaShop.Repositories
{
    using System.Linq;

    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Repositories.Contracts;
    using System.Collections.Generic;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly IList<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models 
            => models.ToList();

        public void Add(IDecoration model)
         => models.Add(model);

        public IDecoration FindByType(string type)
        {
            IDecoration dec = models
                .FirstOrDefault(x => x.GetType().Name == type);

            return dec;
        }

        public bool Remove(IDecoration model)
         => models.Remove(model);
    }
}
