using _7.Models;

namespace _7.Core.Interfaces
{
    public interface IController
    {
        Citizen CreateCitizien(string name, int age, string id, string birthdate);
        Robot CreateRobot(string model, string id);
        Pet CreatePet(string name, string birthdate);
    }
}
