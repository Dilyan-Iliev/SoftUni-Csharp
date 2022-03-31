using System;
using System.Linq;
using System.Collections.Generic;

namespace Heroes_of_Code_and_Logic_VII
{
    internal class Program
    {
        static int maxHP = 100;   //global variables to be used in the scope of Program class.
        static int maxMP = 200;  //global variables to be used in the scope of Program class.
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, Hero>();
            int numberOfHeroes = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfHeroes; i++)
            {
                string[] heroData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string heroName = heroData[0];
                int heroHP = int.Parse(heroData[1]);
                int heroMP = int.Parse(heroData[2]);

                if (!dictionary.ContainsKey(heroName))
                {
                    var heroObj = new Hero(heroHP, heroMP);
                    //{
                    //    HeroHP = heroHP,
                    //    HeroMP = heroMP,
                    //};  //this scope should be left if we dont have ctor in our class

                    dictionary[heroName] = heroObj;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                DictionaryCmds(dictionary, cmdArgs);
            }

            PrintDictionary(dictionary);
        }

        static Dictionary<string, Hero> DictionaryCmds(Dictionary<string, Hero> dict, string[] arr)
        {
            string currentCmd = arr[0];
            string heroName = arr[1];

            switch (currentCmd)
            {
                case "Heal": HealCmd(dict, arr, heroName); break;
                case "Recharge": RechargeCmd(dict, arr, heroName); break;
                case "TakeDamage": TakeDamageCmd(dict, arr, heroName); break;
                case "CastSpell": CastSpellCmd(dict, arr, heroName); break;
            }

            return dict;
        }

        static Dictionary<string, Hero> HealCmd(Dictionary<string, Hero> dict, string[] arr, string heroName)
        {
            int HPhealAmount = int.Parse(arr[2]);

            if (dict[heroName].HeroHP + HPhealAmount >= maxHP)
            {
                Console.WriteLine($"{heroName} healed for {maxHP - dict[heroName].HeroHP} HP!");
                dict[heroName].HeroHP = maxHP;
            }
            else
            {
                dict[heroName].HeroHP += HPhealAmount;
                Console.WriteLine($"{heroName} healed for {HPhealAmount} HP!");
            }

            return dict;
        }

        static Dictionary<string, Hero> RechargeCmd(Dictionary<string, Hero> dict, string[] arr, string heroName)
        {
            int MPhealAmount = int.Parse(arr[2]);

            if (dict[heroName].HeroMP + MPhealAmount >= maxMP)
            {
                Console.WriteLine($"{heroName} recharged for {maxMP - dict[heroName].HeroMP} MP!");
                dict[heroName].HeroMP = maxMP;
            }
            else
            {
                dict[heroName].HeroMP += MPhealAmount;
                Console.WriteLine($"{heroName} recharged for {MPhealAmount} MP!");
            }

            return dict;
        }

        static Dictionary<string, Hero> TakeDamageCmd(Dictionary<string, Hero> dict, string[] arr, string heroName)
        {
            int dmgTaken = int.Parse(arr[2]);
            string attackername = arr[3];

            if (dict[heroName].HeroHP - dmgTaken <= 0)
            {
                Console.WriteLine($"{heroName} has been killed by {attackername}!");
                dict.Remove(heroName);
            }
            else
            {
                dict[heroName].HeroHP -= dmgTaken;
                Console.WriteLine($"{heroName} was hit for {dmgTaken} HP by {attackername} and now has {dict[heroName].HeroHP} HP left!");
            }

            return dict;
        }

        static Dictionary<string, Hero> CastSpellCmd(Dictionary<string, Hero> dict, string[] arr, string heroName)
        {
            int neededMP = int.Parse(arr[2]);
            string spellName = arr[3];

            if (dict[heroName].HeroMP >= neededMP)
            {
                dict[heroName].HeroMP -= neededMP;
                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {dict[heroName].HeroMP} MP!");
            }
            else
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
            }

            return dict;
        }

        static void PrintDictionary(Dictionary<string, Hero> dict)
        {
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}");
                Console.WriteLine($"  HP: {kvp.Value.HeroHP}");
                Console.WriteLine($"  MP: {kvp.Value.HeroMP}");
            }
        }
    }

    public class Hero
    {
        public Hero(int heroHp, int heroMP)
        {
            this.HeroHP = heroHp;
            this.HeroMP = heroMP;
        }
        public int HeroHP { get; set; }
        public int HeroMP { get; set; } 
    }
}
