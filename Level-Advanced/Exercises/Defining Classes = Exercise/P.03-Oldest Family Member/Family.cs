using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace P._03_Oldest_Family_Member
{
    public class Family
    {
        public Family()
        {
            this.People = new List<Person>();
        }

        private List<Person> people;
        public List<Person> People
        {
            get { return this.people; }
            set { this.people = value; }
        }

        public void AddMember(Person person)
        {
            this.People.Add(person);
        }

        public Person GetOldestMember()
        {
            return this.People.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }
}
