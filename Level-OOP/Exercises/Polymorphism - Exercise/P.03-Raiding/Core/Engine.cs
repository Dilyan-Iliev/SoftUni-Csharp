namespace PracticeForJudge.Core
{
    using System.Linq;
    using System.Collections.Generic;
    using PracticeForJudge.Exceptions;
    using PracticeForJudge.IO.Interfaces;
    using PracticeForJudge.Core.Factories;
    using PracticeForJudge.Core.Interfaces;
    using PracticeForJudge.Models.Interfaces;
    using PracticeForJudge.Core.Factories.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICollection<IHero> heroes;

        private Engine() //initializer for collections
        {
            heroes = new List<IHero>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            IHeroFactory heroFactory = new HeroFactory();
            //ICollection<IHero> heroes = new List<IHero>();

            int targetValidHeroes = int.Parse(reader.ReadLine());
            int validHeroes = 0;

            while (targetValidHeroes != validHeroes)
            {
                string heroName = reader.ReadLine();
                string heroType = reader.ReadLine();

                try
                {
                    IHero hero = heroFactory.Create(heroType, heroName);
                    heroes.Add(hero);

                    validHeroes++;
                }
                catch (InvalidHeroException ihe)
                {
                    writer.WriteLine(ihe.InvalidHeroMessage);
                }
            }

            int bossPower = int.Parse(reader.ReadLine());

            foreach (var hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
            }

            bool isWin = heroes.Sum(x => x.Power) >= bossPower;

            string result = isWin ? "Victory!" : "Defeat...";
            writer.WriteLine(result);
        }
    }
}
