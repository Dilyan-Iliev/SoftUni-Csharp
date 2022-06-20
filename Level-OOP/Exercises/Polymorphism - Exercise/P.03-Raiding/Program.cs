using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();
            BaseHero hero = null;
            int validHeroesMade = 0;

            while (validHeroesMade != n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                switch (heroType)
                {
                    case "Paladin": hero = new Paladin(heroName); break;
                    case "Druid": hero = new Druid(heroName); break;
                    case "Warrior": hero = new Warrior(heroName); break;
                    case "Rogue": hero = new Rogue(heroName); break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        continue;
                }

                heroes.Add(hero);
                validHeroesMade++;
            }

            heroes.ForEach(x => Console.WriteLine(x.CastAbility()));

            long bossPower = int.Parse(Console.ReadLine());
            long powers = heroes.Sum(x => x.Power);
            bool isWin = powers >= bossPower;

            string result = isWin ? "Victory!" : "Defeat...";
            Console.WriteLine(result);
        }
    }
}
