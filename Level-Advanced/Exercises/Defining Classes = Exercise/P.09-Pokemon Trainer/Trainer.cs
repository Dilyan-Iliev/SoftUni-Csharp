using System;
using System.Collections.Generic;
using System.Text;

namespace P._09_Pokemon_Trainer
{
    public class Trainer
    {
        public Trainer(string trainerName)
        {
            this.TrainerName = trainerName;
            this.Badge = 0;
            this.CollectionOfPokemons = new List<Pokemon>();
        }
        private string trainerName;
        private int badge;
        private List<Pokemon> collectionOfPokemons;

        public string TrainerName
        {
            get { return this.trainerName; }
            set { this.trainerName = value; }
        }
        public int Badge
        {
            get { return this.badge; }
            set { this.badge = value; }
        }
        public List<Pokemon> CollectionOfPokemons
        {
            get { return this.collectionOfPokemons;}
            set { this.collectionOfPokemons = value; }
        }

        public override string ToString()
        {
            return $"{this.TrainerName} {this.Badge} {this.CollectionOfPokemons.Count}";
        }
    }
}
