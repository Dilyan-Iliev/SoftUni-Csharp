using System;
using System.Collections.Generic;
using System.Linq;

namespace P._05_Football_Team_Generator
{
    public class Team
    {
        private string name;
        private readonly List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public int GetTeamRating
        {
            get => TeamRating();
        }

        public void Add(Player player)
        {
            this.players.Add(player);
        }
        public void Remove(string name)
        {
            var player = players
                .Where(x => x.Name == name)
                .FirstOrDefault();

            if (player is null)
            {
                throw new ArgumentException($"Player {name} is not in the {this.Name} team.");
            }

            players.Remove(player);
        }
        private int TeamRating()
        {
            var result = 0;

            foreach (var player in players)
            {
                result += player.GetOverallSkill;
            }

            if (result == 0)
            {
                return 0; 
            }

            return result / players.Count;
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.GetTeamRating}";
        }
    }
}
