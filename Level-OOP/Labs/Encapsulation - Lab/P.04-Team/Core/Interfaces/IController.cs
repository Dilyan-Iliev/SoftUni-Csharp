using PersonsInfo.Models;

namespace _5.Core.Interfaces
{
    public interface IController
    {
        Person CreatePerson(string firstName, string lastName, int age, decimal salary);
        Team CreateTeam(string name);
    }
}
