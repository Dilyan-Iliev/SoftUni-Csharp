using PersonsInfo.Models;

namespace PersonsInfo.Core
{
    public class Controller : IController
    {
        public Person CreatePerson(string firstName, string lastName, int age, decimal salary)
        {
           return new Person(firstName, lastName, age, salary);
        }

        public Team CreateTeam(string name)
        {
            return new Team(name);
        }
    }
}
