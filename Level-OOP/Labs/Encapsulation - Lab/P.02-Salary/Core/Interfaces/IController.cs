using PersonsInfo.Models;

namespace _4.Core.Interfaces
{
    public interface IController
    {
        Person CreatePerson(string firstName, string lastName, int age, decimal salary);
    }
}
