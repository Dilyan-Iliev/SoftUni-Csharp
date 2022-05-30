using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }
        public string Name { get; private set; }
        public IReadOnlyCollection<Person> FirstTeam { get => this.firstTeam; }
        public IReadOnlyCollection<Person> ReserveTeam { get => this.reserveTeam; }
        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First team has {this.firstTeam.Count} players.");
            sb.Append($"Reserve team has {this.reserveTeam.Count} players.");

            return sb.ToString();
        }
    }
}
