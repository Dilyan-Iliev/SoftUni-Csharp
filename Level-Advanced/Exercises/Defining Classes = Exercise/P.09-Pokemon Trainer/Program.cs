using System;
using System.Linq;
using System.Collections.Generic;

namespace P._09_Pokemon_Trainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var trainers = new Dictionary<string, Trainer>();

            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                //Each line will carry information about a pokemon and the trainer who caught it 
                string[] inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = inputArgs[0];
                string pokemonName = inputArgs[1];
                string pokemonElement = inputArgs[2];
                int pokemonHealth = int.Parse(inputArgs[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    var trainer = new Trainer(trainerName);
                    trainers[trainerName] = trainer;
                }

                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                trainers[trainerName].CollectionOfPokemons.Add(pokemon);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var kvp in trainers.Values)
                {
                    if(kvp.CollectionOfPokemons.Any(x => x.PokemonElement == command))
                    {
                        kvp.Badge += 1;
                    }
                    else
                    {
                        foreach (var pokemon in kvp.CollectionOfPokemons)
                        {
                            pokemon.PokemonHealth -= 10;
                        }

                        kvp.CollectionOfPokemons.RemoveAll(x => x.PokemonHealth <= 0);
                    }
                }
            }

            foreach (var kvp in trainers.OrderByDescending(x => x.Value.Badge))
            {
                Console.WriteLine(kvp.Value.ToString());
            }
        }
    }
}
