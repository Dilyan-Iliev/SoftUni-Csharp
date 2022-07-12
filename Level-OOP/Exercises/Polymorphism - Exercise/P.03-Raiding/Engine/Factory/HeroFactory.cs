namespace _8.Engine.Factory
{
    using _8.Models;
    using _8.Models.Interfaces;

    public class HeroFactory
    {
        public IHero Create(string type, string name)
        {
            IHero hero = null;

            if (type == nameof(Druid))
            {
                hero = new Druid(name);
            }
            else if (type == nameof(Paladin))
            {
                hero = new Paladin(name);
            }
            else if (type == nameof(Rogue))
            {
                hero = new Rogue(name);
            }
            else if (type == nameof(Warrior))
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new System.ArgumentException("Invalid hero type");
            }

            return hero;
        }
    }
}
