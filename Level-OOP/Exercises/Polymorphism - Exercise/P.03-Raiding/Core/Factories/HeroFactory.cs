namespace PracticeForJudge.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using PracticeForJudge.Exceptions;
    using PracticeForJudge.Models.Interfaces;
    using PracticeForJudge.Core.Factories.Interfaces;

    public class HeroFactory : IHeroFactory
    {
        public IHero Create(string heroType, string heroName)
        {
            Assembly assemlby = Assembly.GetCallingAssembly();
            Type type = assemlby.GetTypes()
                .FirstOrDefault(x => x.Name == heroType);

            if (type == null)
            {
                throw new InvalidHeroException("Invalid hero type!");
            }

            var hero = Activator.CreateInstance(type, heroName) as IHero;

            return hero;
        }
    }
}
