namespace _8.Engine
{
    using System;
    using _8.IO.Interfaces;
    using _8.Engine.Interfaces;
    using _8.Engine.Factory;
    using _8.Models.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;

        public Engine(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            List<IHero> heroes = new List<IHero>();

            int neededNumberValidHeroes = int.Parse(reader.ReadLine());
            int counter = 0;

            while (counter != neededNumberValidHeroes)
            {
                string heroName = reader.ReadLine();
                string heroType = reader.ReadLine();

                HeroFactory heroFactory = new HeroFactory();
                try
                {
                    IHero hero = heroFactory.Create(heroType, heroName);
                    heroes.Add(hero);

                    counter++;

                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
            }
            int bossPower = int.Parse(reader.ReadLine());

            heroes.ForEach(x => writer.WriteLine(x.CastAbility()));

            bool isWin = heroes.Sum(x => x.Power) >= bossPower;

            string result = isWin ? "Victory!" : "Defeat...";
            writer.WriteLine(result);
        }
    }
}
