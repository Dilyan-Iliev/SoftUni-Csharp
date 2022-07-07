using _7.Models;

namespace _7.Core.Interfaces
{
    public interface IController
    {
        Citizen CreateCitizien(string name, int age, string id);
        Robot CreateRobot(string model, string id);
    }
}
