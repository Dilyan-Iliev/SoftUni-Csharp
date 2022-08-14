namespace PlanetWars.Factories
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class MilitaryUnitFactory
    {
        public IMilitaryUnit Create(string unitType)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type type = assembly.GetTypes()
                .FirstOrDefault(x => x.Name == unitType);
            
            if (type == null)
            {
                throw new InvalidOperationException($"{unitType} still not available!");
            }

            var unit = Activator.CreateInstance(type) as IMilitaryUnit;

            return unit;
        } 
    }
}
