using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo.Models
{
    public class Team
    {
        private ICollection<Person> firstTeam;
        private ICollection<Person> secondTeam;

        public Team(string name)
        {
            this.firstTeam = new List<Person>();
            this.secondTeam = new List<Person>();
        }
        public IReadOnlyCollection<Person> FirstTeam => firstTeam.ToList().AsReadOnly();
        public IReadOnlyCollection<Person> SecondTeam => secondTeam.ToList().AsReadOnly();
        public string Name { get; private set; }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                secondTeam.Add(person);
            }
        }
    }
}
