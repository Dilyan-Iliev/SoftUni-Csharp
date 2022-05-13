using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public List<Player> Players { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Players = new List<Player>();
        }
        public int Count => this.Players.Count;

        public void AddPlayer(Player player)
        {
            if (Players.Count < Capacity)
            {
                Players.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = Players.Where(x => x.Name == name)
                .FirstOrDefault();

            if (player != null)
            {
                Players.Remove(player);

                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            Player player = Players.Where(x => x.Name == name).FirstOrDefault();

            if (player != null)
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = Players.Where(x => x.Name == name).FirstOrDefault();

            if (player != null)
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string claass)
        {
            var filteredPlayers = Players.FindAll(x => x.Class == claass).ToArray();

            Players.RemoveAll(x => x.Class == claass);

            return filteredPlayers;
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {Name}");

            foreach (var item in Players)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
