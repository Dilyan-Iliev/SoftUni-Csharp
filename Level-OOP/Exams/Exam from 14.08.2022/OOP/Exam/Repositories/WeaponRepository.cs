namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private IList<IWeapon> models;

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models 
            => this.models.ToList();

        public void AddItem(IWeapon model) 
             => this.models.Add(model);

        public IWeapon FindByName(string name)
             => models.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name)
            => this.models.Remove(FindByName(name));
    }
}
