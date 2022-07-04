using PersonsInfo.Models;

namespace PersonsInfo.Core
{
    public interface IController
    {
        Person CreatePerson(string firstName, string lastName, int age, decimal salary);
        Team CreateTeam(string name);
    }
}
