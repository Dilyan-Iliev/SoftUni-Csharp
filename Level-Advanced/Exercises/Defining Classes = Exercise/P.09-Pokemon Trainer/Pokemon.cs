using System;
using System.Collections.Generic;
using System.Text;

namespace P._09_Pokemon_Trainer
{
    public class Pokemon
    {
        public Pokemon(string name, string element, int health)
        {
            this.PokemonName = name;
            this.PokemonElement = element;
            this.PokemonHealth = health;
        }
        private string pokemonName;
        private string pokemonElement;
        private int pokemonHealth;

        public string PokemonName
        {
            get { return this.pokemonName; }
            set { this.pokemonName = value; }
        }
        public string PokemonElement
        {
            get { return this.pokemonElement; }
            set { this.pokemonElement = value; }
        }
        public int PokemonHealth
        {
            get { return this.pokemonHealth; }
            set { this.pokemonHealth = value; }
        }
    }
}
