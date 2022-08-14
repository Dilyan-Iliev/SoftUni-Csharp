namespace PlanetWars.Factories
{
    using PlanetWars.Models.Weapons.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class WeaponFactory
    {
        public IWeapon Create(string weaponType, int destructionLevel)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type type = assembly.GetTypes()
                .FirstOrDefault(x => x.Name == weaponType);

            if (type == null)
            {
                throw new InvalidOperationException($"{weaponType} still not available!");
            }

            IWeapon weapon = Activator.CreateInstance(type) as IWeapon;

            return weapon;
        }
    }
}
